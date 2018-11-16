drop table buecher;
drop table leser;
drop table gelesen;
drop table beruf;

create table buecher(bno int primary key,btitel varchar2(30),anzahlseiten int);
create table leser(lno int primary key,lname varchar2(30),jobno int);
create table gelesen(lno int,bno int,von date,bis date);
create table beruf(jno int primary key,jname varchar2(30));

drop sequence seq_leser;
create sequence seq_leser;

insert into buecher values(seq_leser.nextval,'Winnetou I',101);
insert into buecher values(seq_leser.nextval,'Winnetou II',2101);
insert into buecher values(seq_leser.nextval,'Lederstrumpf',301);
insert into buecher values(seq_leser.nextval,'Schlafes Bruder',404);
insert into buecher values(seq_leser.nextval,'C# fuer Anfänger',1);
insert into buecher values(seq_leser.nextval,'C++ fuer Profis',1001);
insert into buecher values(seq_leser.nextval,'Maerchen',543);

insert into beruf values(seq_leser.nextval,'Schueler');
insert into beruf values(seq_leser.nextval,'Lehrer');
insert into beruf values(seq_leser.nextval,'Sonstige');

insert into leser values(seq_leser.nextval,'Ameise',8);
insert into leser values(seq_leser.nextval,'Bmeise',8);
insert into leser values(seq_leser.nextval,'Cmeise',8);
insert into leser values(seq_leser.nextval,'Einstein',9);
insert into leser values(seq_leser.nextval,'Zweistein',9);
insert into leser values(seq_leser.nextval,'Dreistein',10);

insert into gelesen values(11,1,'11/12/2005','14/12/2005');
insert into gelesen values(11,2,'11/12/2005','15/12/2005');
insert into gelesen values(11,3,'11/11/2005','14/12/2005');
insert into gelesen values(11,4,'11/10/2005','14/12/2005');
insert into gelesen values(11,1,'21/01/2006','22/02/2006');
insert into gelesen values(11,2,'21/01/2006','22/03/2006');
insert into gelesen values(11,3,'11/04/2006','14/12/2006');
insert into gelesen values(12,6,'04/05/2006','14/06/2006');
insert into gelesen values(12,5,'11/12/2006','14/12/2006');
insert into gelesen values(12,6,'11/12/2005','14/12/2005');
insert into gelesen values(12,5,'10/10/2005','14/12/2005');
insert into gelesen values(12,4,'11/12/2006','14/12/2006');
insert into gelesen values(12,1,'11/12/2005','14/12/2005');
insert into gelesen values(13,1,'11/12/2005','14/12/2005');
insert into gelesen values(13,2,'10/02/2005','14/02/2005');
insert into gelesen values(14,4,'11/12/2005','14/12/2005');
insert into gelesen values(14,5,'11/12/2006','14/12/2006');
insert into gelesen values(14,3,'10/02/2005','04/03/2005');
insert into gelesen values(15,4,'11/12/2005','14/12/2005');
insert into gelesen values(15,6,'11/12/2005','14/12/2005');
insert into gelesen values(16,5,'11/12/2005','14/12/2005');
insert into gelesen values(16,6,'11/09/2005','14/12/2005');
insert into gelesen values(16,7,'11/08/2005','14/12/2005');

column lname   format a10
column jname   format a10
column jahr    format a10
column avg_mon format 99.9
column avg_day format 99
column job   format a10
column "Veränderung in %" format 9999.9
column buch format a15
set linesize 100;
set pagesize 100;

--------------------------------------------------------------------
Ermittle die Leserzahlen und die durchschnittliche Entlehndauer bezogen auf Berufsgruppen und Jahr. 

select jname,decode(grouping_id(to_char(von,'yyyy')),1,'alle Jahre',to_char(von,'yyyy')) jahr,
count(*) Leseranzahl,avg(months_between(bis,von)) avg_mon
  from (leser join gelesen on leser.lno=gelesen.lno)
              join beruf on leser.jobno=beruf.jno
group by rollup(jname,to_char(von,'yyyy'))
having grouping_id(jname,to_char(von,'yyyy')) between 0 and 1
order by 1,grouping_id(jname,to_char(von,'yyyy')),2;

JNAME      JAHR            LESERANZAHL AVG_MON
---------- --------------- ----------- -------
Lehrer     2005                      4      .3
Lehrer     2006                      1      .1
Lehrer     alle Jahre                5      .2
Schueler   2005                      9      .7
Schueler   2006                      6     2.1
Schueler   alle Jahre               15     1.2
Sonstige   2005                      3     2.4
Sonstige   alle Jahre                3     2.4
---------------------------------------------------------------------
Ermittle die durchschnittliche Entlehndauer der einzelnen Bücher bezogen auf Berufsgruppen und
auf die einzelnen Jahre und für die einzelnen Bücher allgemein.

