using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using csvToDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Relational;

namespace csvToDatabase.Controllers
{
    public class HomeController : Controller
    {
        private PDDbContext _context;
        public HomeController(PDDbContext context)
        {
            _context = context;

        }

        public static void Download()
        {
            Console.WriteLine("Info: downloading for ourAirport ...");
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
                wc.DownloadFileAsync(uris[i], startupPath + "\\Temp\\" + name[i]);
            }


        }

        public void Update()
        {

            // string server = "localhost,3306";
            // string database = "testpicnicday";
            // string user = "root";
            // string pw = "root";

            // string SQLServerConnectionString = String.Format("Data Source={0};Initial Catalog={1};UID={2};Password={3}; POOLING=false;", server, database, user, pw);
            var mustOpen = db.Database.Connection.State != ConnectionState.Open;
            
            string path = Directory.GetCurrentDirectory();
            string[] lines = System.IO.File.ReadAllLines(path + "\\Temp\\airports.csv");

            var table = new DataTable();
            table.Columns.Add("ident", typeof(string));
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("runway", typeof(string));
            table.Columns.Add("latitude", typeof(string));
            table.Columns.Add("longitude", typeof(string));

            for (int i = 1; i < lines.Count() - 1; i++)
            {
                string[] data = lines[i].Split(',');

                string[] roll = new string[5]
                {
                    data[0],
                    data[1],
                    data[2],
                    data[3],
                    data[4]
                };
                    
                table.Rows.Add(roll);
            }

            try
            {
                if (mustOpen)
                    db.Database.Connection.Open();
                using (var bulkCopy = new SqlBulkCopy((db.Database.Connection) as SqlConnection, SqlBulkCopyOptions.Default))
                {
                    bulkCopy.DestinationTableName = "runways";
                    bulkCopy.WriteToServer(table);
                }

            }
            finally
            {
                if (mustOpen)
                    db.Database.Connection.Close();
            }
            // foreach(string c in lines)
            // {
            //     Console.WriteLine(c);
            // }
            
            // string[] columns = lines[4].Split(',');
            // double latia = Double.Parse(columns[3],CultureInfo.InvariantCulture);
            // double longia = Double.Parse(columns[4],CultureInfo.InvariantCulture);
            // Console.WriteLine(latia);
            // Console.WriteLine(longia);

            // foreach(string c in columns)
            // {
            //     Console.WriteLine(c);
            // }
            

            // table.Rows.Add(columns);

            

            // foreach (DataRow dataRow in table.Rows)
            // {
            //     foreach (var item in dataRow.ItemArray)
            //     {
            //     Console.WriteLine(item);
            //     }
            // }

            // SqlConnection con = new SqlConnection(SQLServerConnectionString);
            // con.Open();
            // var sqlBulk = new SqlBulkCopy(con);
            // sqlBulk.DestinationTableName = "runways";
            // sqlBulk.WriteToServer(table);

            // con.Close();
        }
    }
}