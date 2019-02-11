/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 * Author:  Gerald
 * Created: 10.01.2017
 */
DROP TABLE products CASCADE CONSTRAINTS;
DROP TABLE producers CASCADE CONSTRAINTS;
DROP SEQUENCE seqProduct;
DROP SEQUENCE seqProducer;

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
	CONSTRAINT fkProducts FOREIGN KEY (id_pc) REFERENCES producers(id)
);
CREATE SEQUENCE seqProduct START WITH 100 INCREMENT BY 10;
CREATE SEQUENCE seqProducer START WITH 11 INCREMENT BY 11;
INSERT INTO producers VALUES(seqProducer.NEXTVAL,'Scheiben AG',NULL);
INSERT INTO producers VALUES(seqProducer.NEXTVAL,'CeDe AG',10000.11);
INSERT INTO producers VALUES(seqProducer.NEXTVAL,'ÖFBB',5000.55);
INSERT INTO producers VALUES(seqProducer.NEXTVAL,'DFBB',1000.1);
INSERT INTO producers VALUES(seqProducer.NEXTVAL,'Haitek',909.90);
INSERT INTO producers VALUES(seqProducer.NEXTVAL,'Kornblum',NULL);

INSERT INTO products VALUES(seqProduct.NEXTVAL,'Frisby',33,200,TO_DATE('11.04.2002','DD.MM.YYYY'));
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Frisby',22,200,TO_DATE('08.11.2012','DD.MM.YYYY'));
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Ball',33,190,TO_DATE('15.02.2009','DD.MM.YYYY'));
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Ball',44,2,TO_DATE('11.01.1992','DD.MM.YYYY'));
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Fidschi Gogerl',44,1000,TO_DATE('01.07.2013','DD.MM.YYYY'));
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Fidschi Gogerl',33,10,TO_DATE('11.08.2013','DD.MM.YYYY'));
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Fidschi Gogerl',55,22,TO_DATE('05.04.2002','DD.MM.YYYY'));
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Murmel',33,802,TO_DATE('13.11.2010','DD.MM.YYYY'));
INSERT INTO products VALUES(seqProduct.NEXTVAL,'Waveboard',22,402,TO_DATE('13.11.2011','DD.MM.YYYY'));
commit;

SELECT * FROM producers;
SELECT id, name, id_pc, onStock, TO_CHAR(onMarket,'DD.MM.YYYY') "on market" FROM products;
