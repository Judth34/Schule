DROP TABLE Aufwandsentschaedigung CASCADE CONSTRAINTS;
DROP TABLE Helfer CASCADE CONSTRAINTS;
DROP TABLE Teilnahme CASCADE CONSTRAINTS;
DROP TABLE Team CASCADE CONSTRAINTS;
DROP TABLE Einsatz CASCADE CONSTRAINTS;



CREATE TABLE Aufwandsentschaedigung(
	Aid INTEGER,
	datum VARCHAR2(50),
	betrag INTEGER,
	Hid INTEGER,
	
	CONSTRAINT pk_Aufwandsentschaedigung PRIMARY KEY(Aid)
);

CREATE TABLE Helfer(
	Hid INTEGER,
	HName VARCHAR2(50),
	Geburtsdatum VARCHAR2(50),
	Aid INTEGER,
	Tid INTEGER,
	
	CONSTRAINT pk_Helfer PRIMARY KEY(Hid),
	CONSTRAINT fk_Helfer_Aufwandsentsch FOREIGN KEY (Aid) REFERENCES Aufwandsentschaedigung (Aid)

);

CREATE TABLE Einsatz(
	Eid INTEGER,
	Datum VARCHAR2(50),
	Beschreibung VARCHAR2(50),
	
	CONSTRAINT pk_Einsatz PRIMARY KEY(Eid)
);

CREATE TABLE Team(
	Tid INTEGER,
	TName VARCHAR2(50),
	LeiterId INTEGER,
	LeiterStvId INTEGER,

	CONSTRAINT pk_Team PRIMARY KEY(Tid),
	CONSTRAINT fk_Team_Leiter FOREIGN KEY(LeiterId) REFERENCES Helfer (Hid),
	CONSTRAINT fk_Team_LeiterStv FOREIGN KEY(LeiterStvId) REFERENCES Helfer (Hid),
	CONSTRAINT ck_Team_Leiter_LeiterStv CHECK (LeiterId != LeiterStvId)
);

CREATE TABLE Teilnahme(
	Tid INTEGER,
	Eid INTEGER,
	
	CONSTRAINT fk_nimmtTeil_Team FOREIGN KEY (Tid) REFERENCES Team(Tid),
	CONSTRAINT fk_nimmtTeil_Einsatz FOREIGN KEY (Eid) REFERENCES Einsatz(Eid)
);

ALTER TABLE Aufwandsentschaedigung ADD CONSTRAINT fk_Aufwandsentschaedigung_Helf FOREIGN KEY (Hid) REFERENCES Helfer (Hid);
ALTER TABLE Helfer ADD 	CONSTRAINT fk_Helfer_Team FOREIGN KEY (Tid) REFERENCES Team (Tid);




ALTER TABLE Aufwandsentschaedigung DISABLE CONSTRAINT fk_Aufwandsentschaedigung_Helf;
ALTER TABLE Helfer DISABLE CONSTRAINT fk_Helfer_Team;

INSERT INTO Aufwandsentschaedigung VALUES (1, '07-12-2016', 7000, 1);
INSERT INTO Einsatz VALUES (1, '07-12-2016', 'Einsatz 1');
INSERT INTO Helfer VALUES (1,'Hansi', '07-12-2016', 1, 1);
INSERT INTO Helfer VALUES (2,'Peppe', '08-12-2016', 1, 1);
INSERT INTO Helfer VALUES (3,'Gerwin', '09-12-2016', 1, 1);
INSERT INTO Team VALUES (1, 'Team 1', 1, 2);
 
ALTER TABLE Aufwandsentschaedigung ENABLE CONSTRAINT fk_Aufwandsentschaedigung_Helf;
ALTER TABLE Helfer ENABLE CONSTRAINT fk_Helfer_Team;

INSERT INTO Teilnahme VALUES(1, 1);


select * from Einsatz;
select * from Helfer;
select * from Aufwandsentschaedigung;
select * from TEAM;
select * from TEILNAHME;