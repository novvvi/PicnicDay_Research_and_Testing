using System;
// https://joshclose.github.io/CsvHelper/getting-started
using CsvHelper;
// StreamReader are library in ASP.NET , which require to use System.IO (refer to note1)
using System.IO;
using System.Collections.Generic;
using CSVParser.Models;
using System.Globalization;

namespace CSVParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            
            //using (var reader = new StreamReader("c\\Users\\noveh\\Dropbox\\project\\picnicDay\\CSVParser\\testtable.csv"))
            // path to csv : c\\Users\\noveh\\project\\picnicDay\\CSVParser\\testtable.csv

            string path =  null; 
            
            List<TestModel> dataList = new List<TestModel>();

            try
            {
                // get project folder path
                // https://stackoverflow.com/questions/816566/how-do-you-get-the-current-project-directory-from-c-sharp-code-when-creating-a-c
                path = Directory.GetCurrentDirectory() +  "\\testtable.csv";
                Console.WriteLine(path);
                var csv = new CsvReader(new StreamReader(path));
                var csvList = csv.GetRecords<TestModel>(); // Iemurble object

                foreach(var c in csvList)
                {
                    TestModel data  = new TestModel();
                    
                    try
                    {
                        // c.ColC is a ReadOnlySpan<char> using .ToString() to covent
                        // https://stackoverflow.com/questions/22016751/cannot-convert-datetime-string-with-datetime-parseexact
                        Console.WriteLine(c.ColC);
                        data.ColC = DateTime.Parse(c.ColC.ToString());
                    }
                    catch
                    {
                        Console.WriteLine("CSV string datetime not save to varible correctly");
                    }

                    data.ColA = c.ColA;
                    data.ColB = int.Parse(c.ColB.ToString());
                    

                    dataList.Add(data);
                }

                foreach(TestModel d in dataList)
                {
                    Console.WriteLine("this ColA " + d.ColA);
                    Console.WriteLine("this ColB " + d.ColB);
                    Console.WriteLine("this ColC " + d.ColC);
                }

            }
            catch
            {
                Console.WriteLine("Somewrong");
            }
            




            // Code below this point will be used in Controller
            // https://www.youtube.com/watch?v=B1E6utVhHbE

            // [httpPost]
            // public ActionResult Index(HttpPostedFileBase file)
            // {
            //     string path = null;

            //     List<TestModel> dataList = new List<TestModel>();
                
            //     // Testcase !!!
            //     try
            //     {
            //         if (file.ContentLength > 0) // check the filename or content are something in it
            //         {
            //             var fileName = Path.GetFileName(file.FileName);
            //             path = AppDomain.CurrentDomain.BaseDirectory + "upload\\" + fileName;
            //             file.SaveAs(path);

            //             var csv = new CsvReader(new StreamReader(path));
            //             var csvList = csv.GetRecords<TestModel>(); // Iemurble object

            //             foreach(var c in csvList)
            //             {
            //                 TestModel data  = new TestModel();
                            
            //                 try
            //                 {
            //                     // c.ColC is a ReadOnlySpan<char> using .ToString() to covent
            //                     // https://stackoverflow.com/questions/22016751/cannot-convert-datetime-string-with-datetime-parseexact
            //                     data.ColC = DateTime.ParseExact(c.ColC.ToString(), "mm/dd/yyyy", CultureInfo.InvariantCulture);
            //                 }
            //                 catch
            //                 {
            //                     // do nothing
            //                 }

            //                 data.ColA = c.ColA;
            //                 data.ColB = int.Parse(c.ColB.ToString());
                            

            //                 dataList.Add(data);
            //             }
            //         }
            //     }
            //     catch
            //     {
            //         ViewData["error"] = "Upload Failed";
            //     }
            //     return view();
            // }

        }
    }
}


