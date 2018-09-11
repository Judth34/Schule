drop table auto cascade constraints;

create table besitzer (
  SVNR Integer,
  bName Varchar(50),
  CONSTRAINT pk_SVNR PRIMARY KEY (SVNR)
);

create table Car (
  FGNR Integer,
  marke varchar(50),
  typ varchar (50),
  b_id integer,
  constraint pk_fgnr primary key (fgnr),
  CONSTRAINT fk_bid FOREIGN KEY (b_id) references besitzer(svnr)

);


select * from car;
