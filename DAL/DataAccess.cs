using CsvHelper;
using ImmigrationFormFiller.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;

namespace ImmigrationFormFiller
{
    public static class DataAccess
    {
        private static string TalentCsvfile = Utility.CandidiateCsvPath; 
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static List<Talent> GetAllTalent()
        {

            Logger.Info("Start Reading Candidiates Dataset..");

            if (!File.Exists(TalentCsvfile))
                throw new Exception("Failed to read from Candidicate CSV, please make sure it's exists");

            List<Talent> Talent = new List<Talent>();
            try
            {
                using (var csvReader = new StreamReader(TalentCsvfile))
                using (var csv = new CsvReader(csvReader))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        string id = csv.GetField("id");
                        string isOccupationPublishedOnTFW = csv.GetField("isOccupationPublishedOnTFW");
                        string isEmployerReferedByGTSByPartner = csv.GetField("isEmployerReferedByGTSByPartner");
                        string PartnerOrganizationName = csv.GetField("PartnerOrganizationName");
                        string PrincipalPartnerContactFirstName = csv.GetField("PrincipalPartnerContactFirstName");
                        string PrincipalPartnerContactMiddleName = csv.GetField("PrincipalPartnerContactMiddleName");
                        string PrincipalPartnerContactLastName = csv.GetField("PrincipalPartnerContactLastName");
                        string PrincipalPartnerContactTelephone = csv.GetField("PrincipalPartnerContactTelephone");
                        string PrincipalPartnerContactTelephone2 = csv.GetField("PrincipalPartnerContactTelephone2");
                        string PrincipalPartnerContactFax = csv.GetField("PrincipalPartnerContactFax");
                        string PrincipalPartnerContactEmail = csv.GetField("PrincipalPartnerContactEmail");
                        string PrincipalPreferedOralCommunicationLanguage = csv.GetField("PrincipalPreferedOralCommunicationLanguage");
                        string PrincipalPreferedWrittenCommunicationLanguage = csv.GetField("PrincipalPreferedWrittenCommunicationLanguage");
                        string AlternativePartnerOrganizationName = csv.GetField("AlternativePartnerOrganizationName");
                        string AlternativePartnerContactFirstName = csv.GetField("AlternativePartnerContactFirstName");
                        string AlternativePartnerContactLastName = csv.GetField("AlternativePartnerContactLastName");
                        string AlternativePartnerContactMiddleName = csv.GetField("AlternativePartnerContactMiddleName");
                        string AlternativePreferedOralCommunicationLanguage = csv.GetField("AlternativePreferedOralCommunicationLanguage");
                        string AlternativePreferedWrittenCommunicationLanguage = csv.GetField("AlternativePreferedWrittenCommunicationLanguage");
                        string AlternativePartnerContactTelephone = csv.GetField("AlternativePartnerContactTelephone");
                        string AlternativePartnerContactTelephone2 = csv.GetField("AlternativePartnerContactTelephone2");
                        string AlternativePartnerContactFax = csv.GetField("AlternativePartnerContactFax");
                        string AlternativePartnerContactEmail = csv.GetField("AlternativePartnerContactEmail");

                       Talent talent = new Talent(
                         id,
                         isOccupationPublishedOnTFW,
                         isEmployerReferedByGTSByPartner,
                         PartnerOrganizationName,
                         PrincipalPartnerContactFirstName,
                         PrincipalPartnerContactMiddleName,
                         PrincipalPartnerContactLastName,
                         PrincipalPartnerContactTelephone,
                         PrincipalPartnerContactTelephone2,
                         PrincipalPartnerContactFax,
                         PrincipalPartnerContactEmail,
                         PrincipalPreferedOralCommunicationLanguage,
                         PrincipalPreferedWrittenCommunicationLanguage,
                         AlternativePartnerOrganizationName,
                         AlternativePartnerContactFirstName,
                         AlternativePartnerContactLastName,
                         AlternativePartnerContactMiddleName,
                         AlternativePreferedOralCommunicationLanguage,
                         AlternativePreferedWrittenCommunicationLanguage,
                         AlternativePartnerContactTelephone,
                         AlternativePartnerContactTelephone2,
                         AlternativePartnerContactFax,
                         AlternativePartnerContactEmail
                        );
                        Talent.Add(talent);
                    }
                }
                Logger.Info($"Finished Reading Candidiates Dataset..{Talent.Count.ToString()} candidicates data has been read..!");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.Message);
            }
            return Talent;
        }

    }
}
