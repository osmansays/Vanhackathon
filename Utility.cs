using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using iText.Kernel.Pdf;
using iText.Forms;

namespace ImmigrationFormFiller
{
    public static class Utility
    {
        private static string CurrentDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        private static string pdfTemplatePath = $@"{CurrentDirectoryPath}Docs\ESDC-EMP5624.pdf";
        private static string pdfOutputPath = $@"{CurrentDirectoryPath}Docs\output\";

        public static string GetPdfTemplateFilePath()
        {
            return pdfTemplatePath;
        }

        public static string GetOutputFilePath()
        {
            return pdfOutputPath;
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static int GenerateCandidatePDF(List<Candidate> candidates)
        {
            if (!File.Exists(pdfTemplatePath))
                throw new Exception("Failed to read Template file , please make sure it's exists");
            FileInfo temaplateFileInfo = new FileInfo(pdfTemplatePath);
            string templateFileName = temaplateFileInfo.Name.Replace(".pdf", "");
            int sucessFileCreationCounter = 0;
            try
            {
                foreach (Candidate candidate in candidates)
                {

                    string destFileName = pdfTemplatePath.Replace($"{temaplateFileInfo.Name}", $@"output\{templateFileName}-{candidate.UserId}.pdf");
                    using (var reader = new PdfReader(pdfTemplatePath))
                    {
                        if (reader == null)
                            throw new Exception("Failed to read Template file , please make sure it's exists and it's not used by other application");
                        reader.SetUnethicalReading(true);
                        using (var pdfWriter = new PdfWriter(destFileName))
                        using (var pdfDoc = new PdfDocument(reader, pdfWriter))
                        {
                            if (pdfWriter == null || pdfDoc==null)
                                throw new Exception("Failed to write to File/Directory , please make sure the write access is granted the on destination folder and the file is not used by other application ");
                            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
                            form.GetField("EMP5624_E[0].Page1[0].Yes_inn[0]").SetValue("1");
                            form.GetField("EMP5624_E[0].Page1[0].Yes_business[0]").SetValue("1");
                            form.GetField("EMP5624_E[0].Page3[0].txtF_position_title[0]").SetValue(candidate.Position);
                            form.GetField("EMP5624_E[0].Page4[0].txtF_MainDuties[0]").SetValue(candidate.SkillsAsText);
                            sucessFileCreationCounter++;
                            pdfDoc.Close();

                            if (File.Exists(destFileName))
                            {
                                string message = $"Application form has been filled for user id={candidate.UserId.ToString()}..";
                                Logger.Info(message);

                            }
                            else
                            {
                                string message = $"Failed to Generate Application form for user id={candidate.UserId.ToString()}";
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
