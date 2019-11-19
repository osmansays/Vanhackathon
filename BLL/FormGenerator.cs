using ImmigrationFormFiller.Model;
using iText.Forms;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ImmigrationFormFiller.BLL
{
   public class FormGenerator
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private static string pdfTemplateFullPath = Utility.FormPdfTeampltePath;

     
        public static int GeneratetalentPDF(List<Talent> Talent)
        {
            if (!File.Exists(pdfTemplateFullPath))
                throw new Exception("Failed to read Template file , please make sure it's exists");
            FileInfo temaplateFileInfo = new FileInfo(pdfTemplateFullPath);
            string templateFileName = temaplateFileInfo.Name.Replace(".pdf", "");
            int sucessFileCreationCounter = 0;
            try
            {
                foreach (Talent talent in Talent)
                {

                    string destFileName = pdfTemplateFullPath.Replace($"{temaplateFileInfo.Name}", $@"output\{templateFileName}-{talent.id.ToString()}.pdf");
                    using (var reader = new PdfReader(pdfTemplateFullPath))
                    {
                        PdfTemplate pdfTemplate = new PdfTemplate();
                        if (reader == null)
                            throw new Exception("Failed to read Template file , please make sure it's exists and it's not used by other application");
                        reader.SetUnethicalReading(true);
                        using (var pdfWriter = new PdfWriter(destFileName))
                        using (var pdfDoc = new PdfDocument(reader, pdfWriter))
                        {
                            if (pdfWriter == null || pdfDoc == null)
                                throw new Exception("Failed to write to File/Directory , please make sure the write access is granted the on destination folder and the file is not used by other application ");
                            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
                            string message = $"Reading and Mapping Fields for user id={talent.id.ToString()}..";
                            Logger.Info(message);
                            foreach (PropertyInfo propertyInfo in talent.GetType().GetProperties())
                            {
                                string feildValue = propertyInfo.GetValue(talent, null).ToString();
                                string pdfFieldName = pdfTemplate.GetPdfFiled(propertyInfo.Name, feildValue);
                                if ((feildValue.ToLower() == "yes") || (feildValue.ToLower() == "english")|| (feildValue.ToLower() == "french"))
                                    feildValue = "1";
                                if (feildValue.ToLower() == "no")
                                    feildValue = "0";

                                if (pdfFieldName.Length > 0)
                                {
                                    form.GetField(pdfFieldName).SetValue(feildValue);
                                 
                                }
                            }
                            sucessFileCreationCounter++;
                            PdfAcroForm.GetAcroForm(pdfDoc, true).FlattenFields();
                            pdfDoc.Close();
                            if (File.Exists(destFileName))
                            {
                                string message = $"Application form has been filled for user id={talent.id.ToString()}..";
                                Logger.Info(message);

                            }
                            else
                            {
                                string message = $"Failed to Generate Application form for user id={talent.id.ToString()}";
                                Logger.Info(message);
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.Message);
            }

            return sucessFileCreationCounter;
        }

    }
}
