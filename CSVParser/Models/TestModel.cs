using System;
// this is the library for CsvField (refer to note1)
//using CsvHelper.Configuration;


namespace CSVParser.Models
{
    public class TestModel
    {
        public string ColA {get; set;}

        //note1 if there is a space at the column name 
        //[CsvField(name="Col B")]
        public int ColB {get; set;}
        public DateTime ColC {get; set;}
    }
}
