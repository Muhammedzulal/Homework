using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkCarpet
{
    internal class FileOperations
    {
        //Dosya yolu
        static string Filepath= "C:\\Users\\muham\\OneDrive\\Masaüstü\\Carpet.txt";

        //Clear File
        public static void ClearFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Filepath, false))
                {
                    sw.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error clearing file: " + ex.Message);
            }
        }

        //Count Line
        public static int CountLines()
        {
            try
            {
                int lineCount = 0;
                using (StreamReader sr = new StreamReader(Filepath))
                {
                    while (sr.ReadLine() != null)
                    {
                        lineCount++;
                    }
                }
                return lineCount;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error counting lines: " + ex.Message);
                return 0;
            }
        }


        //Write to File
        public static void WriteToFile(string txt)
        {
            using(StreamWriter sw=new StreamWriter(Filepath, true))
            {
                sw.WriteLine(txt);
            }
            
        }

        //Read File
        public static string ReadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Filepath))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
                return null;
            }
        }

        //Find Customer
        public static string FindCustomer(int Id)
        {
            string customerNo = "Id: " + Id;
            string[] lines = File.ReadAllLines(Filepath);
            foreach (string line in lines)
            {
                if (line.Contains(customerNo))
                {
                    return line;
                }
            }
            return null;
        }
        //Durum Kontrol
        public static int StatusControl(int Id)
        {
            string customerNo = "Id: " + Id;
            string[] lines = File.ReadAllLines(Filepath);
            foreach (string line in lines)
            {
                if (line.Contains(customerNo))
                {
                    string[] parts = line.Split(',');
                    return Convert.ToInt32(parts[1]);
                }
            }
            return -1; // Not found
        }

        //Durum Güncelle
        public static void StatusUpdate(int Id)
        {
            string customerNo = "Id: " + Id;
            string[] lines = File.ReadAllLines(Filepath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(customerNo))
                {
                    string[] parts = lines[i].Split(',');
                    parts[1] = "1"; // Update status to 1
                    lines[i] = string.Join(",", parts);
                    break;
                }
            }
            File.WriteAllLines(Filepath, lines);
        }
        //Yıkanmışları Oku
        public static string ReadWashed()
        {
            string[] lines = File.ReadAllLines(Filepath);
            string result = "";
            foreach (string line in lines)
            {
                if (line.Contains(",1,"))
                {
                    string[] parts = line.Split(',');//02345 89
                    result += $"{parts[0]} {parts[2].Substring(6)} {parts[3].Substring(7)} {parts[4].Substring(9)} {parts[5].Substring(8)} Adet {parts[8].Substring(14)} {parts[9].Substring(7)}\r\n";                    
                }
            }
            return result;
        }
        //Yıkanmamışları Oku
        public static string ReadUnwashed()
        {
            string[] lines = File.ReadAllLines(Filepath);
            string result = "";
            foreach (string line in lines)
            {
                if (line.Contains(",0,"))
                {
                    string[] parts = line.Split(',');//02345 89
                    result += $"{parts[0]} {parts[2].Substring(6)} {parts[3].Substring(7)} {parts[4].Substring(9)} {parts[5].Substring(8)} Adet {parts[8].Substring(14)} {parts[9].Substring(7)}\r\n";
                }
            }
            return result;
        }

    }
}
