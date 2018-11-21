select DECODE(grouping_id(CNAME),1,'alle',CNAME),NET_NAME, SUM(DURATION * CENT_PER_MIN) from blaschkj_calls2017
inner join Blaschkj_net on BLASCHKJ_NET.NET_ID = blaschkj_calls2017.NET_ID
inner join blaschkj_called_pers on blaschkj_called_pers.CNR = blaschkj_calls2017.CNR
group by ROLLUP(CNAME),NET_NAME;



select DECODE(grouping_id(CNAME),1,'alle',CNAME), netMJ.NETMJ_NAME, cname, sum(duration * netMJ.CENT_PER_MIN) from netMJ 
inner join CALLS2017MJ on CALLS2017MJ.NETMJ_ID = CALLS2017MJ.NETMJ_ID
inner join CALLED_PERSMJ on CALLED_PERSMJ.CNR = CALLS2017MJ.CNR
group by rollup(cname), netMJ.NETMJ_NAME;


select * from(
select co.COUNTRYMJ_ID AS COUNTRY, n.NETMJ_NAME AS NET,sum(c.DURATION) AS DAUER,
Rank() over (Partition by co.COUNTRYMJ_ID order by sum(c.DURATION) DESC,-3)as rank from CALLS2017MJ c
join countryMJ co on c.COUNTRYMJ_ID = co.COUNTRYMJ_ID
join netMJ n on c.NETMJ_ID = n.NETMJ_ID
group by co.COUNTRYMJ_ID,n.NETMJ_NAME)
where rank in (1,2);


CREATE OR REPLACE VIEW viewJudth AS
SELECT TO_CHAR(ca.CALL_DATE, 'MM') AS "Month", SUM(n.cent_per_min * ca.duration) AS "Costs",
FIRST_VALUE(SUM(n.cent_per_min * ca.duration)) OVER (ORDER BY TO_CHAR(ca.call_date, 'MM') ROWS BETWEEN 1 PRECEDING AND 0 FOLLOWING ) AS costs_former_month,
(SUM(n.cent_per_min * ca.duration) - FIRST_VALUE(SUM(n.cent_per_min* ca.duration)) OVER (ORDER BY TO_CHAR(ca.call_date, 'MM') ROWS BETWEEN 1 PRECEDING AND 0 FOLLOWING )) AS "Change" 
FROM CALLS2017MJ ca 
JOIN net n on ca.NETMJ_ID = n.net_id
WHERE ca.COUNTRYMJ_ID = (select countryMJ_id FROM countryMJ WHERE countryMJ_name LIKE 'Austria') AND TO_CHAR(ca.call_date, 'YYYY') LIKE '2017'
GROUP BY TO_CHAR(ca.call_date, 'MM'); 
SELECT * FROM viewJudth WHERE "Change"  = (select MIN("Change") from viewJudth);