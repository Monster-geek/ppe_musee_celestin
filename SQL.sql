DROP DATABASE IF EXISTS DatMusee;
CREATE DATABASE DatMusee
DEFAULT CHARACTER SET ascii
COLLATE ascii_general_ci;

USE DatMusee;

DROP TABLE IF EXISTS Artiste;
DROP TABLE IF EXISTS Salle;
DROP TABLE IF EXISTS Oeuvre;
DROP TABLE IF EXISTS Musee;

CREATE TABLE Artiste(
    nomArtiste VARCHAR(50) NOT NULL,
    nationalite VARCHAR(50) NOT NULL,
    CONSTRAINT pk_Artiste PRIMARY KEY(nomArtiste)
);

CREATE TABLE Oeuvre(
    nomOeuvre VARCHAR(50) NOT NULL,
    prixOeuvre INTEGER(10) NOT NULL,
    nomArtisteOeuvre VARCHAR(50) NOT NULL,
    nomsalleOeuvre VARCHAR(50) NOT NULL,
    CONSTRAINT pk_Oeuvre PRIMARY KEY (nomOeuvre),
    CONSTRAINT fk_Artiste FOREIGN KEY (nomArtisteOeuvre) REFERENCES Artiste(nomArtiste) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Salle(
    nomSalle VARCHAR(50) NOT NULL,
    montantAssurance INTEGER(10) NOT NULL,
    monMuseeSalle VARCHAR(50) NOT NULL,
    CONSTRAINT pk_Salle PRIMARY KEY (nomSalle)
);

CREATE TABLE Musee(
    monMusee VARCHAR(50) NOT NULL,
    CONSTRAINT pk_Musee PRIMARY KEY (monMusee)
);

INSERT INTO Artiste VALUES("Monet", "Francaise");
INSERT INTO Artiste VALUES("Manet", "Francaise");
INSERT INTO Artiste VALUES("Van Gogh", "Neelandaise");

INSERT INTO Oeuvre VALUES("Le Dejeuner sur l'herbe", 500000, "Monet", "Francaise");
INSERT INTO Oeuvre VALUES("Au bord de l'eau", 350000, "Monet", "Francaise");
INSERT INTO Oeuvre VALUES("La Partie de croquet", 250000, "Manet", "Francaise");
INSERT INTO Oeuvre VALUES("Tournesols dans un vase", 1000000, "Van Gogh", "Neerlandaise");
INSERT INTO Oeuvre VALUES("Champ de ble avec cypres", 100000, "Van Gogh", "Neerlandaise");
INSERT INTO Oeuvre VALUES("Les Paveurs", 275000, "Van Gogh", "Neerlandaise");

INSERT INTO Salle VALUES("Francaise", 10000000, "Musee des Celestins - VICHY");
INSERT INTO Salle VALUES("Neerlandaise", 5000000, "Musee des Celestins - VICHY");

INSERT INTO Musee VALUES("Musee des Celestins - VICHY");

ALTER TABLE Oeuvre ADD CONSTRAINT fk_Salle FOREIGN KEY (nomsalleOeuvre) REFERENCES Salle(nomSalle) ON UPDATE CASCADE ON DELETE CASCADE;
ALTER TABLE Salle ADD CONSTRAINT fk_ContientSalle FOREIGN KEY (monMuseeSalle) REFERENCES Musee(monMusee) ON UPDATE CASCADE ON DELETE CASCADE;


DESC Musee;
DESC Salle;
DESC Oeuvre;
DESC Artiste;

SELECT * FROM Musee;
SELECT * FROM Salle;
SELECT * FROM Oeuvre;
SELECT * FROM Artiste;




