DROP TABLE Adresse CASCADE CONSTRAINTS;
DROP TABLE Mitglied CASCADE CONSTRAINTS;
DROP TABLE Funktion CASCADE CONSTRAINTS;
DROP TABLE Befugnis CASCADE CONSTRAINTS;
DROP TABLE Leistung CASCADE CONSTRAINTS;


CREATE TABLE Adresse(
	PLZ INTEGER,
	Ort VARCHAR2(50),
	CONSTRAINT pk_PLZ PRIMARY KEY(PLZ)
);


CREATE TABLE Mitglied(
	idM INTEGER,
	Name VARCHAR2(50),
	PLZ INTEGER,
	Bürgerflag INTEGER,
	Beamterflag INTEGER,
	CONSTRAINT pk_idM PRIMARY KEY(idM),
	CONSTRAINT fk_PLZ FOREIGN KEY(PLZ) REFERENCES Adresse(PLZ),
	Constraint ck_BurgerFlags check (Bürgerflag = 1 or Bürgerflag = 0),
	Constraint ck_BeamterFlags check (Beamterflag = 1 or Beamterflag = 0)
);

CREATE TABLE Funktion(
	idF INTEGER,
	Beschreibung VARCHAR2(50),
	CONSTRAINT pk_idF PRIMARY KEY(idF)
);

CREATE TABLE Befugnis(
	idM INTEGER,
	idF INTEGER,
	CONSTRAINT pk_B PRIMARY KEY(idM,idF),
	CONSTRAINT fk_idF FOREIGN KEY(idF) REFERENCES Funktion(idF),
	CONSTRAINT fk_idM FOREIGN KEY(idM) REFERENCES Mitglied(idM)
);

CREATE TABLE Leistung(
	idBurger INTEGER,
	idF INTEGER,
	idBeamter INTEGER,
	Lbeschr VARCHAR2(50),
	Datum DATE,
	CONSTRAINT pk_Leistung PRIMARY KEY(idBurger,Lbeschr,Datum),
	CONSTRAINT fk_idF1 FOREIGN KEY (idF) REFERENCES Funktion(idF),
	CONSTRAINT fk_idBeamter FOREIGN KEY (idBeamter) REFERENCES MITGLIED(idM),
	CONSTRAINT fk_idBurger FOREIGN KEY(idBurger) REFERENCES Mitglied(idM)
);





INSERT INTO Adresse VALUES(9220, 'Velden');
INSERT INTO Adresse VALUES(9500, 'Villach');
INSERT INTO Mitglied VALUES(1, 'Franz Mayer', 9220, 1, 0);
INSERT INTO Mitglied VALUES(2, 'Hansi Mayer', 9500, 1, 1);
INSERT INTO Mitglied VALUES(3, 'Franz Wurst', 9220, 0, 1);
INSERT INTO Mitglied VALUES(4, 'Sebastian Straus', 9220, 1, 1);
INSERT INTO Mitglied VALUES(5, 'Klaus Kleber', 9220, 1, 1);
INSERT INTO Mitglied VALUES(6, 'Hans Klaus', 9220, 1, 0);
INSERT INTO Mitglied VALUES(7, 'A. Sterix', 9220, 1, 0);
INSERT INTO Funktion VALUES(1, 'Funktion 1');
INSERT INTO Funktion VALUES(2, 'Funktion 2');



INSERT INTO Befugnis VALUES(1, 1);
INSERT INTO Befugnis VALUES(1, 2);
INSERT INTO Leistung VALUES(1, 1, 2, 'Leistung 1', to_date('05.04.2017', 'DD.MM.YYYY'));
INSERT INTO Leistung VALUES(7, 1, 2, 'Leistung 1', to_date('05.05.2014', 'DD.MM.YYYY'));
INSERT INTO Leistung VALUES(7, 2, 2, 'Leistung 1', to_date('06.05.2014', 'DD.MM.YYYY'));




select * from BEFUGNIS;
select * from LEISTUNG;
select * from ADRESSE;
select * from MITGLIED;
select * from FUNKTION;


