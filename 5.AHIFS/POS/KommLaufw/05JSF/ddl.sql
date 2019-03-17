DROP TABLE orders CASCADE CONSTRAINTS;
DROP TABLE users CASCADE CONSTRAINTS;
DROP TABLE books CASCADE CONSTRAINTS;
CREATE TABLE users (
	username VARCHAR2(20),
	password VARCHAR2(20),
	information VARCHAR2(50),
	count_orders INTEGER,
	CONSTRAINTS pk_user PRIMARY KEY (username)
);
CREATE TABLE books (
	id INTEGER,
	title VARCHAR2(50),
	author VARCHAR2(20),
	price INTEGER,
	CONSTRAINTS pk_books PRIMARY KEY (id)
);
CREATE TABLE orders (
	username VARCHAR2(20),
	bookid INTEGER,
	CONSTRAINTS pk_orders PRIMARY KEY(username, bookid),
	CONSTRAINTS fk_orders FOREIGN KEY (bookid) REFERENCES books(id)
);
INSERT INTO users VALUES('admin','secret','administrator',0);
INSERT INTO users VALUES('adam','adam','poor reader',11);
INSERT INTO users VALUES('eva','eva','great library',22);

INSERT INTO books VALUES(1,'C# for Beginners','Cestein',12);
INSERT INTO books VALUES(2,'Java for Beginners','Jotstein',32);

commit;
