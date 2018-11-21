drop table called_persMJ cascade constraints;
drop table countryMJ cascade constraints;
drop table calls2017MJ cascade constraints;
drop table netMJ cascade constraints;
drop sequence seq_calls2017MJ;

create sequence seq_calls2017MJ;

-- angerufene Person
create table called_persMJ(
	cnr integer primary key, 
	cname varchar2(20));

-- Zielland
create table countryMJ (
	countryMJ_id integer primary key, 
	countryMJ_name varchar2(20));

-- netMJz aus dem gerufen wird
create table netMJ(
	netMJ_id integer primary key, 
	netMJ_name varchar2(20), 
	cent_per_min integer); 

create table calls2017MJ(
	call_nr integer,  
	netMJ_id integer references netMJ(netMJ_id),  -- rufendes netMJz
	countryMJ_id integer references countryMJ (countryMJ_id),  -- Zielland
	duration integer,  -- in Minuten
	call_date date,
	cnr integer references called_persMJ(cnr));  -- angerufene Person

	
insert into called_persMJ values (1,'Einstein');
insert into called_persMJ values (2,'Zweistein');
insert into called_persMJ values (3,'Dreistein');
insert into called_persMJ values (4,'Vierstein');

insert into countryMJ values (0043,'Austria');
insert into countryMJ values (0044,'Great Britain');
insert into countryMJ values (0046,'Germany');

insert into netMJ values(1,'A1',10);
insert into netMJ values(2,'EasynetMJ',70);
insert into netMJ values(3,'Vodafone',20);
insert into netMJ values(4,'NullnetMJ',0);


insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0043,100,to_date('01.01.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0043,100,to_date('01.02.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0043,100,to_date('01.02.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.02.2017','DD.MM.YYYY'),4);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.03.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0046,10,to_date('01.03.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0046,100,to_date('01.03.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,100,to_date('01.02.2017','DD.MM.YYYY'),4);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,100,to_date('01.02.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,100,to_date('01.02.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.02.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.03.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0046,10,to_date('01.03.2017','DD.MM.YYYY'),4);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0046,100,to_date('01.03.2017','DD.MM.YYYY'),4);

insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0043,10,to_date('01.02.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0043,10,to_date('01.02.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0043,10,to_date('01.02.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0043,10,to_date('01.03.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0043,10,to_date('01.03.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0043,10,to_date('01.03.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0046,10,to_date('01.03.2017','DD.MM.YYYY'),2);

insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.03.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.03.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.03.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.03.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,100,to_date('01.04.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0043,100,to_date('01.04.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0046,10,to_date('01.04.2017','DD.MM.YYYY'),4);

insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.04.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.04.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.04.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.05.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.05.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0043,10,to_date('01.04.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0046,10,to_date('01.04.2017','DD.MM.YYYY'),4);

insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.02.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.02.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.02.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.02.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0044,10,to_date('01.03.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0043,100,to_date('01.03.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,1,0046,10,to_date('01.04.2017','DD.MM.YYYY'),2);

insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.02.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.02.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.02.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.02.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.03.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.04.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.04.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0043,10,to_date('01.05.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0043,10,to_date('01.05.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0043,10,to_date('01.06.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0043,10,to_date('01.06.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0043,10,to_date('01.06.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0043,10,to_date('01.08.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0043,10,to_date('01.08.2017','DD.MM.YYYY'),1);

insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.04.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.04.2017','DD.MM.YYYY'),4);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.04.2017','DD.MM.YYYY'),4);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.05.2017','DD.MM.YYYY'),4);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,4,0044,10,to_date('01.05.2017','DD.MM.YYYY'),4);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,4,0043,10,to_date('01.04.2017','DD.MM.YYYY'),4);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,4,0046,10,to_date('01.04.2017','DD.MM.YYYY'),4);

insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.06.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.06.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0044,10,to_date('01.06.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,4,0044,10,to_date('01.07.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,4,0044,10,to_date('01.07.2017','DD.MM.YYYY'),2);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,4,0043,10,to_date('01.03.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,4,0046,10,to_date('01.04.2017','DD.MM.YYYY'),3);

insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,3,0044,100,to_date('01.02.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,3,0044,100,to_date('01.02.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,3,0044,100,to_date('01.07.2017','DD.MM.YYYY'),4);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,3,0044,10,to_date('01.07.2017','DD.MM.YYYY'),4);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,3,0044,10,to_date('01.03.2017','DD.MM.YYYY'),4);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,3,0043,10,to_date('01.03.2017','DD.MM.YYYY'),3);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,3,0046,10,to_date('01.04.2017','DD.MM.YYYY'),3);

insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0043,20,to_date('01.06.2017','DD.MM.YYYY'),1);
insert into calls2017MJ values(seq_calls2017MJ.NEXTVAL,2,0043,70,to_date('01.06.2017','DD.MM.YYYY'),1);

commit;