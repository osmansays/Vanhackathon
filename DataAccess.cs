using CsvHelper;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImmigrationFormFiller
{
   public static class DataAccess
    {
        private static string CurrentDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        private static string candidatesCsvfile = $@"{CurrentDirectoryPath}Dataset\HiredCandidates.csv";
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();


        public static string GetCandidateFilePath()
        {
            return candidatesCsvfile;
        }


        public static List<Candidate> GetAllCandidates()
        {

            Logger.Info("Start Reading Candidiates Dataset..");

            if (!File.Exists(candidatesCsvfile))
                throw new Exception("Failed to read from Candidicate CSV, please make sure it's exists");

            List<Candidate> candidates = new List<Candidate>();
            try
            {
                using (var csvReader = new StreamReader(candidatesCsvfile))
                using (var csv = new CsvReader(csvReader))
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
                Logger.Info($"Finished Reading Candidiates Dataset..{candidates.Count.ToString()} candidicates data has been read..!");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.Message);
            }
            return candidates;
        }

    }
}
