using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sms
{
    internal class Program
    {
        static string szamsor(List<string> betuk, string szo)
        {
            string szamsor = "";

            for (int i = 0; i < szo.Length; i++)
            {
                szamsor += Convert.ToString(betuk.IndexOf(betuk.FirstOrDefault(b => b.Contains(szo[i].ToString())))+2);
            }

            return szamsor;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            /*
            SMS
            MG 2025.10.13.
            */
            string fejlec = "SMS";
            Console.WriteLine(fejlec);

            for (int i = 0; i < fejlec.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            List<string> szavak = File.ReadAllLines("../../szavak.txt").ToList();
            List<string> betuk = new List<string>();
            
            betuk = new List<string> { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            
            bool loop = false;
            while (loop == false)
            {
                Console.Write("Adjon meg egy betűt: ");
                string betuinput = Console.ReadLine();
                var gomb = betuk.FirstOrDefault(b => b.Contains(betuinput));
                if (gomb == null)
                    Console.WriteLine("\tÉrvénytelen betű.");
                else
                { 
                    Console.WriteLine($"\tA betű nyomógombja: {betuk.IndexOf(gomb) + 2}");
                    loop = true;
                }
            }
            loop = false;
            while (loop == false)
            {
                Console.Write("Adjon meg egy szavat: ");
                string szoinput = Console.ReadLine();

                string szamkomb = szamsor(betuk, szoinput);
                if (szamkomb.Contains("1"))
                    Console.WriteLine("\tA szó érvénytelen karaktereket tartalmaz");
                else
                {
                    Console.WriteLine($"\tA '{szoinput}' szónak a gombkombinációja: {szamkomb}");
                    loop = true;
                }
            }
            Console.WriteLine();
            string leghosszabbszo = szavak.OrderByDescending(szo => szo.Length).First();
            Console.WriteLine($"A leghosszabb szó: {leghosszabbszo}.");
            Console.WriteLine();
            int rovidszo = 0;
            foreach (var szo in szavak)
            {
                if(szo.Length <= 5)
                    rovidszo++;
            }
            Console.WriteLine($"A rövid szavak száma: {rovidszo}");

            StreamWriter kodok = new StreamWriter("../../kodok.txt");
            foreach (var szo in szavak)
            {
                kodok.WriteLine(szamsor(betuk, szo));
            }
            
            kodok.Close();
            Console.WriteLine();
            Console.Write("Adjon meg egy számsort: ");
            string szamsorinput = Console.ReadLine();

            List<string> talalt = new List<string>();
            for (int i = 0; i < szavak.Count; i++)
            {
                if (szamsor(betuk, szavak[i]) == szamsorinput)
                {
                    talalt.Add(szavak[i]);
                }
            }
            if (talalt.Count == 0)
            {
                Console.WriteLine("\tNincs ilyen számsorhoz tartozó szó.");
            }
            else
            {
                Console.WriteLine("\tA megadott számsorhoz tartozó szavak:");
                foreach (var item in talalt)
                {
                    Console.WriteLine("\t\t"+item);
                }
            }
            Console.WriteLine();
      
            Dictionary<string, List<string>> kodokdik = new Dictionary<string, List<string>>();
            for (int i = 0; i < szavak.Count; i++)
            {
                string kod = szamsor(betuk, szavak[i]);
                if (!kodokdik.ContainsKey(kod))
                {
                    kodokdik.Add(kod, new List<string>());
                }
                kodokdik[kod].Add(szavak[i]);
            }
            Console.WriteLine("8. feladat: ");
            foreach (var pair in kodokdik)
            {
                if (pair.Value.Count > 1)
                {
                    for (int j = 0; j < pair.Value.Count; j++)
                    {
                        Console.Write(pair.Value[j] + " : " + pair.Key + "; ");
                    }
                }
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("9. feladat: ");

            string leghosszabbkod = "";
            int leghosszabbdb = 0;

            foreach (var pair in kodokdik)
            {
                if (pair.Value.Count > leghosszabbdb)
                {
                    leghosszabbdb = pair.Value.Count;
                    leghosszabbkod = pair.Key;
                }
            }

            Console.WriteLine($"A legtöbb szó a '{leghosszabbkod}' kódhoz tartozik ({leghosszabbdb} db):");
            foreach (var szo in kodokdik[leghosszabbkod])
            {
                Console.WriteLine("\t" + szo);
            }


            Console.WriteLine();
            Console.WriteLine("Nyomja meg az ENTER-t a kilépéshez");
            Console.ReadLine();
        }
    }
}
