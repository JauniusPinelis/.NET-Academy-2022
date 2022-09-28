CREATE TABLE tag (
   id SERIAL PRIMARY KEY,
   name VARCHAR(50) NOT NULL
);

INSERT INTO tag (name)
values ('food'),('grocery');

CREATE TABLE shop_tag (
  shop_id    int REFERENCES shop (id)
, tag_id int REFERENCES tag (id)
, CONSTRAINT shop_tag_pk PRIMARY KEY (shop_id, tag_id)  -- explicit pk
);

