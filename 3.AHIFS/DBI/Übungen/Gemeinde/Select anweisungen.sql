select name, Count(lbeschr) from mitglied
inner join Leistung on mitglied.idM = idBeamter 
where beamterflag = 1
group by name;


select * from mitglied
inner join Leistung on mitglied.idM = idBurger 
where name = 'A. Sterix' 
and 
datum > to_date('01.05.2014', 'DD.MM.YYYY') 
and 
datum < to_date('31.05.2014', 'DD.MM.YYYY');


