CREATE DATABASE vehiclerental;

\c vehiclerental;

CREATE TABLE renter (
    Id SERIAL PRIMARY KEY NOT NULL,
    Name varchar(100) NOT NULL,
    Document varchar(14) NOT NULL,
    Birth_Date TimestampTz NOT NULL,
    CNH varchar(11) NULL,
    CNH_Type varchar(10) NULL,
    CNH_Img_URL varchar(250) NULL,
    Cnh_Expiration_Date TimestampTz NULL
);

CREATE TABLE brands (
    Id SERIAL PRIMARY KEY,
    Name varchar(100) NOT NULL,
    Type varchar(10) NOT NULL
);

CREATE TABLE vehicle (
    Id SERIAL PRIMARY KEY NOT NULL,
    Year integer NOT NULL,
    Plate varchar(10) NOT NULL,
    Model varchar(50) NOT NULL,
    Brand_Id integer NOT NULL REFERENCES brands(Id),
    Status varchar(50) NOT NULL,
    Availability boolean NOT NULL
);

CREATE TABLE renterorder (
    Id SERIAL PRIMARY KEY NOT NULL,
    Rental_Value numeric NOT NULL,
    Status varchar(50) NOT NULL,
    Renter_Id integer NOT NULL REFERENCES renter(Id),
    Vehicle_Id integer NOT NULL REFERENCES vehicle(Id),
    Created_Date TimestampTz NOT NULL
);

INSERT INTO brands (name, type) VALUES
('Toyota', 'car'),
('Ford', 'car'),
('Volkswagen', 'car'),
('Honda', 'car'),
('Chevrolet', 'car'),
('BMW', 'car'),
('Mercedes-Benz', 'car'),
('Audi', 'car'),
('Nissan', 'car'),
('Hyundai', 'car'),
('Kia', 'car'),
('Subaru', 'car'),
('Mazda', 'car'),
('Volvo', 'car'),
('Fiat', 'car'),
('Peugeot', 'car'),
('Renault', 'car'),
('Citroën', 'car'),
('Jeep', 'car'),
('Land Rover', 'car'),
('Tesla', 'car'),
('Porsche', 'car'),
('Lexus', 'car'),
('Jaguar', 'car'),
('Acura', 'car'),
('Infiniti', 'car'),
('Mitsubishi', 'car'),
('Buick', 'car'),
('Cadillac', 'car'),
('Chrysler', 'car'),
('Dodge', 'car'),
('GMC', 'car'),
('Lincoln', 'car'),
('Ram', 'car'),
('Aston Martin', 'car'),
('Ferrari', 'car'),
('Maserati', 'car'),
('McLaren', 'car'),
('Alfa Romeo', 'car'),
('Bentley', 'car'),
('Bugatti', 'car'),
('Lamborghini', 'car'),
('Lotus', 'car'),
('Rolls-Royce', 'car'),
('Morgan', 'car'),
('Smart', 'car'),
('Suzuki', 'car'),
('MINI', 'car'),
('Pagani', 'car'),
('Genesis', 'car'),
('Maybach', 'car'),
('Koenigsegg', 'car'),
('Rimac', 'car'),
('Honda', 'motorcycle'),
('Yamaha', 'motorcycle'),
('Suzuki', 'motorcycle'),
('Kawasaki', 'motorcycle'),
('Ducati', 'motorcycle'),
('Harley-Davidson', 'motorcycle'),
('BMW Motorrad', 'motorcycle'),
('Triumph', 'motorcycle'),
('KTM', 'motorcycle'),
('Aprilia', 'motorcycle'),
('MV Agusta', 'motorcycle'),
('Royal Enfield', 'motorcycle'),
('Indian Motorcycle', 'motorcycle'),
('Bajaj', 'motorcycle'),
('Husqvarna', 'motorcycle');