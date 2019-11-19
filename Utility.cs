using iText.Forms;
using iText.Kernel.Pdf;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace ImmigrationFormFiller
{
    public static class Utility
    {

        private static string CurrentDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

        private static string GetConfigurationValue(string key)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            return (config[key]);
        }

        private static string FilledFormRelativeOuputPath
        {
            get
            {
                return (GetConfigurationValue("FilledImmigrationFormOuputDirectory"));
            }
        }

        private static string CandidiateCsvRelativePath
        {
            get
            {
                return (GetConfigurationValue("CandidiateCsvRelativePath"));
            }
        }

        private static string FormPdfRelativeTeampltePath
        {
            get
            {
                return (GetConfigurationValue("FormPdfRelativeTeampltePath"));
            }
        }

        public static string CandidiateCsvPath
        {
            get
            {
                return $@"{CurrentDirectoryPath}{CandidiateCsvRelativePath}";
            }
        }

        public static string FormPdfTeampltePath
        {
            get
            {
                return $@"{CurrentDirectoryPath}{FormPdfRelativeTeampltePath}";
            }
        }

        public static string FilledFormOuputPath
        {
            get
            {
                return $@"{CurrentDirectoryPath}{FilledFormRelativeOuputPath}";
            }
        }

        private static string LogfileRelativePath
        {
            get {
                return GetConfigurationValue("LogfileRelativePath");
            }
        }

        public static string LogfilePath
        {
            get
            {
                return $@"{CurrentDirectoryPath}\{LogfileRelativePath}";
            }
        }

        public static int NumberOfTalent
        {
            get
            {
                int numberofTalent = int.Parse(GetConfigurationValue("NumberOfTalent"));
                return ( numberofTalent);
            }
        }

    }
}
