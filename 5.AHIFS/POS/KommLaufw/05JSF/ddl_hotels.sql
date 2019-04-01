DROP SEQUENCE seqbookings;
DROP TABLE bookings CASCADE CONSTRAINTS;
DROP TABLE hotels CASCADE CONSTRAINTS;
CREATE SEQUENCE seqbookings;
CREATE TABLE hotels (
	id INTEGER,
	hotelname VARCHAR2(20),
	address VARCHAR2(20),
	information VARCHAR2(50),
	number_rooms_total INTEGER,
	image VARCHAR2(30),
	CONSTRAINTS pk_hotels PRIMARY KEY (id)
);
CREATE TABLE bookings (
	id INTEGER,
	id_hotel INTEGER,
	check_in DATE,
	check_out DATE,
	number_rooms INTEGER,
	guest VARCHAR2(20),
	CONSTRAINTS pk_bookings PRIMARY KEY (id),
	CONSTRAINTS ck_date CHECK (check_in < check_out),
	CONSTRAINTS fk_bookings FOREIGN KEY (id_hotel) REFERENCES hotels(id)
);
INSERT INTO hotels VALUES(1,'Stella Maris','Caorle 12','senza climatica',110,'StellaMaris.png');
INSERT INTO hotels VALUES(2,'Star of Sea','Southend 13','accomodation',130,'StarOfSea.png');
INSERT INTO hotels VALUES(3,'Stern des Orion','Paternion 14','mit Dusche',144,'SternDesOrion.png');

INSERT INTO bookings VALUES(seqbookings.NEXTVAL,1,'11.12.2011','13.12.2011',1,'Einstein');
INSERT INTO bookings VALUES(seqbookings.NEXTVAL,1,'12.12.2011','14.12.2011',3,'Zweistein');
INSERT INTO bookings VALUES(seqbookings.NEXTVAL,2,'13.01.2012','15.01.2012',2,'Einstein');
INSERT INTO bookings VALUES(seqbookings.NEXTVAL,2,'17.12.2011','15.01.2012',1,'Dreistein');

commit;