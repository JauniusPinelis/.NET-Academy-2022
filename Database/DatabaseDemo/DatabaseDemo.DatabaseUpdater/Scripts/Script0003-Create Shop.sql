CREATE TABLE shop(
   id SERIAL PRIMARY KEY,
   name VARCHAR(50) NOT NULL,
   description varchar(200)
);

ALTER TABLE shop_items
ADD shop_id int not null;

ALTER TABLE shop_items
ADD CONSTRAINT fk_shop_item_shop FOREIGN KEY (shop_id) REFERENCES shop (id);