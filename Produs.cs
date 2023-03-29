﻿using System;

namespace LibrarieModele
{
    public class Produs
    {
        //constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int ID = 0;
        private const int NUME = 1;
        //private const int PRENUME = 2;

        private int idProdus; //identificator unic produs
        private string nume;
        //private string prenume;

        //contructor implicit
        public Produs()
        {
            nume = string.Empty;
        }

        //constructor cu parametri
        public Produs(int idProdus, string nume)
        {
            this.idProdus = idProdus;
            this.nume = nume;
            //this.prenume = prenume;
        }

        //constructor cu un singur parametru de tip string care reprezinta o linie dintr-un fisier text
        public Produs(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idProdus = Convert.ToInt32(dateFisier[ID]);
            nume = dateFisier[NUME];
            //prenume = dateFisier[PRENUME];
        }

        public string Info()
        {
            string info = string.Format("Id:{0} Nume:{1} ", 
                idProdus.ToString(),
                (nume ?? " NECUNOSCUT "));

            return info;
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectProdusPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idProdus.ToString(),
                (nume ?? " NECUNOSCUT "));

            return obiectProdusPentruFisier;
        }

        public int GetIdProdus()
        {
            return idProdus;
        }

        public string GetNume()
        {
            return nume;
        }

        /*public string GetPrenume()
        {
            return prenume;
        }*/
    }
}
