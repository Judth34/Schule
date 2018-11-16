DROP TABLE village CASCADE CONSTRAINTS;

CREATE TABLE village (
	building_id integer PRIMARY KEY,
	name VARCHAR2(30),
	visitors integer,
	building SDO_GEOMETRY
);


/*****************index********************/
INSERT INTO user_sdo_geom_metadata
(	TABLE_NAME,
	COLUMN_NAME,
	DIMINFO,
	SRID
)
VALUES
(	'village',
	'building',
	SDO_DIM_ARRAY( -- 20X20 grid
		SDO_DIM_ELEMENT('X', 0, 1000, 0.5),
		SDO_DIM_ELEMENT('Y', 0, 1000, 0.5)
	),
	NULL -- SRID
);

CREATE INDEX village_idx
	ON village(building)
	INDEXTYPE IS MDSYS.SPATIAL_INDEX;


-- inserts
INSERT INTO village VALUES(1,'Kirche', 10,
	SDO_GEOMETRY(
		2003,
		NULL,
		NULL,
		SDO_ELEM_INFO_ARRAY(1,1003,1),
		SDO_ORDINATE_ARRAY(100,100, 80,120, 80,150, 100,150, 100,200, 150,200, 150,150, 200,150, 200,120, 150,120, 150,100)
	)
);

select * from village;
