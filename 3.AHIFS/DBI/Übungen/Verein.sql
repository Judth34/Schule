DROP TABLE Verein CASCADE CONSTRAINTS;
DROP TABLE Laufbahn CASCADE CONSTRAINTS;
DROP TABLE Lizenz CASCADE CONSTRAINTS;
DROP TABLE Teammitglied CASCADE CONSTRAINTS;


create table Verein(
id integer,
name varchar2(500),

CONSTRAINT pk_Verein PRIMARY KEY(id)
);


create table Teammitglied(
id integer,
name varchar(200),
gebdtm date,
CONSTRAINT pk_Teammitglied PRIMARY KEY(id)

);


create table Laufbahn(
von date,
bis date,
vid integer,
tmid integer,
funktion varchar2(200),
aktuell boolean,

CONSTRAINT fk_Laufbahn_tmid FOREIGN KEY (tmid) REFERENCES Teammitglied(id),
CONSTRAINT fk_Laufbahn_vid FOREIGN KEY (vid) REFERENCES Verein(id)
);


create table Lizenz(
id integer,
tmid integer,
von date,
bis date,
art varchar2(200),

CONSTRAINT pk_Lizenz PRIMARY KEY(id),
CONSTRAINT fk_Lizenz_tmid FOREIGN KEY (tmid) REFERENCES Teammitglied(id)
);

INSERT INTO VEREIN VALUES(1, 'Villach');
INSERT INTO TEAMMITGLIED VALUES(1, 'Hansi', '02.02.1998');
INSERT INTO TEAMMITGLIED VALUES(2, 'Peter', '02.02.1997');
INSERT INTO TEAMMITGLIED VALUES(3, 'Franz', '02.02.1999');
INSERT INTO TEAMMITGLIED VALUES(4, 'Heinz', '02.02.2000');
INSERT INTO TEAMMITGLIED VALUES(5, 'Lord Baldemord', '02.02.1920');

INSERT INTO LAUFBAHN VALUES('10.10.2010', null, 1, 1, 'Stürmer', true);
INSERT INTO LAUFBAHN VALUES('10.10.2003', null, 1, 2, 'Tormann', true);
INSERT INTO LAUFBAHN VALUES('10.10.2004', null, 1, 3, 'Verteidiger', true);
INSERT INTO LAUFBAHN VALUES('10.10.1015', null, 1, 4, 'Mittelfeldspieler', true);
INSERT INTO LAUFBAHN VALUES('10.10.2010', null, 1, 5, 'Trainer', true);


select * from VEREIN;
select * from LAUFBAHN;
select * from TEAMMITGLIED;
select * from LIZENZ;


select * from teammitglied 
inner join laufbahn on tid = id
where laufbahn.position like 'trainer' or laufbahn.position like 'Betreuer' or laufbahn.position like 'Masseur';

select * from teammitglied 
inner join laufbahn on tid = id
where laufbahn.position like 'trainer' or laufbahn.position like 'Betreuer' or laufbahn.position like 'Masseur';


select name, gebdtm, 

