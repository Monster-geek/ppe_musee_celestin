using System;
using System.Collections.Generic;

namespace METIER
{
    //---------------
    // Classe ARTISTE
    //---------------
    public class Artiste
    {
        // Attributs 
        private string nomArtiste;
        private string nationalite;

        // Constructeur
        public Artiste(string nom, string nat)
        { this.nomArtiste = nom; this.nationalite = nat; }

        // Accesseurs
        public string GetNomArtiste()
        { return this.nomArtiste; }
        public string GetNationalité()
        { return this.nationalite; }
        public void SetNom(string nom)
        { this.nomArtiste = nom; }
        public void SetNationalité(string nat)
        { this.nationalite = nat; }

        // Affiche le nom et la nationalité de l’artiste
        public string AfficheArtiste()
        {
            string aAfficher = "";

            aAfficher += "[" + this.nomArtiste + ", " + this.nationalite + "]\n";

            return aAfficher;
        }
    }

    //--------------
    // Classe OEUVRE
    //--------------
    public class Oeuvre
    {
        // Attributs
        private string nomOeuvre;
        private float prixOeuvre;
        private Artiste artiste;

        // Constructeur. 
        public Oeuvre(string nom, float prix)
        { this.nomOeuvre = nom; this.prixOeuvre = prix; }

        // Constructeur surchargé
        public Oeuvre(string nom, float prix, Artiste art)
        {
            this.nomOeuvre = nom;
            this.prixOeuvre = prix;
            this.artiste = new Artiste(art.GetNomArtiste(), art.GetNationalité());
        }

        // Accesseurs
        public string GetNomOeuvre()
        { return this.nomOeuvre; }
        public float GetPrixOeuvre()
        { return this.prixOeuvre; }
        public void SetNomOeuvre(string nom)
        { this.nomOeuvre = nom; }
        public void SetPrixOeuvre(float prix)
        { this.prixOeuvre = prix; }

        // Accesseurs sur l'artiste de l'oeuvre
        public Artiste GetArtiste()
        { return this.artiste; }
        public void SetArtiste(Artiste art)
        { this.artiste = new Artiste(art.GetNomArtiste(), art.GetNationalité()); }

        // Affiche les caratéristiques de l'oeuvre avec son artiste
        public string AffichageOeuvre()
        {
            string aAfficher = "";

            aAfficher += "\t[" + this.nomOeuvre + ", " + this.prixOeuvre + " euros => " + this.artiste.GetNomArtiste() + ", " + this.artiste.GetNationalité() + "]\n";

            return aAfficher;
        }
    }

    //-------------
    // Classe SALLE
    //-------------
    public class Salle
    {
        // Attributs
        private string nomSalle;
        private float montantAssurance;
        private int nbOeuvres;
        private List<Oeuvre> listOeuvre;

        // Constructeur
        public Salle(string nomSalle, float montant)
        {
            // 'this' fait référence à l'objet "courant"; cela permet de lever
            // l'ambiguité entre les attributs et les paramètres du constructeur.
            this.nomSalle = nomSalle;
            this.montantAssurance = montant;
            this.nbOeuvres = 0;
            this.listOeuvre = new List<Oeuvre>();
        }

        // Accesseurs 
        public string GetNomSalle()
        { return this.nomSalle; }
        public float GetMontantAssurance()
        { return this.montantAssurance; }
        public void SetNomSalle(string nom)
        { this.nomSalle = nom; }
        public void SetMontantAssurance(float mtt)
        { this.montantAssurance = mtt; }

        // Retourne le nombre d'oeuvres
        public int GetNbOeuvres()
        { return this.nbOeuvres; }

        // Retourne l’oeuvre dont le nom est passé en paramètre ou "null" sinon trouvée.
        public Oeuvre GetOeuvre(string nom)
        {

            for (int i = 0; i < this.listOeuvre.Count; i++)
            {
                if (nom == this.listOeuvre[i].GetNomOeuvre())
                {
                    return this.listOeuvre[i];
                }
            }

            return null;
        }

        // Retourne vrai si l'Oeuvre dont le nom est passé en paramètre existe dans la salle, faux sinon.
        public bool ExisteOeuvre(string nom)
        {
            if (this.GetOeuvre(nom) != null)
                return true;
            else
                return false;

        }

        // Retourne vrai si l’Oeuvre passée en paramètre existe dans la salle, faux sinon.
        public bool ExisteOeuvre(Oeuvre uneOeuvre)
        {
            if (this.ExisteOeuvre(uneOeuvre.GetNomOeuvre()) == true)
                return true;
            else
                return false;
        }

        // Ajoute une Oeuvre dans la salle, retourne vrai si l’ajout a eu lieu, faux si l'œuvre existe déjà.
        public bool AjouteOeuvre(Oeuvre uneOeuvre)
        { 
            if(this.ExisteOeuvre(uneOeuvre) == true)
                return false;

            this.listOeuvre.Add(new Oeuvre(uneOeuvre.GetNomOeuvre(), uneOeuvre.GetPrixOeuvre(), uneOeuvre.GetArtiste()));
            this.nbOeuvres++;

            return true;
        }

