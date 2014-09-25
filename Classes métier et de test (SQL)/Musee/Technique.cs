using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;

using METIER;

namespace TECHNIQUE
{
    class ODBC
    {
        private string dsn;
        private OdbcConnection connexion;
        private OdbcCommand command;
        private OdbcDataReader reader;

        public ODBC(string source)
        {
            this.dsn = source;
            this.connexion = null;
            this.command = null;
            this.reader = null;
        }

        public void Open()
        {
            string chaineCo = "DSN=" + this.dsn + ";";
            this.connexion = new OdbcConnection(chaineCo);
            this.connexion.Open();
        }

        public void Close()
        {
            if (this.reader != null)
                this.reader.Close();
            if (this.connexion != null)
                this.connexion.Close();
        }

        public List<string> Requeteur(string requet)
        {
            this.Open();

            List<string> listS = new List<string>();

            this.command = new OdbcCommand(requet, this.connexion);

            if (requet.Contains("SELECT"))
            {
                this.reader = this.command.ExecuteReader();

                if (this.reader != null)
                    while (this.reader.Read())
                        for (int i = 0; i < this.reader.FieldCount; i++)
                            listS.Add(this.reader[i].ToString());
            }
            else
                listS.Add("Nombre de lignes modifiees : " + this.command.ExecuteNonQuery());

            this.Close();

            return listS;
        }


        public List<Artiste> GetArtiste()
        {
            List<Artiste> listA = new List<Artiste>();
            List<string> listStr = new List<string>();

            string requet = "SELECT nomArtiste, nationalite FROM Artiste ORDER BY nomArtiste;";
            listStr = this.Requeteur(requet);

            int i = 0;
            while (i < listStr.Count)
            {
                listA.Add(new Artiste(listStr[i], listStr[i + 1]));
                i += 2;
            }

            return listA;
        }

        public List<Oeuvre> GetOeuvre()
        {
            List<Oeuvre> listO = new List<Oeuvre>();
            List<Artiste> listA = new List<Artiste>();
            List<string> listStr = new List<string>();

            listA = this.GetArtiste();

            string requet = "SELECT nomOeuvre, prixOeuvre, nomArtisteOeuvre, nomsalleOeuvre FROM Oeuvre ORDER BY nomOeuvre;";
            listStr = this.Requeteur(requet);

            int i = 0;
            while (i < listStr.Count)
            {
                string nom = listStr[i];
                float prix = float.Parse(listStr[i + 1]);
                Artiste a = new Artiste("", "");

                for (int j = 0; j < listA.Count; j++)
                {
                    if (listStr[i + 2] == listA[j].GetNomArtiste())
                        a = new Artiste(listA[j].GetNomArtiste(), listA[j].GetNationalité());
                }

                Oeuvre o = new Oeuvre(nom, prix, a);
                listO.Add(o);
                i += 4;
            }


            return listO;
        }

        public List<Salle> GetSalle()
        {
            List<Oeuvre> listO = new List<Oeuvre>();
            List<Salle> listS = new List<Salle>();
            List<string> listStr = new List<string>();

            listO = this.GetOeuvre();

            string requet = "SELECT nomSalle, montantAssurance, monMuseeSalle FROM Salle ORDER BY nomSalle;";
            listStr = this.Requeteur(requet);

            int i = 0;
            while (i < listStr.Count)
            {
                string nom = listStr[i];
                float mont = float.Parse(listStr[i + 1]);
                Salle s = new Salle(nom, mont);

                for (int j = 0; j < listO.Count; j++)
                {
                    if (listO[j].GetArtiste().GetNationalité() == nom)
                        s.AjouteOeuvre(listO[j]);
                }

                listS.Add(s);
                i += 3;
            }

            return listS;
        }

        public Musee GetMusee()
        {
            List<string> listStr = new List<string>();
            List<Artiste> listA = new List<Artiste>();
            List<Oeuvre> listO = new List<Oeuvre>();
            List<Salle> listS = new List<Salle>();

            listA = this.GetArtiste();
            listO = this.GetOeuvre();
            listS = this.GetSalle();


            string requet = "SELECT monMusee FROM Musee;";
            listStr = this.Requeteur(requet);

            Musee m = new Musee(listStr[0]);

            for (int i = 0; i < listA.Count; i++)
            {
                m.CreerArtiste(listA[i]);
            }

            for (int i = 0; i < listS.Count; i++)
            {
                m.CreerSalle(listS[i]);
            }

            for (int i = 0; i < listO.Count; i++)
            {
                Salle s = new Salle("", 0);
                for (int j = 0; j < listS.Count; j++)
                {

                    if (listO[i].GetArtiste().GetNationalité() == listS[j].GetNomSalle())
                        s = listS[j];

                }

                m.CreerOeuvre(listO[i], listO[i].GetArtiste(), s);
            }


            return m;
        }

    }
}
