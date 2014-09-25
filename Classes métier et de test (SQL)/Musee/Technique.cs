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
            listStr  = this.Requeteur(requet);

            int i = 0;
            while(i < listStr.Count)
            {
                listA.Add(new Artiste(listStr[i], listStr[i + 1]));
                i += 2;
            }

            return listA;
        }

        public List<Oeuvre> GetOeuvre()
        {
            List<Oeuvre> listO = new List<Oeuvre>();
            List<string> listStr = new List<string>();


            return listO;
        }

        public List<Salle> GetSalle()
        {
            List<Salle> listS = new List<Salle>();
            List<string> listStr = new List<string>();

            return listS;
        }

        public List<Musee> GetMusee()
        {
            List<Musee> listM = new List<Musee>();
            List<string> listStr = new List<string>();

            return listM;
        }

    }
}
