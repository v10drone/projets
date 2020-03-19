SET FEEDBACK OFF
SET LINESIZE 150
SET PAGESIZE 40

ALTER SESSION SET NLS_DATE_FORMAT = 'dd/mm/yyyy';

PROMPT --> DEBUT DU SCRIPT

REM ** Requête SQL de création des tables **

DROP TABLE amateur CASCADE CONSTRAINTS PURGE
/
DROP TABLE programmeur CASCADE CONSTRAINTS PURGE
/

PROMPT CREATION DES TABLES

CREATE TABLE amateur
(
login VARCHAR2(25) NOT NULL,
mdp VARCHAR2(30) NOT NULL,
mail VARCHAR2(30) NOT NULL
)
/

CREATE TABLE programmeur
(
login_p VARCHAR2(25) NOT NULL,
mdp_p VARCHAR2(30) NOT NULL,
mail VARCHAR2(30) NOT NULL,
url VARCHAR2(50) NOT NULL
)
/

PROMPT INSERTION DE AMATEURS

insert into amateur (login, mdp, mail)
values('dabi','dabi', 'dabi@gmail.com');
insert into amateur (login, mdp, mail)
values('daran','daran', 'daran@hotmail.com');
insert into amateur (login, mdp, mail)
values('bintou','bintou', 'bintou@gmail.com');
insert into amateur (login, mdp, mail)
values('guillaume','guillaume', 'guillaume@gmail.com');
insert into amateur (login, mdp, mail)
values('macoura','macoura', 'macoura@hotmail.fr');

PROMPT INSERTION DE PROGRAMMEURS

insert into programmeur (login_p, mdp_p, mail, url)
values('examples','dabi', 'dabi@gmail.com', 'ftp://localhost:2121/');
insert into programmeur (login_p, mdp_p, mail, url)
values('daran','daran', 'daran@gmail.com', 'ftp://localhost:2121/');

PROMPT --> SCRIPT COMPLETEMENT TERMINE

commit;

SET FEEDBACK ON
