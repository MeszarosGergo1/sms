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
                    Console.WriteLine("Érvénytelen betű.");
                else
                { 
                    Console.WriteLine($"A betű nyomógombja: {betuk.IndexOf(gomb) + 2}");
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
                    Console.WriteLine("A szó érvénytelen karaktereket tartalmaz");
                else
                {
                    Console.WriteLine($"A '{szoinput}' szónak a gombkombinációja: {szamkomb}");
                    loop = true;
                }
            }

            string leghosszabbszo = szavak.OrderByDescending(szo => szo.Length).First();
            Console.WriteLine($"A leghosszabb szó: {leghosszabbszo}.");

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

            Console.Write("Adjon meg egy számsort: ");
            string szamsorinput = Console.ReadLine();

            for (int k = 0; k < szamsorinput.Length; k++)
            {
                List<string> talalt = new List<string>();
                for (int j = 0; j < betuk[szamsorinput[k]-2].Length; j++)
                {
                    talalt[k] += betuk[szamsorinput[k]-2][j];
                }
            }



            Console.WriteLine();
            Console.WriteLine("Nyomja meg az ENTER-t a kilépéshez");
            Console.ReadLine();
        }
    }
}