        // Enlève une Oeuvre dans la salle, retourne vrai si le retrait a eu lieu, faux si l'œuvre n'existe pas.
        public bool RetireOeuvre(Oeuvre uneOeuvre)
        {
            if (this.ExisteOeuvre(uneOeuvre) == false)
                return false;

            bool b = this.listOeuvre.Remove(uneOeuvre);
            this.nbOeuvres--;

            return true;

        }

        // Retourne la valeur totale des tableaux stockés dans la salle
        public double ValeurSalle()
        {
            double valeur = 0;

            for (int i = 0; i < this.listOeuvre.Count; i++)
            {
                valeur += this.listOeuvre[i].GetPrixOeuvre();
            }

            return valeur;
        }

        // Retourne l’écart entre le montant de la valeur déclarée à l’assurance 
        // et la valeur des Oeuvres.
        public double Ecart()
        {
            double ecart = 0;

            ecart = this.montantAssurance - this.ValeurSalle();

            return ecart;
        }

        // Affiche les caractéristiques de la salle (nom et montant de l’assurance) 
        // et des œuvres avec artiste.
        public string AfficheOeuvresSalle()
        {
            string aAfficher = "";

            if (this.listOeuvre.Count <= 0)
                aAfficher = "Il n'y a aucune oeuvre dans cette salle";
            else
            {
                aAfficher += "SALLE : " + this.nomSalle + " Montant d'assurance : " + this.montantAssurance + "\n";
                aAfficher += "Il y a " + this.nbOeuvres + " oeuvre(s)\n";

                for (int i = 0; i < this.listOeuvre.Count; i++)
                {
                    aAfficher += "\t[" + this.listOeuvre[i].GetNomOeuvre() + ", " + this.listOeuvre[i].GetPrixOeuvre() + " euros => " + this.listOeuvre[i].GetArtiste().GetNomArtiste() + ", " + this.listOeuvre[i].GetArtiste().GetNationalité() + "]\n";
                }

                aAfficher += "\n\tValeur : " + this.ValeurSalle() + " euros. Ecart : " + this.Ecart() + " euros\n\n";
            }

            return aAfficher;

        }
    }

    //-------------
    // Classe MUSEE
    //-------------
    public class Musee
    {
        // Attributs
        private string monMusee;
        private List<Salle> listSalle;
        private List<Artiste> listArtiste;
        private List<Oeuvre> listOeuvre;

        // Constructeur : création d'un musée
        public Musee(string nom)
        {
            if (nom == "")
                this.monMusee = "Inconnu";
            else
                this.monMusee = nom;
            listSalle = new List<Salle>();
            listArtiste = new List<Artiste>();
            listOeuvre = new List<Oeuvre>();
        }

        // Création d'une SALLE
        public string CreerSalle(Salle s)
        {
            if (this.listSalle.Contains(s) == true)
                return "Cette salle existe déjà !!";
            else
                this.listSalle.Add(new Salle(s.GetNomSalle(), s.GetMontantAssurance()));
            return "";
        }

        // Création d'un ARTISTE
        public string CreerArtiste(Artiste a)
        {
            if (this.listArtiste.Contains(a) == true)
                return "Cette artiste existe déjà !!";
            else
                this.listArtiste.Add(new Artiste(a.GetNomArtiste(), a.GetNationalité()));

            return "";
        }

        // Création d'une OEUVRE avec un ARTISTE et une SALLE
        public string CreerOeuvre(Oeuvre o, Artiste a, Salle s)
        {
            if (this.listOeuvre.Contains(o) == true)
                return "Cette Oeuvre est déjà présente dans la salle";
            else
            {
                Oeuvre oo = new Oeuvre(o.GetNomOeuvre(), o.GetPrixOeuvre(), a);
                this.listOeuvre.Add(oo);
                
                for(int i = 0; i < listSalle.Count; i++)
                {
                    if(this.listSalle[i].GetNomSalle() == s.GetNomSalle())
                    {
                        this.listSalle[i].AjouteOeuvre(oo);
                    }
                }
            }
            return "";
        }

        // Accesseurs
        public Artiste GetArtiste(int i)
        { return this.listArtiste[i]; }
        public Oeuvre GetOeuvre(int i)
        { return this.listOeuvre[i]; }
        public Salle GetSalle(int i)
        { return this.listSalle[i]; }

        // Affichage du MUSEE
        public string AfficherMusee()
        {
            string aAfficher = "";

            aAfficher += "*******************************\n";
            aAfficher += this.monMusee + "\n";
            aAfficher += "*******************************\n";
            aAfficher += "\n\n";

            aAfficher += "Liste des ARTISTES\n";

            for (int i = 0; i < this.listArtiste.Count; i++)
            {
                aAfficher += this.listArtiste[i].AfficheArtiste();
            }
            aAfficher += "\n\n";

            aAfficher += "Liste des OEUVRES\n";

            for (int i = 0; i < this.listOeuvre.Count; i++)
            {
                aAfficher += this.listOeuvre[i].AffichageOeuvre();
            }
            aAfficher += "\n\n";

            aAfficher += "Liste des SALLES\n";


            for (int i = 0; i < this.listSalle.Count; i++)
            {
                aAfficher += this.listSalle[i].AfficheOeuvresSalle();
            }


            return aAfficher;
        }
    }
}
