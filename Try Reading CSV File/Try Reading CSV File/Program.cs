using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try_Reading_CSV_File
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
        private void ReadingCSVFile()
        {
            string path = @"C:\myFile.csv";
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] row;
                List<user> list = new List<user>();

                while ((line = sr.ReadLine()) != null)
                {
                    row = line.Split(',');
                    user u = new user();
                    u.username = row[0];
                    u.ColumnB = row[1];
                    md.ColumnC = row[2];
                    md.ColumnD = row[3];
                    list.Add(md);
                }
            }

}

