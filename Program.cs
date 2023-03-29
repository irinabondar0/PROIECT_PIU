using System;
using System.Configuration;
using LibrarieModele;
using NivelStocareDate;

namespace EvidentaProduse_Consola
{
    class Program
    {
        static void Main()
        {
            Produs produs = new Produs();
            string evidenta_studenti = ConfigurationManager.AppSettings["evidenta_studenti"];
            AdministrareProduse_FisierText adminProduse = new AdministrareProduse_FisierText(evidenta_studenti);
            int nrProduse = 0;

            string optiune;
            do
            {
                Console.WriteLine("I. Introducere informatii produs");
                Console.WriteLine("A. Afisare produse");
                Console.WriteLine("F. Afisare produse din fisier");
                Console.WriteLine("S. Salvare produs in fisier");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "I":
                        int idProdus = nrProduse + 1;
                        Console.WriteLine("Introdu numele produsului {0} : ", idProdus);
                        string nume = Console.ReadLine();
                        //Console.WriteLine("Introdu prenumele studentului {0} : ", idStudent);
                        //string prenume = Console.ReadLine();
                        produs = new Produs(idProdus, nume);
                        nrProduse++;

                        break;
                    case "A":
                        string infoProdus = produs.Info();
                        Console.WriteLine("Produsul {0}", infoProdus);

                        break;
                    case "F":
                        Produs[] produse = adminProduse.GetProduse(out nrProduse);
                        AfisareProduse(produse, nrProduse);

                        break;
                    case "S":
                        idProdus = nrProduse + 1;
                        nrProduse++;
                        produs = new Produs(idProdus, "Ioana");
                        //adaugare produs in fisier
                        adminProduse.AddProdus(produs);

                        break;
                    case "X":

                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");

                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        public static void AfisareProduse(Produs[] produse, int nrProduse)
        {
            Console.WriteLine("Produsele sunt:");
            for (int contor = 0; contor < nrProduse; contor++)
            {
                string infoProdus = string.Format("Produsul cu id-ul #{0} are numele: {1} ",
                   produse[contor].GetIdProdus(),
                   produse[contor].GetNume() ?? " NECUNOSCUT ");

                Console.WriteLine(infoProdus);
            }
        }
    }
}
