drop TABLE Messe CASCADE CONSTRAINTS;
drop TABLE nimmtTeil CASCADE CONSTRAINTS;
drop TABLE pfarrmitglied CASCADE CONSTRAINTS;
drop TABLE kirche CASCADE CONSTRAINTS;
drop TABLE dorf CASCADE CONSTRAINTS;

create TABLE Messe(
	me INTEGER,
	datum VARCHAR2(500),
	titel VARCHAR2(500),
	
	constraint pk_Messe PRIMARY KEY(me)
);

CREATE TABLE pfarrmitglied(
	mi INTEGER,
	name VARCHAR2(500),
	rang VARCHAR2(500),
	kName VARCHAR2(500),
	
	CONSTRAINTS pk_pfarrmitglied PRIMARY KEY(mi)	
);

create TABLE nimmtTeil(
	me INTEGER,
	mi INTEGER,
	funktion VARCHAR2(500), 
	
	CONSTRAINTS pk_nimmtTeil_me FOREIGN key(me) REFERENCES Messe(me),
	CONSTRAINTS pk_nimmtTeil_mi FOREIGN key(mi) REFERENCES pfarrmitglied (mi)
);



CREATE TABLE dorf(
	d INTEGER,
	name VARCHAR2(500),
	
	CONSTRAINTS pk_dorf PRIMARY KEY(d)
);

CREATE TABLE kirche(
	kName VARCHAR2(500),
	religion VARCHAR2(500),
	baujahr INTEGER,
	did INTEGER,
	pfarrer INTEGER,
	messner INTEGER,
	CONSTRAINTS pk_kirche PRIMARY KEY(kName),
	CONSTRAINTS fk_kirche_did FOREIGN KEY(did) REFERENCES dorf(d),
	CONSTRAINTS fk_kirche_pfarrer FOREIGN KEY(pfarrer) REFERENCES pfarrmitglied(mi),
	CONSTRAINTS fk_kirche_messner FOREIGN KEY(messner) REFERENCES pfarrmitglied(mi),
	CONSTRAINTS ck_pfarrer_messner CHECK (pfarrer != messner)
);

ALTER TABLE pfarrmitglied ADD CONSTRAINTS fk_pfarrmitglied_kName FOREIGN KEY(kName) REFERENCES kirche(kName);

ALTER TABLE  pfarrmitglied DISABLE CONSTRAINT fk_pfarrmitglied_kName;
INSERT INTO dorf VALUES(1, 'Dorf 1');
INSERT INTO Messe VALUES(1, '08-12-2016', 'Messe 1');
INSERT INTO Messe VALUES(2, '10-12-2016', 'Messe 2');
INSERT INTO pfarrmitglied VALUES(1, 'Heinz', 'Messner', 'Kirche 1');
INSERT INTO pfarrmitglied VALUES(2, 'Peppe', 'Pfarrer', 'Kirche 1');
INSERT INTO pfarrmitglied VALUES(3, 'Hans', 'Ministrant', 'Kirche 1');
INSERT INTO kirche VALUES('Kirche 1', 'röm-Kath', 2000, 1, 2, 1);
INSERT INTO nimmtTeil VALUES(1, 1, 'Messner');
INSERT INTO nimmtTeil VALUES(1, 2, 'Pfarrer');


ALTER TABLE  pfarrmitglied ENABLE CONSTRAINT fk_pfarrmitglied_kName;




select * from MESSE;
select * from pfarrmitglied;
select * from kirche;

