# Immigration Form Filling 

[![N|Solid](https://res-4.cloudinary.com/crunchbase-production/image/upload/c_lpad,h_256,w_256,f_auto,q_auto:eco/apptopia/app/1b027a7f-520e-432b-a107-97271243d366)](https://www.linkedin.com/in/osman-elamin/)

Immigration forms filler applications is built for VanHack Hackathon Challenge for 2019. It's a conosle application build wih .Net Core 2.2 , it reads candidates information from HiredCandidates.csv located on dataset folder , then uses immigation form exists withing projects content on Doc file (titled ESDC-EMP5624.pdf) .

# Running Application!

  - All default configuration shipped with the solution .User can still do any changes on appsettings.json file .
  - appsetting.json contiains information on where to find CVS , form template & output directory.
  - appsetting containers number of expected candidates which is used for testing to insure the applicatioin generates forms for all candidiates as expected .
  - Before Running the application , make sure you fill all required filed on the CSV file located on (Dataset\TalentsForms.csv).
  - The template pdf file is located on on Docs folder named ESDC-EMP5624.pdf .
  - Generated files will saved with Talent Id appended to it's name , located on Docs\output .


### 3rd Party Tools and Extensions

The application uses a number of open source projects to work properly:

* [itext7] Version 7.1.8 -  a community version for itext7 to manipulate PDF Documents in .NET .
* [CsvHelper] Version 12.2.1 - A .NET library for reading and writing CSV files. Extremely fast, flexible, and easy to use.
* [Microsoft.Extensions.Configuration.FileExtensions] Version 3.0.0
* [Microsoft.Extensions.Configuration.Json] Version 3.0.0]
* [Microsoft.Extensions.Configuration] Version 3.0.0
* [NLog for .NET Framework] Version 4.6.8 flexible and free logging platform for various .NET platforms.
* [xUnit] Version 2.4.1 -  free, open source, community-focused unit testing tool for the .NET Framework.




   [itext7]: <https://github.com/itext/itext7-dotnet>
   [CsvHelper]: <https://joshclose.github.io/CsvHelper/>
   [Microsoft.Extensions.Configuration.FileExtensions]: <https://www.nuget.org/packages/Microsoft.Extensions.Configuration.FileExtensions/3.1.0-preview3.19553.2>
   [Microsoft.Extensions.Configuration.Json]: <https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json/3.1.0-preview3.19553.2>
   [Microsoft.Extensions.Configuration]: <https://www.nuget.org/packages/Microsoft.Extensions.Configuration/3.1.0-preview3.19553.2>
   [NLog for .NET Framework]: <https://nlog-project.org/>
   [xUnit]: <https://xunit.net/>

