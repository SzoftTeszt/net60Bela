// See https://aka.ms/new-console-template for more information
using LottoAdat;
using LottoAdat.Data;

namespace Lottos
{
    class Program
    {
        static void Main(string[] args)
        {
            LottoAdatContext db = new LottoAdatContext();
            if (!db.Szamsorok.Any())
            {
                string[] sorok = File.ReadAllLines(@"C:\Adat\LottoSzamok.csv");
                LottoSzamok lsz = new LottoSzamok();
                bool siker = true;
                foreach (var item in sorok)
                {
                    siker = true;
                    try { lsz = new LottoSzamok(item); }
                    catch (ArgumentException e) { siker = false; }
                    if (siker) db.Szamsorok.Add(lsz);
                    else Console.WriteLine($"Hibás: {item}");
                }
                db.SaveChanges();
            }

            foreach (var item in db.Szamsorok)
            {
                Console.WriteLine(item);
            }
        }
    }
}

            // C:\Adat\LottoSzamok.csv
  