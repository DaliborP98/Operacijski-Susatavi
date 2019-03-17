using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zad2
{
    class Program
    {
        static void Main(string[] args)
        {

            string put_upisi = @"D:\direktoriji.txt";
            string put_citaj = @"D:\";

            //Kreiranje tekstualne datoteke
            DirectoryInfo[] direktoriji = new DirectoryInfo(@"D:\").GetDirectories();

            using (StreamWriter sw = File.CreateText(put_upisi))
            {
                sw.WriteLine("Popis direktorija na {0}", put_citaj);
                sw.WriteLine("\n************* POČETAK *************");

                foreach (DirectoryInfo dir in direktoriji)
                {
                    sw.WriteLine(dir.Name);
                }
                sw.WriteLine("************* GOTOVO *************");
            }

            Console.WriteLine("Popis direktorija zapisan u {0}", put_upisi);
            Console.ReadLine();

            //Čitanje iz datoteke
            using (StreamReader sr = File.OpenText(put_upisi))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            Console.ReadLine();

            //konzolna aplikacija za tekst po zelji

            string put_upisi1 = @"D:\Tekstualna_Datoteka.txt";
            string upis = "";
            List<string> tekst = new List<string>();


            if (File.Exists(put_upisi1))
            {
                File.Delete(put_upisi1);
            }

            using (StreamWriter sw = File.CreateText(put_upisi1))
            {
                Console.WriteLine("UPIS PODATAKA U FILE");
                Console.WriteLine("Pritisni 1 da izades iz upisivanja");
                Console.WriteLine("");

                // Upis podataka u file
                int i = 0;
                do
                {
                    Console.Write("Upisi ime[{0}]: ", ++i);
                    upis = Console.ReadLine();

                    if (!(upis == "1"))
                        tekst.Add(upis);
                } while (!(upis == "1"));
                Console.WriteLine("\n****************");

                //spremanje liste u file.txt
                foreach (string str in tekst)
                {
                    sw.WriteLine(str);
                }
            }

            using (StreamReader sr = File.OpenText(put_upisi1))
            {
                Console.WriteLine("UPISANI PODACI U FILE-u");
                Console.WriteLine("");
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

        }
    }
}
