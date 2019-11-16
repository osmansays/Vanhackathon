using System;
using System.Collections.Generic;
using System.IO;

namespace ImmigrationFormFiller
{
    class Program
    {
        static void Main(string[] args)
        {
            //DirectoryInfo directoryInfo = new DirectoryInfo();
             List<Candidate> candidates= Utility.GetCandidatesFromCSV(@"..\..\..\dataset\HiredCandidates.csv");
            //   var FormDocument = PdfDocument.FromFile(@"..\..\..\Docs\ESDC-EMP5624.pdf");

            Utility.GenerateCandidatePDF(candidates, @"..\..\..\Docs\ESDC-EMP5624.pdf", @"..\..\..\Docs\ESDC-EMP5624.pdf");
        }
    }
}
