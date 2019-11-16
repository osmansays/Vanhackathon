using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ImmigrationFormFiller
{
    public static class Utility
    {
        public static List<Candidate> GetCandidatesFromCSV(string csvPath)
        {
            List<Candidate> candidates = new List<Candidate>();
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    int userid = csv.GetField<int>("UserId");
                    int jobid = csv.GetField<int>("HiredForJobId");
                    string skills = csv.GetField("Skills");
                    string position = csv.GetField("UsersPosition");
                    Candidate candidate = new Candidate(userid, jobid, skills, position);
                    candidates.Add(candidate);
                }
            }
            return candidates;
        }

    

        public static void GenerateCandidatePDF(List<Candidate> candidates,string pdfSourcePath , string pdfDestPath)
        {


            foreach (Candidate _candidate in candidates)
            {
                Aspose.Pdf.Facades.Form pdfForm = new Aspose.Pdf.Facades.Form();
                pdfForm.BindPdf(pdfSourcePath);
                pdfForm.FillField("EMP5624_E[0].Page2[0].txtF_Emp_Legal[0]", _candidate.UserId);
                pdfForm.FillField("EMP5624_E[0].Page2[0].txtF_Emp_Legal[0]", _candidate.SkillsAsText);
               // pdfForm.FillField("EMP5624_E[0].Page2[0].txtF_Emp_Legal[0]", _candidate.UserId);
              ////  pdfForm.FillField("EMP5624_E[0].Page2[0].txtF_Emp_Legal[0]", _candidate.UserId);
                pdfForm.Save($"{pdfDestPath.Replace(".pdf","")}{_candidate.UserId}.pdf");
            }

        }

    }
}
