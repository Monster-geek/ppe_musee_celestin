using System;

// Lien vers la classe TECHNIQUE
using TECHNIQUE;

namespace TEST
{
    // Classe de TEST
    class MainClass
	{
		public static void Main(string[] args)
		{
            // Instanciation d'un objet de la classe technique 'Donnees'
            Donnees mesDonnees = new Donnees("DSNmabd");

            try
            {
                //-----------------------------------------
                // Connexion, puis récupération du résultat
                //-----------------------------------------
                mesDonnees.Connexion();

                //----------------
                // Requêtes SELECT
                //----------------

                string texteSQL = "SELECT CONCAT(fournisseur.numero, ', ', fournisseur.nom, ', ', prenom) AS FOURNISSEUR,";
                texteSQL += "CONCAT(articles.nom, ', ', prix) AS ARTICLE,";
                texteSQL += "CONCAT('Actuel : ', stockactuel, ' Min: ', stockminimum) AS STOCK";
                texteSQL += " FROM fournisseur, articles";
                texteSQL += " WHERE fournisseur.numero = articles.numero";
                texteSQL += " ORDER BY fournisseur.nom, articles.nom";
                Console.WriteLine(mesDonnees.ExecuterSQL(texteSQL, true, "Liste des produits par fournisseurs"));

                Console.ReadKey();
                Console.Clear();

                texteSQL = "SELECT COUNT(*) AS NOMBRE FROM articles";
                Console.WriteLine(mesDonnees.ExecuterSQL(texteSQL, true, "Nombre d'articles"));

                Console.ReadKey();
                Console.Clear();

                //-------
                // UPDATE
                //-------
                texteSQL = "UPDATE articles SET stockminimum=15 WHERE code='b500'";
                Console.WriteLine(mesDonnees.ExecuterSQL(texteSQL, false, "MAJ du stock de l'article 'b500' avec 15 unités"));

                Console.ReadKey();
                Console.Clear();

                //-----------------------
                // Infos sur la connexion
                //-----------------------
                Console.WriteLine(mesDonnees.InfosSurConnexion());
            }
            catch (Exception ex)
                { Console.WriteLine(ex.Message); } 
		    finally
                { mesDonnees.Fermeture(); } // Dans tous les cas on ferme tout !
	

            Console.ReadKey();
		}
	}
}
