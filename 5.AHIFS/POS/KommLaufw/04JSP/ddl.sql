DROP TABLE deliveries CASCADE CONSTRAINTS;
DROP TABLE orders CASCADE CONSTRAINTS;
DROP TABLE users CASCADE CONSTRAINTS;
DROP TABLE books CASCADE CONSTRAINTS;
CREATE TABLE users (
	username VARCHAR2(20),
	password VARCHAR2(20),
	CONSTRAINTS pk_user PRIMARY KEY (username),
	CONSTRAINTS ck_length CHECK (length(username) > 2 AND length(password) > 2)
);
CREATE TABLE books (
	id INTEGER,
	title VARCHAR2(50),
	author VARCHAR2(20),
	price INTEGER,
	CONSTRAINTS pk_books PRIMARY KEY (id),
	CONSTRAINTS ck_price CHECK (price BETWEEN 10 AND 200)
);
CREATE TABLE orders (
	username VARCHAR2(20),
	bookid INTEGER,
	CONSTRAINTS pk_orders PRIMARY KEY(username, bookid),
	CONSTRAINTS fk_ordersu FOREIGN KEY (username) REFERENCES users(username),
	CONSTRAINTS fk_ordersb FOREIGN KEY (bookid) REFERENCES books(id)
);
CREATE TABLE deliveries (
	username VARCHAR2(20),
	deldate DATE,
	deltotalprice INTEGER,
	CONSTRAINTS pk_deliveries PRIMARY KEY(username, deldate),
	CONSTRAINTS fk_deliveriesu FOREIGN KEY (username) REFERENCES users(username),
	CONSTRAINTS ck_price1 CHECK (deltotalprice > 30)
);
INSERT INTO users VALUES('admin','secret');
INSERT INTO users VALUES('adam','adam');
INSERT INTO users VALUES('eva','eva');

INSERT INTO books VALUES(1,'C# for Beginners','Cestein',44);
INSERT INTO books VALUES(2,'Java for Beginners','Jotstein',55);
INSERT INTO books VALUES(3,'C# for Eggsbirds','Cestein',66);
INSERT INTO books VALUES(4,'Java for Middleage','Jotstein',45);
INSERT INTO books VALUES(5,'C++ for Ancients','Cestein',89);
INSERT INTO books VALUES(6,'Soccer for Beginners','Hicke',110);
INSERT INTO books VALUES(7,'Soccer for Eggsbirds','Krankl',92);
INSERT INTO books VALUES(8,'Soccer for Hugo','Schneckerl',48);
INSERT INTO books VALUES(9,'Soccer for Little','Schneckerl',18);

INSERT INTO orders VALUES('adam',1);
INSERT INTO orders VALUES('adam',3);
INSERT INTO orders VALUES('adam',5);
INSERT INTO orders VALUES('adam',7);
INSERT INTO orders VALUES('adam',8);
INSERT INTO orders VALUES('adam',9);
INSERT INTO orders VALUES('eva',2);
INSERT INTO orders VALUES('eva',4);
INSERT INTO orders VALUES('eva',6);
INSERT INTO orders VALUES('eva',7);