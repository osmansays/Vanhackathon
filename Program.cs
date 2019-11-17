using NLog;
using System;
using System.Collections.Generic;
using System.IO;


namespace ImmigrationFormFiller
{
    class Program
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            
            string CurrentDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                ConfigureLogging(CurrentDirectoryPath);
                Logger.Info("Application Started to run..");
                List<Candidate> candidates = DataAccess.GetAllCandidates();
                int generatedFilesCount = Utility.GenerateCandidatePDF(candidates);

                if (generatedFilesCount > 0)
                    Logger.Info($@"{generatedFilesCount} Application forms has been generated , all files located on Docs\output folder");
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

        private static void ConfigureLogging(string currentdirectorypath)
        {
            string logFileName= $"log-{ DateTime.Now.ToString().Replace(@"/","-")}.txt";
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = $@"{currentdirectorypath}logs\{logFileName}" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            NLog.LogManager.Configuration = config;
        }
    }
}
