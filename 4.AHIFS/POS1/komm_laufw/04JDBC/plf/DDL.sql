DROP TABLE products CASCADE CONSTRAINTS;
DROP TABLE producers CASCADE CONSTRAINTS;
DROP TABLE orders CASCADE CONSTRAINTS;
DROP TABLE dummy CASCADE CONSTRAINTS;

DROP SEQUENCE seqProduct;
DROP SEQUENCE seqProducer;
DROP SEQUENCE seqOrder;

CREATE TABLE dummy
( id INTEGER
);
CREATE TABLE producers
(	id INTEGER PRIMARY KEY,
	name VARCHAR2(30),
	sales NUMBER(10,2)
);

CREATE TABLE products
(	id INTEGER PRIMARY KEY,
	name VARCHAR2(30),
	id_pc INTEGER,
	onStock INTEGER,
	onMarket DATE,
	price INTEGER,
	CONSTRAINT fkProducts FOREIGN KEY (id_pc) REFERENCES producers(id),
        CONSTRAINT ckProducts CHECK (onStock BETWEEN 0 AND 1000)
);
CREATE TABLE orders
(	id INTEGER ,
	id_product INTEGER,
	qty INTEGER,
	CONSTRAINT pkOrders1 PRIMARY KEY (id, id_product),
	CONSTRAINT fkProducts1 FOREIGN KEY (id_product) REFERENCES products(id)
);

CREATE SEQUENCE seqProduct START WITH 100 INCREMENT BY 10;
CREATE SEQUENCE seqProducer START WITH 11 INCREMENT BY 11;
CREATE SEQUENCE seqOrder START WITH 1 INCREMENT BY 1;

INSERT INTO dummy VALUES(99);
INSERT INTO producers VALUES(seqProducer.NEXTVAL,'Scheiben AG',NULL);
INSERT INTO producers VALUES(seqProducer.NEXTVAL,'CeDe AG',10000.11);
INSERT INTO producers VALUES(seqProducer.NEXTVAL,'ÖFBB',5000.55);
INSERT INTO producers VALUES(seqProducer.NEXTVAL,'DFBB',1000.1);
INSERT INTO producers VALUES(seqProducer.NEXTVAL,'Haitek',909.90);
INSERT INTO producers VALUES(seqProducer.NEXTVAL,'Kornblum',NULL);

INSERT INTO products VALUES(seqProduct.NEXTVAL,'Frisby',33,200,TO_DATE('11.04.2002','DD.MM.YYYY'),20);
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Frisby',22,200,TO_DATE('08.11.2012','DD.MM.YYYY'),25);
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Ball',33,190,TO_DATE('15.02.2009','DD.MM.YYYY'),13);
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Ball',44,2,TO_DATE('11.01.1992','DD.MM.YYYY'),17);
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Fidschi Gogerl',44,1000,TO_DATE('01.07.2013','DD.MM.YYYY'),2);
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Fidschi Gogerl',33,10,TO_DATE('11.08.2013','DD.MM.YYYY'),4);
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Fidschi Gogerl',55,22,TO_DATE('05.04.2002','DD.MM.YYYY'),6);
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Murmel',33,802,TO_DATE('13.11.2010','DD.MM.YYYY'),2);
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Waveboard',22,402,TO_DATE('13.11.2011','DD.MM.YYYY'),100);

commit;




