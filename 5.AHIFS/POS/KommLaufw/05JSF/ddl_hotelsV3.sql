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
	pathimage VARCHAR2(130),
	CONSTRAINTS pk_hotels PRIMARY KEY (id)
) ROWDEPENDENCIES;
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
) ROWDEPENDENCIES;
INSERT INTO hotels VALUES(1,'Stella Maris','Caorle 12','senza climatica',110,'StellaMaris.png');
INSERT INTO hotels VALUES(2,'Star of Sea','Southend 13','accomodation',130,'StarOfSea.png');
INSERT INTO hotels VALUES(3,'Stern des Orion','Paternion 14','mit Dusche',144,'SternDesOrion.png');

INSERT INTO bookings VALUES(seqbookings.NEXTVAL,1,to_date('11.12.2011','dd.mm.yyyy'),to_date('13.12.2011','dd.mm.yyyy'),1,'Einstein');
INSERT INTO bookings VALUES(seqbookings.NEXTVAL,1,to_date('12.12.2011','dd.mm.yyyy'),to_date('14.12.2011','dd.mm.yyyy'),3,'Zweistein');
INSERT INTO bookings VALUES(seqbookings.NEXTVAL,2,to_date('13.01.2012','dd.mm.yyyy'),to_date('15.01.2012','dd.mm.yyyy'),2,'Einstein');
INSERT INTO bookings VALUES(seqbookings.NEXTVAL,2,to_date('17.12.2011','dd.mm.yyyy'),to_date('15.01.2012','dd.mm.yyyy'),1,'Dreistein');

commit;