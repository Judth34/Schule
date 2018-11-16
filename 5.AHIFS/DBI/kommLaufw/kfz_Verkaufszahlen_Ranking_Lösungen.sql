set pagesize 100;

1) Average sold cars per producer per country country and year.
   Round results.

 YEAR REGION                          AVG_SALES AVG_VALUES
----- ------------------------------ ---------- ------------
 2002 France                               5000  217,000,000
 2002 Germany                              6600  430,000,000
 2002 United Kingdom                        400   25,000,000
 2002 ===> avg per region                  4700  275,000,000
 2003 France                               4400  191,000,000
 2003 Germany                              7000  452,000,000
 2003 United Kingdom                        500   32,000,000
 2003 ===> avg per region                  4700  282,000,000
 2004 France                               4400  191,000,000
 2004 Germany                              6000  396,000,000
 2004 United Kingdom                        300   22,000,000
 2004 ===> avg per region                  4200  251,000,000
 2005 France                               3800  167,000,000
 2005 Germany                              5200  347,000,000
 2005 United Kingdom                        300   19,000,000
 2005 ===> avg per region                  3600  220,000,000
 2006 France                               4500  219,000,000
 2006 Germany                              6200  412,000,000
 2006 United Kingdom                        400   28,000,000
 2006 ===> avg per region                  4300  268,000,000
 2007 France                               3900  193,000,000
 2007 Germany                              5100  354,000,000
 2007 United Kingdom                        300   22,000,000
 2007 ===> avg per region                  3600  231,000,000
 2008 France                               3600  180,000,000
 2008 Germany                              4700  330,000,000
 2008 United Kingdom                        200   14,000,000
 2008 ===> avg per region                  3300  213,000,000

SELECT year, DECODE(GROUPING(regions.name),1,'===> avg per region',regions.name) region, ROUND(AVG(sales),-2) avg_sales, 
		TO_CHAR(ROUND(AVG(sale_values),-6),'999,999,999') avg_values
  FROM sales INNER JOIN cars ON sales.carid = cars.carid INNER JOIN regions ON cars.regionid = regions.regionid
 GROUP BY GROUPING SETS
    ((year, regions.name),
     (year)
    );


2) top ten sales per year and cartype

NAME                                 YEAR      SALES       rank
------------------------------ ---------- ---------- ----------
Mercedes S                           2002      11395          1
Mercedes S                           2006      10985          2
Mercedes S                           2003       9835          3
BMW 7                                2002       8610          4
Mercedes S                           2008       8474          5
Mercedes S                           2007       8262          6
BMW 7                                2003       7881          7
BMW 7                                2004       7672          8
Mercedes S                           2004       7045          9
Audi A8                              2003       6988         10

CREATE VIEW v AS
SELECT cars.name, year, sales,
		  RANK() OVER (ORDER BY sales desc ) AS "rank"
  FROM sales INNER JOIN cars ON sales.carid = cars.carid
;

SELECT * FROM v
 WHERE "rank" < 11
 ORDER BY "rank";
 
DROP VIEW v;

3) top three cartypes per year concerning sale-values

 YEAR NAME                           SALE_VALUES       rank
----- ------------------------------ ----------- ----------
 2002 Mercedes S                       774860000          1
 2002 BMW 7                            568260000          2
 2002 Audi A8                          257299000          3
 2003 Mercedes S                       668780000          1
 2003 BMW 7                            528027000          2
 2003 Audi A8                          426268000          3
 2004 BMW 7                            514024000          1
 2004 Mercedes S                       500195000          2
 2004 Audi A8                          406870000          3
 2005 Mercedes S                       476978000          1
 2005 BMW 7                            434662000          2
 2005 Audi A8                          318969000          3
 2006 Mercedes S                       725010000          1
 2006 BMW 7                            414427000          2
 2006 Audi A8                          361270000          3
 2007 Mercedes S                       611388000          1
 2007 Audi A8                          333645000          2
 2007 BMW 7                            301636000          3
 2008 Mercedes S                       627076000          1
 2008 Audi A8                          310143000          2
 2008 BMW 7                            214304000          3

CREATE VIEW v AS
SELECT year, cars.name, sale_values ,
  RANK() OVER (PARTITION BY year ORDER BY sale_values DESC ) AS "rank"
  FROM sales INNER JOIN cars ON sales.carid = cars.carid
;

SELECT * FROM v
 WHERE "rank" < 4
 ORDER BY year, "rank";
 
DROP VIEW v;





---------------------------------------------------------------
WITH v AS
(SELECT year, cars.name, sale_values ,
  RANK() OVER (PARTITION BY year ORDER BY sale_values DESC ) AS "rank"
  FROM sales INNER JOIN cars ON sales.carid = cars.carid
;)
SELECT * FROM v
 WHERE "rank" < 4
 ORDER BY year, "rank";
 









4) yearly increase/decrease of sales  for citroen 


      YEAR      SALES former year change
---------- ---------- ----------- ------
      2002       4632        4632    0 %
      2003       4197        4632  -10 %
      2004       3632        4197  -16 %
      2005       2900        3632  -25 %
      2006       3976        2900   27 %
      2007       3467        3976  -15 %
      2008       2965        3467  -17 %

SELECT year, sales,
  FIRST_VALUE(sales) OVER (ORDER BY year ROWS BETWEEN 1 PRECEDING AND 0 FOLLOWING ) AS "former year",
  to_char(
  (sales -
  (FIRST_VALUE(sales)  OVER (ORDER BY year ROWS BETWEEN 1 PRECEDING AND 0 FOLLOWING ))) * 100 / sales
  ,'999') || ' %' AS "change"
  FROM sales INNER JOIN cars ON sales.carid = cars.carid
 WHERE cars.name LIKE 'Citroen%'  
  ;


SELECT year, sales,
  LAG(sales,1) OVER ( order by year ) AS "former year",    ---PARTITION BY cartype
  to_char(
  (sales -
  (LAG(sales,1) OVER ( order by year ))) * 100 / sales   ----PARTITION BY cartype
  ,'999') || ' %' AS "change"
  FROM sales INNER JOIN cars ON sales.carid = cars.carid
 WHERE cars.name LIKE 'Citroen%'  
  ;


