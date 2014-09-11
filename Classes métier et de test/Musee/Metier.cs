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
        { nomArtiste = nom; nationalite = nat; }

        // Accesseurs
        public string GetNomArtiste()
        { return nomArtiste; }
        public string GetNationalité()
        { return nationalite; }
        public void SetNom(string nom)
        { nomArtiste = nom; }
        public void SetNationalité(string nat)
        { nationalite = nat; }

        // Affiche le nom et la nationalité de l’artiste
        public void AfficheArtiste()
        { }
    }

    //--------------
    // Classe OEUVRE
    //--------------
    public class Oeuvre
    {
        // Attributs
        private string nomOeuvre;
        private float prixOeuvre;

        // Constructeur. 
        public Oeuvre(string nom, float prix)
        { nomOeuvre = nom; prixOeuvre = prix; }

        // Constructeur surchargé
        public Oeuvre(string nom, float prix, Artiste art)
        { }

        // Accesseurs
        public string GetNomOeuvre()
        { return nomOeuvre; }
        public float GetPrixOeuvre()
        { return prixOeuvre; }
        public void SetNomOeuvre(string nom)
        { nomOeuvre = nom; }
        public void SetPrixOeuvre(float prix)
        { prixOeuvre = prix; }

        // Accesseurs sur l'artiste de l'oeuvre
        public Artiste GetArtiste()
        { return null; }
        public void SetArtiste(Artiste art)
        { }

        // Affiche les caratéristiques de l'oeuvre avec son artiste
        public void AffichageOeuvre()
        { }
    }

    //-------------
    // Classe SALLE
    //-------------
    public class Salle
    {
        // Attributs
        private string nomSalle;
        private float montantAssurance;

        // Constructeur
        public Salle(string nomSalle, float montant)
        {
            // 'this' fait référence à l'objet "courant"; cela permet de lever
            // l'ambiguité entre les attributs et les paramètres du constructeur.
            this.nomSalle = nomSalle;
            this.montantAssurance = montant;
        }

        // Accesseurs 
        public string GetNomSalle()
        { return nomSalle; }
        public float GetMontantAssurance()
        { return montantAssurance; }
        public void SetNomSalle(string nom)
        { this.nomSalle = nom; }
        public void SetMontantAssurance(float mtt)
        { this.montantAssurance = mtt; }

        // Retourne le nombre d'oeuvres
        public int GetNbOeuvres()
        { return 0; }

        // Retourne l’oeuvre dont le nom est passé en paramètre ou "null" sinon trouvée.
        public Oeuvre GetOeuvre(string nom)
        { return null; }

        // Retourne vrai si l'Oeuvre dont le nom est passé en paramètre existe dans la salle, faux sinon.
        public bool ExisteOeuvre(string nom)
        { return false; }

        // Retourne vrai si l’Oeuvre passée en paramètre existe dans la salle, faux sinon.
        public bool ExisteOeuvre(Oeuvre uneOeuvre)
        { return false; }

        // Ajoute une Oeuvre dans la salle, retourne vrai si l’ajout a eu lieu, faux si l'œuvre existe déjà.
        public bool AjouteOeuvre(Oeuvre uneOeuvre)
        { return false; }

        // Enlève une Oeuvre dans la salle, retourne vrai si le retrait a eu lieu, faux si l'œuvre n'existe pas.
        public bool RetireOeuvre(Oeuvre uneOeuvre)
        { return false; }

        // Retourne la valeur totale des tableaux stockés dans la salle
        public double ValeurSalle()
        { return 0; }

        // Retourne l’écart entre le montant de la valeur déclarée à l’assurance 
        // et la valeur des Oeuvres.
        public double Ecart()
        { return 0; }

        // Affiche les caractéristiques de la salle (nom et montant de l’assurance) 
        // et des œuvres avec artiste.
        public void AfficheOeuvresSalle()
        { }
    }

    //-------------
    // Classe MUSEE
    //-------------
    public class Musee
    {
        // Attributs
        private string monMusee;

        // Constructeur : création d'un musée
        public Musee(string nom)
        { }

        // Création d'une SALLE
        public void CreerSalle(Salle s)
        { }

        // Création d'un ARTISTE
        public void CreerArtiste(Artiste a)
        { }

        // Création d'une OEUVRE avec un ARTISTE et une SALLE
        public void CreerOeuvre(Oeuvre o, Artiste a, Salle s)
        { }

        // Accesseurs
        public Artiste GetArtiste(int i)
        { return null; }
        public Oeuvre GetOeuvre(int i)
        { return null; }
        public Salle GetSalle(int i)
        { return null; }

        // Affichage du MUSEE
        public void AfficherMusee()
        { }
    }
}
