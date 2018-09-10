DROP TABLE lehrer CASCADE CONSTRAINTS;
DROP TABLE schueler CASCADE CONSTRAINTS;
DROP TABLE entlehnung CASCADE CONSTRAINTS;
DROP TABLE leihtBuchAus CASCADE CONSTRAINTS;
DROP TABLE leihtVideoAus CASCADE CONSTRAINTS;
DROP TABLE buch CASCADE CONSTRAINTS;
DROP TABLE video CASCADE CONSTRAINTS;
DROP TABLE spieltMit CASCADE CONSTRAINTS;
DROP TABLE schauspieler CASCADE CONSTRAINTS;



CREATE TABLE lehrer(
	id INTEGER,
	name VARCHAR2(50),
	
	CONSTRAINT pk_lehrer PRIMARY KEY(id)
);

CREATE TABLE schueler(
	id INTEGER,
	name VARCHAR2(50),
	klasse VARCHAR2(50),
	
	CONSTRAINT pk_schueler PRIMARY KEY(id)
);

CREATE TABLE entlehnung(
	id INTEGER,
	lDatum VARCHAR2(50),
	rDatum VARCHAR2(50),
	pid INTEGER,
	sid INTEGER,

	
	CONSTRAINT pk_entlehnung PRIMARY KEY(id),
	CONSTRAINT fk_entlehnung_pid FOREIGN KEY (pid) REFERENCES lehrer(id),
	CONSTRAINT fk_entlehnung_sid FOREIGN KEY (sid) REFERENCES schueler(id)
);


CREATE TABLE buch(
	id INTEGER,
	titel VARCHAR2(50),
	
	CONSTRAINT pk_buch PRIMARY KEY(id)
);

CREATE TABLE leihtBuchAus(
	eid INTEGER,
	bid INTEGER,
	
	CONSTRAINT fk_leihtBuchAus_eid FOREIGN KEY (eid) REFERENCES entlehnung(id),
	CONSTRAINT fk_leihtBuchAus_bid FOREIGN KEY (bid) REFERENCES buch(id)

);

CREATE TABLE video(
	id INTEGER,
	titel VARCHAR2(50),
	
	CONSTRAINT pk_video PRIMARY KEY(id)
);

CREATE TABLE leihtVideoAus(
	eid INTEGER,
	vid INTEGER,
	
	CONSTRAINT fk_leihtVideoAus_eid FOREIGN KEY (eid) REFERENCES entlehnung(id),
	CONSTRAINT fk_leihtVideoAus_bid FOREIGN KEY (vid) REFERENCES video(id)

);


CREATE TABLE schauspieler(
	id INTEGER,
	name VARCHAR2(50),
	herkunftsland VARCHAR2(50),
	
	CONSTRAINT pk_schauspieler PRIMARY KEY(id)
);

CREATE TABLE spieltMit(
	vid INTEGER,
	sid INTEGER,
	
	CONSTRAINT fk_spieltMit_vid FOREIGN KEY (vid) REFERENCES video(id),
	CONSTRAINT fk_spieltMit_sid FOREIGN KEY (sid) REFERENCES schauspieler(id)

);


INSERT INTO schauspieler VALUES(1, 'Winnetou', 'USA');
INSERT INTO schauspieler VALUES(2, 'Old Shatterhand', 'D');
INSERT INTO schauspieler VALUES(3, 'Sam Hawkins', 'USA');

INSERT INTO video VALUES(1, 'Winnetou |');
INSERT INTO video VALUES(2, 'Winnetou ||');
INSERT INTO buch VALUES(1, 'Games of Throne');


INSERT INTO spieltMit VALUES(1,1);
INSERT INTO spieltMit VALUES(1,2);
INSERT INTO spieltMit VALUES(2,1);
INSERT INTO spieltMit VALUES(2,3);

INSERT INTO schueler VALUES(1, 'Karl Gerber', '3.Ahifs');
INSERT INTO lehrer VALUES(1, 'Kupfer');


INSERT INTO entlehnung VALUES(1, '12.01.2017', null, null, 1);
INSERT INTO entlehnung VALUES(2, '12.01.2016', '13.3.2016', 1, null);


INSERT INTO leihtVideoAus(1, 1);
INSERT INTO leihtVideoAus(1, 2);
INSERT INTO leihtVideoAus(2, 1);

INSERT INTO leihtBuchAus(1, 1);