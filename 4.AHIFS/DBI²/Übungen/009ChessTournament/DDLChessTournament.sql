drop table ChessClub cascade constraints;
drop table Member cascade constraints;
drop table Tournament cascade constraints;
drop table Responsible cascade constraints;
drop table Participation cascade constraints;
drop table Match cascade constraints;




create table ChessClub(
  id integer,
  name varchar(50),
  address varchar(50),
  year VARCHAR(10),
  CONSTRAINT pk_id PRIMARY KEY(id)
);

create table member(
  id integer,
  FName varchar(50),
  LastName varchar(50),
  address VARCHAR(50),
  pNumber VARCHAR(50),
  eMail VARCHAR(50),
  joinDate Date,
  ranking Integer,
  AchievmentDate Date,
  nationality Varchar(50),
  IDChessClub Integer,

  CONSTRAINT pk_idMember PRIMARY KEY(id),
  CONSTRAINT fk_idChessClub FOREIGN KEY (IDChessClub) REFERENCES ChessClub(id)
);


create table Tournament(
  id integer,
  idM integer,
  startD Date,
  endD Date,
  name varchar(50),
  location varchar(50),

  CONSTRAINT pk_idTournament PRIMARY KEY(id)
);

create table Responsible(
  idT integer,
  idM integer,

  CONSTRAINT pk_idResponsible PRIMARY KEY(idT ,idM ),
  CONSTRAINT fk_idMember FOREIGN KEY (idM) REFERENCES Member(id),
  CONSTRAINT fk_idTournament FOREIGN KEY (idT) REFERENCES Tournament(id)
);

create table Participation(
  Mid integer,
  Tid integer,
  place varchar(50),

  CONSTRAINT pk_idParticipation PRIMARY KEY(Mid, Tid),
  CONSTRAINT fk_idMemberP FOREIGN KEY (Mid) REFERENCES Member(id),
  CONSTRAINT fk_idTournamentP FOREIGN KEY (Tid) REFERENCES Tournament(id)
);

create table Match(
  id integer,
  startD date,
  endD date,
  nMoves integer,
  result integer,
  pA integer,
  pB integer,
  tid integer,

  CONSTRAINT pk_idMatch PRIMARY KEY(id),
  CONSTRAINT fk_idMemberpA FOREIGN KEY (pA) REFERENCES Member(id),
  CONSTRAINT fk_idMemberpB FOREIGN KEY (pA) REFERENCES Member(id),
  CONSTRAINT fk_idTournamentM FOREIGN KEY (Tid) REFERENCES Tournament(id)
);
