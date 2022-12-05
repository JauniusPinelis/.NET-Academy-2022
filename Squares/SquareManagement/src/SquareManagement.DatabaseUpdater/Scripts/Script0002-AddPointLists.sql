CREATE TABLE points (
	x int  NOT NULL,
	y int  NOT NULL,
	pointlist_id int not null,
	PRIMARY KEY(x, y, pointlist_id),
	CONSTRAINT fk_pointlist_id
      FOREIGN KEY(pointlist_id) 
	  REFERENCES point_lists(id)
);