using Objects;
using Objects.Geometry;
using Speckle.Automate.Sdk;
using Speckle.Core.Logging;
using Speckle.Core.Models.Extensions;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
//using Aspose.Cells;

public static class AutomateFunction
{
  public static async Task Run(
    AutomationContext automationContext,
    FunctionInputs functionInputs
  )
  {
    Console.WriteLine("Starting execution");
    _ = typeof(ObjectsKit).Assembly; // INFO: Force objects kit to initialize

    Console.WriteLine("Receiving version");
    var commitObject = await automationContext.ReceiveVersion();

    Console.WriteLine("Received version: " + commitObject);

    var count = commitObject
      .Flatten()
      .Count(b => b.speckle_type == functionInputs.SpeckleTypeToCount);

    Console.WriteLine($"Counted {count} objects");
    Console.WriteLine("Random text");
    string path = "c:\\temp\\MyTest.txt";

            // Create the file, or overwrite if it already exists
           // using (FileStream fs = File.Create(path))
           // {
           //     byte[] info = new UTF8Encoding(true).GetBytes("textystuff");
           //     fs.Write(info, 0, info.Length);
           //     Console.WriteLine(path);
           // }
        
            // Instantiate a Workbook object.
        //Workbook workbook = new Workbook();

        // Add a new worksheet to the Excel object.
        //Worksheet worksheet = workbook.Worksheets.Add("MySheet");

        // Input your report data into the cells of the worksheet (e.g., worksheet.Cells["A1"].PutValue("Hello, World!")).

        // Save the Excel file.
       // string filePathWithData = @"C:\temp\MyExcelFileWithData.xlsx";
        //workbook.Save(filePathWithData);
        // Open the stream and read from the file (optional)
        using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
       
      
    automationContext.MarkRunSuccess($"Counted {count} objects");

    
  }
}
