using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace downloadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start download");
            Download();
        }

        static void Download()
        {
            Console.WriteLine("Info: downloading for ourAirport.com ...");
            string startupPath = Directory.GetCurrentDirectory();

            string[] name = new string[2]
            {
                "airports.csv",
                "runways.csv"
            };
            Uri[] uris = new Uri[2]
            {
                new Uri("http://ourairports.com/data/airports.csv"),
                new Uri("http://ourairports.com/data/runways.csv")
            };
            
            for (int i = 0; i < uris.Length; i++)
            {
                Console.WriteLine(startupPath + "\\Temp\\airports.csv");
                var wc = new WebClient();
                wc.DownloadFileAsync(uris[i] , startupPath + "\\Temp\\" + name[i] );
            }
        }


        

    }
}
