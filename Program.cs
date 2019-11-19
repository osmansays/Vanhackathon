using ImmigrationFormFiller.BLL;
using ImmigrationFormFiller.Model;
using NLog;
using System;
using System.Collections.Generic;


namespace ImmigrationFormFiller
{
    class Program
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static readonly string CurrentDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        static void Main(string[] args)
        {
          
            SettingLogConfigurations(CurrentDirectoryPath); 
           
            try
            {
                Logger.Info("Application Started to run..");
                List<Talent> Talent = DataAccess.GetAllTalent();
                int generatedFilesCount = FormGenerator.GeneratetalentPDF(Talent);

                if (generatedFilesCount > 0)
                    Logger.Info($@"{generatedFilesCount} Application forms has been generated , all files located on {Utility.FilledFormOuputPath} folder");
                else
                    Logger.Info($"No Files Has Been Generated , please make sure the CSV file exists and it's not empty!");
                Console.WriteLine("Press any key to exit!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.Message);
            }
        }

        private static void SettingLogConfigurations(string currentdirectorypath)
        {
           

            string logFileName= $"log-{ DateTime.Now.ToString().Replace(@"/","-")}.txt";
            var logconfig = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = Utility.LogfilePath };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            logconfig.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            logconfig.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            NLog.LogManager.Configuration = logconfig;
        }
    }
}