select btitel,decode(grouping_id(to_char(von,'yyyy')),1,'alle',to_char(von,'yyyy')) jahr,
		decode(grouping_id(jname),1,'alle',jname) job,
		avg(months_between(bis,von)) as avg_mon ,
       	grouping_id(jname,to_char(von,'yyyy')) gid
  from ((leser join gelesen on leser.lno=gelesen.lno)
              join buecher on buecher.bno=gelesen.bno)
		  join beruf on leser.jobno=beruf.jno
group by cube(btitel,to_char(von,'yyyy'), jname)
having count(*)>1 and grouping_id(btitel,jname,to_char(von,'yyyy')) between 1 and 3
order by grouping_id(jname,to_char(von,'yyyy'));

BTITEL                         JAHR            JOB        AVG_MON        GID
------------------------------ --------------- ---------- ------- ----------
Winnetou I                     alle            Schueler        .3          1
Winnetou II                    alle            Schueler        .8          1
Lederstrumpf                   alle            Schueler       4.6          1
C++ fuer Profis                alle            Schueler        .7          1
Schlafes Bruder                alle            Schueler       1.1          1
C# fuer Anfänger               alle            Schueler       1.1          1
Schlafes Bruder                alle            Lehrer          .1          1
Winnetou I                     2005            alle            .1          2
Winnetou II                    2005            alle            .1          2
Schlafes Bruder                2005            alle            .8          2
C# fuer Anfänger               2006            alle            .1          2
C# fuer Anfänger               2005            alle           1.1          2
C++ fuer Profis                2005            alle           1.1          2
Lederstrumpf                   2005            alle           1.0          2
Winnetou I                     alle            alle            .3          3
Winnetou II                    alle            alle            .8          3
C# fuer Anfänger               alle            alle            .6          3
Schlafes Bruder                alle            alle            .6          3
C++ fuer Profis                alle            alle           1.2          3
Lederstrumpf                   alle            alle           3.3          3
------------------------------------------------------------------------------

----------------------------
Ermittle die Summe der Entlehnungen bezogen auf die Berufsgruppen

select sum(decode(jname,'Schueler',1,0)) Schueler,
		sum(decode(jname,'Lehrer',1,0)) Lehrer,
		sum(decode(jname,'Sonstige',1,0)) Sonstige
  from gelesen join leser on gelesen.lno = leser.lno join beruf on leser.jobno = beruf.jno
  ;

  SCHUELER     LEHRER   SONSTIGE
---------- ---------- ----------
        15          5          3

----------------------------
Ermittle die Summe der Entlehnungen der Berufsgruppen aufgeteilt auf die Monate

select to_char(von,'MON') Monat, sum(decode(jname,'Schueler',1,0)) Schueler,
		sum(decode(jname,'Lehrer',1,0)) Lehrer,
		sum(decode(jname,'Sonstige',1,0)) Sonstige
  from gelesen join leser on gelesen.lno = leser.lno join beruf on leser.jobno = beruf.jno
  group by to_char(von,'MON'),to_char(von,'MM')
  order by to_char(von,'MM')
  ;

MON   SCHUELER     LEHRER   SONSTIGE
--- ---------- ---------- ----------
JAN          2          0          0
FEB          1          1          0
APR          1          0          0
MAI          1          0          0
AUG          0          0          1
SEP          0          0          1
OKT          2          0          0
NOV          1          0          0
DEZ          7          4          1

----------------------------------
aufgeteilt auf Quartale

select to_char(von,'Q')||'. Qu. ' Quartal, sum(decode(jname,'Schueler',1,0)) Schueler,
		sum(decode(jname,'Lehrer',1,0)) Lehrer,
		sum(decode(jname,'Sonstige',1,0)) Sonstige
  from gelesen join leser on gelesen.lno = leser.lno join beruf on leser.jobno = beruf.jno
  group by to_char(von,'Q')
  order by to_char(von,'Q')
  ;

QUARTAL   SCHUELER     LEHRER   SONSTIGE
------- ---------- ---------- ----------
1. Qu.           3          1          0
2. Qu.           2          0          0
3. Qu.           0          0          2
4. Qu.          10          4          1
==============================================================
select jname, 
	sum(decode(to_char(von,'Q'),1,1,0)) as "1.Qu",
	sum(decode(to_char(von,'Q'),2,1,0)) as "2.Qu",
	sum(decode(to_char(von,'Q'),3,1,0)) as "3.Qu",
	sum(decode(to_char(von,'Q'),4,1,0)) as "4.Qu"
  from gelesen join leser on gelesen.lno = leser.lno join beruf on leser.jobno = beruf.jno
  group by jname
  order by jname
  ;

