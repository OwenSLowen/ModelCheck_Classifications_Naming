using Objects;
using Objects.Geometry;
using Speckle.Automate.Sdk;
using Speckle.Core.Logging;
using Speckle.Core.Models.Extensions;
using System;
using System.IO;
using System.Text;

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

        string path = @"C:\temp\MyTest.txt"; // Specify the path where you want to create the file

        try
        {
            // Create the file, or overwrite if it already exists
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new byte [54321];
                fs.Write(info, 0, info.Length);
                Console.WriteLine($"Fiction {info} objects");
            }

            // Open the stream and read from the file (optional)
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    automationContext.MarkRunSuccess($"Counted {count} objects");

    
  }
}
