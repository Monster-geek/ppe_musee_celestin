using System.Data.Odbc; // Sources de données ODBC

namespace TECHNIQUE
{
    //---------------------------------------------------------------------
    //                          Mode CONNECTE
    // Dans une application utilisant une base de données en mode connecté, 
    // on trouvera généralement les étapes suivantes :
    //      1. Connexion à la base de données.
    //      2. Émissions de requêtes SQL vers la base.
    //      3. Réception et traitement des résultats de ces requêtes.
    //      4. Fermeture de la connexion.
    //---------------------------------------------------------------------

    // Classe TECHNIQUE d'accès aux données d'une source ODBC
    class Donnees
    {
        // Attributs
        private string dsn;                 // Source de données DSN
        private OdbcConnection connexion;   // Objet CONNEXION
        private OdbcCommand commande;       // Objet COMMANDE
        private OdbcDataReader reader; 	    // Objet LECTEUR de données

        // Constructeur - Paramètre : nom de la source ODBC
        public Donnees(string source)
        {
            this.dsn = source;
            this.connexion = null;
            this.commande = null;
            this.reader = null;
        }

        // Connexion à la source de données
        public void Connexion()
        {
            // Chaîne de connexion, puis instanciation
            // de l'objet connexion
            string chaineDeConnexion = "DSN=" + dsn + ";";
            connexion = new OdbcConnection(chaineDeConnexion);
            connexion.Open();
        }

        // Exécute une requête SQL de type SELECT passée en paramètre.
        // Une valeur booléenne indique s'il s'agit d'un SELECT
        public string ExecuterSQL(string requete, bool select, string message = "")
        {
            string aRetourner = "*** Résultat de la requête ***\n\n";
            if (message.Length != 0)
                aRetourner += ("\t" + message + "\n\n");

            // a. Objet COMMANDE construit à partir de la requête et de la CONNEXION
            this.commande = new OdbcCommand(requete, this.connexion);

            // b. On exécute la requête SQL à partir de l’objet COMMANDE. 
            // --> Si SELECT, l'objet LECTEUR contiendra le résultat de la requête
            // --> Si UPDATE, DELETE... on exécute la requête et on affiche le nombre
            //     de tuples affectés.
            if (select)
            {
                this.reader = commande.ExecuteReader();
                if (this.reader != null) // Si on a quelque chose à lire !
                {
                    // c. Formatage de la liste des colonnes
                    aRetourner += "Liste des CHAMPS : ";
                    for (int i = 0; i < this.reader.FieldCount - 1; i++)
                        aRetourner += (this.reader.GetName(i) + "\t");

                    aRetourner += this.reader.GetName(this.reader.FieldCount - 1);
                    aRetourner += "\n\n";

                    // d) Formatage des données extraites
                    // A chaque appel de 'Read()', on se positionne sur la ligne suivante
                    aRetourner += "RESULTAT : \n";
                    while (this.reader.Read())
                    {
                        for (int i = 0; i < this.reader.FieldCount; i++)
                            aRetourner += (this.reader[i].ToString() + "\t");

                        aRetourner += System.Environment.NewLine;
                    }
                }

            }
            else
                // e) MAJ directe (INSERT, UPDATE, DELETE, DROP/CREATE TABLE...
                aRetourner += string.Format("Nombre de lignes modifiees : " + this.commande.ExecuteNonQuery());

            return aRetourner;
        }

        // Fournit des informations sur la connexion
        public string InfosSurConnexion()
        {
            string aRetourner = "*** Informations sur la connexion à la BD ***\n";

            aRetourner += string.Format("\tChaîne de connexion: {0}\n\tTimeout : {1}\n\tBD: {2}\n\tSource: {3}\n\tDriver: {4}\n",
                            this.connexion.ConnectionString, this.connexion.ConnectionTimeout,
                            this.connexion.Database, this.connexion.DataSource, this.connexion.Driver);
            return aRetourner;
        }

        // Fermeture de la connexion
        public void Fermeture()
        {
            if (reader != null)
                reader.Close();     // LECTEUR
            if (connexion != null)
                connexion.Close();  // CONNEXION	
        }
    }
    
}
