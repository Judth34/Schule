drop table struktur cascade constraints;
drop table lager cascade constraints;
drop table artikel cascade constraints;
drop table et_liste cascade constraints;
drop table produktionsauftrag cascade constraints;
drop table nachbestellListe;
drop table log_tab_06;

create table artikel (
		a_nr varchar2(4) primary key,
		bezeichnung varchar2(30),
		preis number);

create table lager (
		a_nr varchar2(4) primary key,
		lagermenge number(5),
		mindestlagermenge number(5),
		nachbestellmenge number(5),
		maximallagermenge number(5),
		foreign key (a_nr) references artikel(a_nr));


create table struktur (
		o_a_nr varchar2(4),
		u_a_nr varchar2(4),
		menge number(5),
		primary key(o_a_nr, u_a_nr),
		foreign key(o_a_nr) references artikel(a_nr),
		foreign key(u_a_nr) references artikel(a_nr));

create table produktionsauftrag(
		pa_nr integer primary key,
		a_nr varchar2(4) references artikel(a_nr),
		pa_menge number);

create table et_liste(
		pa_nr integer,
		et_nr varchar2(4),
		et_menge number,
		primary key(pa_nr,et_nr),
		foreign key(pa_nr) references produktionsauftrag(pa_nr),
		foreign key(et_nr) references artikel(a_nr)
		);
				


create table nachbestellListe(
  PA_NR INTEGER,
  A_NR VARCHAR(20),
  et_menge INTEGER
);


create table log_tab_06(
  log_txt_06 VARCHAR2(100)
);


				
				
-- Einzelartikel
insert into artikel VALUES('E100', 'EPROM',100);
insert into artikel VALUES('E101', 'PROM',80);
insert into artikel VALUES('E102', 'EEPROM',150);
insert into artikel VALUES('E103', 'DDRAM',200);
insert into artikel VALUES('E104', 'SDRAM',200);
insert into artikel VALUES('E105', 'Prozessor',700);
insert into artikel VALUES('E200', 'Sockel',50);
insert into artikel VALUES('E300', 'Platine',500);

-- Bauartikel
insert into artikel VALUES('B100', 'Board_A',1000);
insert into artikel VALUES('B200', 'GrafikBoard',500);
insert into artikel VALUES('B300', 'SCSI-Board',1000);
insert into artikel VALUES('B400', 'Allwetter-Board',800);
insert into artikel VALUES('P100', 'Traktionskontrolle',3000);

-- Endprodukt
insert into artikel VALUES('P200', 'Wegfahrhilfe',4000);
insert into artikel VALUES('P300', 'ESP',5000);
					   
					   
-- Struktur
insert into Struktur Values('B100','B300',1);
insert into Struktur Values('B100','B400',1);
insert into Struktur Values('B200','E100',4);
insert into Struktur Values('B200','E102',2);
insert into Struktur Values('B200','E104',6);
insert into Struktur Values('B200','E300',1);
insert into Struktur Values('B300','E300',1);
insert into Struktur Values('B300','E200',1);
insert into Struktur Values('B300','E105',1);
insert into Struktur Values('B300','E104',6);
insert into Struktur Values('B300','E100',3);
insert into Struktur Values('B400','E300',1);
insert into Struktur Values('B400','E102',4);
insert into Struktur Values('P100','B100',2);
insert into Struktur Values('P100','E101',4);
insert into Struktur Values('P100','E102',2);
insert into Struktur Values('P200','B300',4);
insert into Struktur Values('P200','E105',1);
insert into Struktur Values('P300','B300',1);
insert into Struktur Values('P300','B200',1);



-- Lager
insert into Lager (a_nr, lagermenge,mindestlagermenge, nachbestellmenge) values ('E100', 10,5,10);
insert into Lager (a_nr, lagermenge,mindestlagermenge, nachbestellmenge) values ('E101', 10,5,10);
insert into Lager (a_nr, lagermenge,mindestlagermenge, nachbestellmenge) values ('E102', 10,5,10);
insert into Lager (a_nr, lagermenge,mindestlagermenge, nachbestellmenge) values ('E103', 10,5,10);
insert into Lager (a_nr, lagermenge,mindestlagermenge, nachbestellmenge) values ('E104', 10,5,10);
insert into Lager (a_nr, lagermenge,mindestlagermenge, nachbestellmenge) values ('E105', 10,5,10);
insert into Lager (a_nr, lagermenge,mindestlagermenge, nachbestellmenge) values ('E200', 10,5,10);
insert into Lager (a_nr, lagermenge,mindestlagermenge, nachbestellmenge) values ('E300', 10,5,10);
commit;
