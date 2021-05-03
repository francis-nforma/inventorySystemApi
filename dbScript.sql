CREATE TABLE challenge.car
(
   	id serial primary key,
   	make text NOT NULL,
   	model text NOT NULL,
	series text NOT NULL,
   	year integer NOT NULL,
    active boolean NOT NULL,
	created_by text default current_user,
   	created_date timestamp with time zone default current_timestamp,
   	last_updated_date timestamp with time zone NULL
)

CREATE TABLE challenge.dealer
(
   	id serial primary key,
   	dealer_name text NOT NULL,
	address_line1 text NULL,
	address_line2 text NULL,
	address_suburb text NULL,
	address_state text NULL,
	address_postcode integer NULL,
   	contact_phone text NULL,
   	active boolean NOT NULL,
	created_by text default current_user,
   	created_date timestamp with time zone default current_timestamp,
   	last_updated_date timestamp with time zone NULL
)

CREATE TABLE challenge.inventory
(
    id serial primary key,
   	car_id integer NOT NULL,
   	branch_id integer NOT NULL,
   	quantity integer NOT NULL,
   	created_date timestamp with time zone default current_timestamp,
    created_by text default current_user,
   	last_updated_date timestamp with time zone NULL,
   	CONSTRAINT fk_car FOREIGN KEY(car_id) REFERENCES car(id),
	CONSTRAINT fk_dealer FOREIGN KEY(dealer_id) REFERENCES dealer(id)
)

drop table challenge."Inventory";
drop table challenge."InventoryTransactions";
drop table challenge."Car";
drop table challenge."Dealer";
drop table 

-- test data to be inserted into the dealer table
insert into challenge."Dealer" ("Dealer_Name","Address_Line1","Address_Line2","Address_Suburb","Address_State","Address_Postcode","Contact_Number")
select 'Mercedes-Benz Melbourne','135 Kings Way','','South Melbourne','VIC',3205,'(03) 9690 8833'
union
select 'Mercedes-Benz Toorak','1 Carters Ave','','Toorak','VIC',3142,'(03) 8825 5000'
union
select '3 Point Motors Fairfield','484 Heidelberg Rd','','Fairfield','VIC',3078,'03) 9489 7777'
union
select 'Silver Star Motors','835 Doncaster Rd','','Doncaster','VIC',3108,'(03) 8848 1266'
union
select '3 Point Motors Mercedes-Benz','128 Denmark St','','Kew','Vic',3101,'+61398536669';

-- test data for cars
insert into challenge."Car" ("Make","Model","Series","Year")
select 'Mercedes-Benz','A-Class','A170',2006
Union
select 'Mercedes-Benz','A-Class','A200',2007
Union
select 'Mercedes-Benz','A-Class','A200',2005
Union
select 'Mercedes-Benz','A-Class','A200',2010
Union
select 'Mercedes-Benz','A-Class','A180',2013
Union
select 'Mercedes-Benz','E-Class','E200',2017
Union
select 'Mercedes-Benz','E-Class','E250',2007
Union
select 'Mercedes-Benz','E-Class','E320',2003
Union
select 'Mercedes-Benz','E-Class','E400',2013
Union
select 'Mercedes-Benz','E-Class','E63',2020
Union
select 'Mercedes-Benz','C-Class','C250',2017
Union
select 'Mercedes-Benz','C-Class','C300',2018
Union
select 'Mercedes-Benz','C-Class','C63',2016
Union
select 'Mercedes-Benz','C-Class','C200',2020
Union
select 'Mercedes-Benz','C-Class','C43',2019;

-- setup the initial inventory
-- Branch - Mercedes-Benz Melbourne
insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'E320' and "Year" = 2003), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='Mercedes-Benz Melbourne'),
5;

insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'A200' and "Year" = 2010), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='Mercedes-Benz Melbourne'),
10;

insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'E63' and "Year" = 2020), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='Mercedes-Benz Melbourne'),
2;

-- Branch - Mercedes-Benz Toorak
insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'C200' and "Year" = 2020), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='Mercedes-Benz Toorak'),
7;

insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'E400' and "Year" = 2013), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='Mercedes-Benz Toorak'),
2;

insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'A180' and "Year" = 2013), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='Mercedes-Benz Toorak'),
5;

-- Branch - 3 Point Motors Fairfield
insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'A200' and "Year" = 2005), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='3 Point Motors Fairfield'),
7;

insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'E63' and "Year" = 2020), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='3 Point Motors Fairfield'),
3;

insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'C250' and "Year" = 2017), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='3 Point Motors Fairfield'),
2;

-- Branch - Silver Star Motors
insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'C250' and "Year" = 2017), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='Silver Star Motors'),
3;

insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'A200' and "Year" = 2005), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='Silver Star Motors'),
2;

insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'E400' and "Year" = 2013), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='Silver Star Motors'),
1;

-- Branch - 3 Point Motors Mercedes-Benz
insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'C250' and "Year" = 2017), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='3 Point Motors Mercedes-Benz'),
3;

insert into challenge."Inventory" ("CarId","DealerId","Quantity")
select
(select "Id" from challenge."Car" where "Make" = 'Mercedes-Benz' and "Series" = 'A200' and "Year" = 2005), 
(select "Id" from challenge."Dealer" where "Dealer_Name"='3 Point Motors Mercedes-Benz'),
4;