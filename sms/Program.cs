using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sms
{
    class betu
    {
        public List<string> betulista;
        public betu(List<string> betulista)
        {
            this.betulista = betulista;
        }
    }
    internal class Program
    {
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
            List<betu> betuk = new List<betu>();
            
            betuk.Add(new betu(new List<string>() {"a", "b", "c"}));
            betuk.Add(new betu(new List<string>() {"d", "e", "f"}));
            betuk.Add(new betu(new List<string>() {"g", "h", "i"}));
            betuk.Add(new betu(new List<string>() {"j", "k", "l"}));
            betuk.Add(new betu(new List<string>() {"m", "n", "o"}));
            betuk.Add(new betu(new List<string>() {"p", "q", "r", "s"}));
            betuk.Add(new betu(new List<string>() {"t", "u", "v"}));
            betuk.Add(new betu(new List<string>() {"w", "x", "y", "z"}));

            foreach (var item in betuk)
            {
                foreach (var item1 in item.betulista)
                {
                    Console.WriteLine(item1);
                }
            }
            
            Console.Write("Adjon meg egy betűt: ");
            string betuinput = Console.ReadLine();

            var gomb = betuk.FirstOrDefault(b => b.betulista.Contains(betuinput));
            if(gomb == null)
                Console.WriteLine("Érvénytelen betű.");
            else
                Console.WriteLine($"A betű nyomógombja: {betuk.IndexOf(gomb) + 2}");
            


            Console.WriteLine();
            Console.WriteLine("Nyomja meg az ENTER-t a kilépéshez");
            Console.ReadLine();
        }
    }
}
