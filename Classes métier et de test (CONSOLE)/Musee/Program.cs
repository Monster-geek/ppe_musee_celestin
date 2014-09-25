using System;

using METIER;

namespace TEST
{
    //---------------
    // Classe de TEST
    //---------------
    class Program
    {
        static void Main(string[] args)
        {
            // Des artistes
            Artiste monet = new Artiste("Monet", "Francaise");
            Artiste manet = new Artiste("Manet", "Francaise");
            Artiste vangogh = new Artiste("Van Gogh", "Neelandaise");

            // Des oeuvres
            Oeuvre o1 = new Oeuvre("Le Déjeuner sur l'herbe", 500000);
            Oeuvre o2 = new Oeuvre("Au bord de l'eau", 350000);
            Oeuvre o3 = new Oeuvre("La Partie de croquet", 250000);
            Oeuvre o4 = new Oeuvre("Tournesols dans un vase", 1000000);
            Oeuvre o5 = new Oeuvre("Champ de ble avec cypres", 100000);
            Oeuvre o6 = new Oeuvre("Les Paveurs", 275000);

            // Des salles
            Salle francaise = new Salle("Francaise", 10000000);
            Salle neerlandaise = new Salle("Neerlandaise", 5000000);

            // Un musée
            Musee monMusee = new Musee("Musee des Celestins - VICHY");

            // Ajouter des Artistes
            monMusee.CreerArtiste(monet);
            monMusee.CreerArtiste(manet);
            monMusee.CreerArtiste(vangogh);

            // Ajouter des Salles
            monMusee.CreerSalle(francaise);
            monMusee.CreerSalle(neerlandaise);

            // Ajouter des Oeuvres
            monMusee.CreerOeuvre(o1, monet, monMusee.GetSalle(0));
            monMusee.CreerOeuvre(o2, monet, monMusee.GetSalle(0));
            monMusee.CreerOeuvre(o3, manet, monMusee.GetSalle(0));
            monMusee.CreerOeuvre(o4, vangogh, monMusee.GetSalle(1));
            monMusee.CreerOeuvre(o5, vangogh, monMusee.GetSalle(1));
            monMusee.CreerOeuvre(o6, vangogh, monMusee.GetSalle(1));

            // Afficher le musée
            monMusee.AfficherMusee();

            Console.ReadKey();
        }
    }
}