JNAME            1.Qu       2.Qu       3.Qu       4.Qu
---------- ---------- ---------- ---------- ----------
Lehrer              1          0          0          4
Schueler            3          2          0         10
Sonstige            0          0          2          1
==============================================================

Statistik über Lehrer
=====================
select decode(grouping_id(btitel),1,'alle Buecher',btitel) buch,
		decode(grouping_id(to_char(von,'yyyy')),1,'ueber alle Jahre',to_char(von,'yyyy')) jahr,
		count(*) as anzahl,
		avg(bis-von) as avg_day 
  from ((leser join gelesen on leser.lno=gelesen.lno)
              join buecher on buecher.bno=gelesen.bno)
		  join beruf on leser.jobno=beruf.jno
where jname = 'Lehrer'
group by cube(btitel,to_char(von,'yyyy'), jname)
having grouping_id(btitel,jname,to_char(von,'yyyy')) IN (0,4,5)
order by grouping_id(btitel,jname,to_char(von,'yyyy')),to_char(von,'yyyy'),btitel;

Statistik über Lehrer
=====================
BUCH                           JAHR                     ANZAHL AVG_DAY
------------------------------ -------------------- ---------- -------
C++ fuer Profis                2005                          1       3
Lederstrumpf                   2005                          1      22
Schlafes Bruder                2005                          2       3
C# fuer Anfänger               2006                          1       3
alle Buecher                   2005                          4       8
alle Buecher                   2006                          1       3
alle Buecher                   ueber alle Jahre              5       7


==============================================================
Veränderung der Zahlen von 2005 auf 2006

drop view v2005;
drop view v2006;


create or replace view v2005 as
select 	decode(grouping_id(to_char(von,'yyyy')),1,'ueber alle Jahre',to_char(von,'yyyy')) jahr,
		jname,
		decode(grouping_id(btitel),1,'alle Buecher',btitel) buch,
		count(*) as anzahl
  from ((leser join gelesen on leser.lno=gelesen.lno)
              join buecher on buecher.bno=gelesen.bno)
		  join beruf on leser.jobno=beruf.jno
  where to_char(von,'yyyy')=2005
group by cube(btitel,to_char(von,'yyyy'), jname)
having grouping_id(btitel,jname,to_char(von,'yyyy')) = 0
order by grouping_id(btitel,jname,to_char(von,'yyyy')),to_char(von,'yyyy'),jname,btitel;

create or replace view v2006 as
select 	decode(grouping_id(to_char(von,'yyyy')),1,'ueber alle Jahre',to_char(von,'yyyy')) jahr,
		jname,
		decode(grouping_id(btitel),1,'alle Buecher',btitel) buch,
		count(*) as anzahl
  from ((leser join gelesen on leser.lno=gelesen.lno)
              join buecher on buecher.bno=gelesen.bno)
		  join beruf on leser.jobno=beruf.jno
  where to_char(von,'yyyy')=2006
group by cube(btitel,to_char(von,'yyyy'), jname)
having grouping_id(btitel,jname,to_char(von,'yyyy')) = 0
order by grouping_id(btitel,jname,to_char(von,'yyyy')),to_char(von,'yyyy'),jname,btitel;

select v.jname,v.buch,v.anzahl as "Anzahl 2005",nvl(w.anzahl,0) as "Anzahl 2006", 
		(nvl(w.anzahl,0) - v.anzahl) * 100 / v.anzahl as "Veränderung in %"
   from v2005 v left join v2006 w on v.buch=w.buch and v.jname=w.jname
 order by v.jname, v.buch
;

JNAME      BUCH                   Anzahl 2005 Anzahl 2006 Veränderung in %
---------- ---------------------- ----------- ----------- ----------------
Lehrer     C++ fuer Profis                  1           0           -100.0
Lehrer     Lederstrumpf                     1           0           -100.0
Lehrer     Schlafes Bruder                  2           0           -100.0
Schueler   C# fuer Anfänger                 1           1               .0
Schueler   C++ fuer Profis                  1           1               .0
Schueler   Lederstrumpf                     1           1               .0
Schueler   Schlafes Bruder                  1           1               .0
Schueler   Winnetou I                       3           1            -66.7
Schueler   Winnetou II                      2           1            -50.0
Sonstige   C# fuer Anfänger                 1           0           -100.0
Sonstige   C++ fuer Profis                  1           0           -100.0
Sonstige   Maerchen                         1           0           -100.0


==============================================================
==============================================================
==============================================================
==============================================================
