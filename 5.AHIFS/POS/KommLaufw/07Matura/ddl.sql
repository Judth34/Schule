DROP TABLE location CASCADE CONSTRAINTS;
DROP TABLE route CASCADE CONSTRAINTS;
DROP TABLE section CASCADE CONSTRAINTS;
DROP TABLE shipment CASCADE CONSTRAINTS;

CREATE TABLE location
( locid INTEGER,
  locname VARCHAR2(50),
  coox INTEGER,                 -- coo of loc in animation
  cooy INTEGER,
  CONSTRAINT pkLocation PRIMARY KEY (locid)
);

CREATE TABLE section
( secid INTEGER,
  locidstart INTEGER,
  locidend INTEGER,
  sectimespan INTEGER,          -- msec for animation
  maxgondoliereallowed INTEGER, -- how many gondolieres at the same time allowed
  CONSTRAINT pkSection PRIMARY KEY (secid),
  CONSTRAINT fkSection1 FOREIGN KEY (locidstart) REFERENCES location,
  CONSTRAINT fkSection2 FOREIGN KEY (locidend) REFERENCES location,
  CONSTRAINT uqSection UNIQUE (locidstart, locidend)
);

CREATE TABLE shipment
( shid INTEGER,
  startdate DATE, -- date time
  enddate DATE,   -- estimated time (for further usage)
  gondoliere VARCHAR2(50),
  pwd VARCHAR2(50),
  details VARCHAR2(50),
  CONSTRAINT pkShipment PRIMARY KEY (shid)
);


CREATE TABLE route
( shid INTEGER,
  routeid INTEGER,  -- sequence of route (1,2,3,...)
  secid INTEGER,
  routestartdate DATE,
  routeenddate DATE,
  CONSTRAINT pkRoute PRIMARY KEY (shid, routeid),
  CONSTRAINT fkRoute1 FOREIGN KEY (shid) REFERENCES shipment,
  CONSTRAINT fkRoute2 FOREIGN KEY (secid) REFERENCES section
);

INSERT INTO location VALUES(1, 'Stazione Ferroviaria', 330, 10);
INSERT INTO location VALUES(2, 'Piazzale Roma', 330, 170);
INSERT INTO location VALUES(3, 'S. Rocco', 500, 230);
INSERT INTO location VALUES(4, 'S. Maria', 620, 140);
INSERT INTO location VALUES(5, 'Madonna dell'' Orto', 1050, 140);
INSERT INTO location VALUES(6, 'S. Terese', 130, 290);
INSERT INTO location VALUES(7, 'S. Marco', 500, 480);
INSERT INTO location VALUES(8, 'Pallazo Ducale', 760, 470);
INSERT INTO location VALUES(9, 'Arsenale', 1040, 300);

INSERT INTO section VALUES(1, 1, 2, 4000, 1);
INSERT INTO section VALUES(2, 2, 3, 5000, 1);
INSERT INTO section VALUES(3, 3, 4, 2000, 1);
INSERT INTO section VALUES(4, 4, 8, 4000, 1);
INSERT INTO section VALUES(5, 4, 5, 2000, 1);
INSERT INTO section VALUES(6, 3, 7, 4000, 1000);
INSERT INTO section VALUES(7, 6, 7, 3000, 1);
INSERT INTO section VALUES(8, 7, 8, 5000, 1);
INSERT INTO section VALUES(9, 8, 9, 5000, 1);
INSERT INTO section VALUES(11, 2, 1, 4000, 1);
INSERT INTO section VALUES(12, 3, 2, 5000, 1);
INSERT INTO section VALUES(13, 4, 3, 2000, 1);
INSERT INTO section VALUES(14, 8, 4, 4000, 1);
INSERT INTO section VALUES(15, 5, 4, 2000, 1);
INSERT INTO section VALUES(16, 7, 3, 4000, 1000);
INSERT INTO section VALUES(17, 7, 6, 3000, 1);
INSERT INTO section VALUES(18, 8, 7, 5000, 1);
INSERT INTO section VALUES(19, 9, 8, 5000, 1);

INSERT INTO shipment VALUES(1, TO_DATE('05.04.2019 08:00','DD.MM.YYYY HH24:MI'), NULL, 'Paolo', 'segreto', '4 personi');
INSERT INTO shipment VALUES(2, TO_DATE('05.04.2019 08:00','DD.MM.YYYY HH24:MI'), NULL, 'Emanuele', 'segreto', '6 personi');
INSERT INTO shipment VALUES(3, TO_DATE('05.04.2019 08:00','DD.MM.YYYY HH24:MI'), NULL, 'Umberto', 'segreto', 'birra urgente');
INSERT INTO shipment VALUES(4, TO_DATE('05.04.2019 08:00','DD.MM.YYYY HH24:MI'), NULL, 'Giovanni', 'segreto', 'vino urgente');
INSERT INTO shipment VALUES(5, TO_DATE('05.04.2019 08:00','DD.MM.YYYY HH24:MI'), NULL, 'Giuseppe', 'segreto', 'famiglia');
INSERT INTO shipment VALUES(6, TO_DATE('06.04.2019 08:00','DD.MM.YYYY HH24:MI'), NULL, 'Paolo', 'segreto', 'pesce urgente');

INSERT INTO route VALUES(1, 1, 1, NULL, NULL);
INSERT INTO route VALUES(1, 2, 2, NULL, NULL);
INSERT INTO route VALUES(2, 1, 15, NULL, NULL);
INSERT INTO route VALUES(2, 2, 13, NULL, NULL);
INSERT INTO route VALUES(2, 3, 6, NULL, NULL);
INSERT INTO route VALUES(2, 4, 17, NULL, NULL);
INSERT INTO route VALUES(3, 1, 16, NULL, NULL);
INSERT INTO route VALUES(4, 1, 8, NULL, NULL);
INSERT INTO route VALUES(4, 2, 14, NULL, NULL);
INSERT INTO route VALUES(4, 3, 5, NULL, NULL);
INSERT INTO route VALUES(5, 1, 14, NULL, NULL);
INSERT INTO route VALUES(5, 2, 13, NULL, NULL);
INSERT INTO route VALUES(5, 3, 12, NULL, NULL);
INSERT INTO route VALUES(5, 4, 11, NULL, NULL);
INSERT INTO route VALUES(6, 1, 7, NULL, NULL);
INSERT INTO route VALUES(6, 2, 16, NULL, NULL);
INSERT INTO route VALUES(6, 3, 3, NULL, NULL);

COMMIT;