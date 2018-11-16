drop table teilstrecke cascade constraints;
drop table abschnitt cascade constraints;
drop table netz cascade constraints;

create table teilstrecke(
  id varchar2(10) primary key,
  xa integer,
  ya integer,
  xe integer,
  ye integer
);

create table abschnitt(
  id varchar2(10) primary key,
  bezeichunung varchar2(100)
);

create table netz(
  id_parent varchar2(10),
  id_child varchar2(10),
  constraint pk_netz primary key (id_teilstrecke, id_abschnitt)
);

insert into abschnitt values('A1', 'Ring West');
insert into abschnitt values('A1-1', 'Industrie West');
insert into abschnitt values('A1-2', 'EKZ-West');
insert into abschnitt values('A1-2-1', 'EKZ-1');
insert into abschnitt values('A1-2-2', 'EKZ-2');
insert into abschnitt values('A2', 'Ring Ost');
insert into abschnitt values('A2-1', 'Wohnwagensiedlung');
insert into abschnitt values('A2-2', 'Infrastruktur Bildung');
insert into abschnitt values('A2-2-1', 'Campus UNI');
insert into abschnitt values('A2-2-2', 'Schulen');
insert into abschnitt values('A2-2-2-1', 'Volksschule');
insert into abschnitt values('A2-2-2-2', 'NMS');

insert into teilstrecke values('G1', 900, 400, 900, 150);
insert into teilstrecke values('G2', 900, 150, 525, 200);
insert into teilstrecke values('G3', 525, 200, 500, 300);
insert into teilstrecke values('G4', 500, 300, 700, 480);
insert into teilstrecke values('G5', 525, 200, 250, 100);
insert into teilstrecke values('G6', 250, 100, 200, 350);
insert into teilstrecke values('G7', 200, 350, 375, 625);
insert into teilstrecke values('G8', 200, 350, 500, 300);

INSERT INTO TEILSTRECKE VALUES('G9', 900, 400, 1000, 650);
INSERT INTO TEILSTRECKE VALUES('G10', 1000, 650, 1000, 950);
INSERT INTO TEILSTRECKE VALUES('G11', 1000, 950, 700, 750);
INSERT INTO TEILSTRECKE VALUES('G12', 700, 480, 700, 750);
INSERT INTO TEILSTRECKE VALUES('G13', 1000, 950, 650, 1000);
INSERT INTO TEILSTRECKE VALUES('G14', 650, 1000, 350, 900);
INSERT INTO TEILSTRECKE VALUES('G15', 350, 900, 700, 750);
INSERT INTO TEILSTRECKE VALUES('G16', 350, 900, 100, 750);
INSERT INTO TEILSTRECKE VALUES('G17', 375, 625, 350, 900);

INSERT INTO TEILSTRECKE VALUES('B1', 900, 400, 700, 480);
INSERT INTO TEILSTRECKE VALUES('B2', 700, 480, 375, 625);
INSERT INTO TEILSTRECKE VALUES('B3', 375, 625, 100, 750);

insert into netz values('A1', 'A1-1');
insert into netz values('A1', 'A1-2');
insert into netz values('A1-2', 'A1-2-1');
insert into netz values('A1-2', 'A1-2-2');
insert into netz values('A2', 'A2-1');
insert into netz values('A2', 'A2-2');
insert into netz values('A2-2', 'A2-2-1');
insert into netz values('A2-2', 'A2-2-2');
insert into netz values('A2-2-2', 'A2-2-2-1');
insert into netz values('A2-2-2', 'A2-2-2-2');

insert into netz values('A1-1', 'G1');
insert into netz values('A1-1', 'G2');
insert into netz values('A1-1', 'G3');
insert into netz values('A1-1', 'G4');
insert into netz values('A1-1', 'B1');

insert into netz values('A1-2-1', 'G3');
insert into netz values('A1-2-1', 'G5');
insert into netz values('A1-2-1', 'G6');
insert into netz values('A1-2-1', 'G8');

insert into netz values('A1-2-2', 'G4');
insert into netz values('A1-2-2', 'G8');
insert into netz values('A1-2-2', 'G7');
insert into netz values('A1-2-2', 'B2');

INSERT INTO NETZ VALUES('A2-1', 'G9');
INSERT INTO NETZ VALUES('A2-1', 'G10');
INSERT INTO NETZ VALUES('A2-1', 'G11');
INSERT INTO NETZ VALUES('A2-1', 'G12');
INSERT INTO NETZ VALUES('A2-1', 'B1');

INSERT INTO NETZ VALUES('A2-2-1', 'G11');
INSERT INTO NETZ VALUES('A2-2-1', 'G13');
INSERT INTO NETZ VALUES('A2-2-1', 'G14');
INSERT INTO NETZ VALUES('A2-2-1', 'G15');

INSERT INTO NETZ VALUES('A2-2-2-1', 'B2');
INSERT INTO NETZ VALUES('A2-2-2-1', 'G12');
INSERT INTO NETZ VALUES('A2-2-2-1', 'G15');
INSERT INTO NETZ VALUES('A2-2-2-1', 'G17');

INSERT INTO NETZ VALUES('A2-2-2-2', 'GB3');
INSERT INTO NETZ VALUES('A2-2-2-2', 'G16');
INSERT INTO NETZ VALUES('A2-2-2-2', 'G17');
