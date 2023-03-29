using LibrarieModele;
using System.IO;

namespace NivelStocareDate
{
    public class AdministrareProduse_FisierText
    {
        private const int NR_MAX_PRODUSE = 50;
        private string evidenta_studenti;

        public AdministrareProduse_FisierText(string evidenta_studenti)
        {
            this.evidenta_studenti = evidenta_studenti;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(evidenta_studenti, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddProdus(Produs produs)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(evidenta_studenti, true))
            {
                streamWriterFisierText.WriteLine(produs.ConversieLaSir_PentruFisier());
            }
        }

        public Produs[] GetProduse(out int nrProduse)
        {
            Produs[] produse = new Produs[NR_MAX_PRODUSE];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(evidenta_studenti))
            {
                string linieFisier;
                nrProduse = 0;

                // citeste cate o linie si creaza un obiect de tip Produs
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    produse[nrProduse++] = new Produs(linieFisier);
                }
            }

            return produse;
        }
    }
}