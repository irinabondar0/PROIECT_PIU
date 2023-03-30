using LibrarieModele;
using System.IO;

namespace NivelStocareDate
{
    public class AdministrareProduse_FisierText
    {
        private const int NR_MAX_PRODUSE = 35;
        private string numeFisier;


        public AdministrareProduse_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
   
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddProdus(Produs produs)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(produs.ConversieLaSir_PentruFisier());
            }
        }

        public Produs[] GetProduse(out int nrProduse)
        {
           Produs[] produse = new Produs[NR_MAX_PRODUSE];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrProduse = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    produse[nrProduse++] = new Produs(linieFisier);
                }
            }

            return produse;
        }
    }
}