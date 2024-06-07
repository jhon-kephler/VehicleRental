CREATE DATABASE vehiclerental;

\c vehiclerental;

CREATE TABLE deliveryman (
    Id SERIAL PRIMARY KEY NOT NULL,
    Name varchar(100) NOT NULL,
    CNPJ varchar(14) NOT NULL,
    Birth_Date TIMESTAMP NOT NULL,
    CNH varchar(11) NOT NULL,
    CNH_Type varchar(10) NOT NULL,
    CNH_Img varchar(250) NOT NULL
);

CREATE TABLE deliveryOrder (
    Id SERIAL PRIMARY KEY NOT NULL,
    Created_Date TIMESTAMP NOT NULL,
    Race_Value numeric NOT NULL,
    Status varchar(50) NOT NULL,
    Availability boolean NOT NULL,
    Deliveryman_Id integer REFERENCES Deliveryman(Id)
);

CREATE TABLE brands (
    Id SERIAL PRIMARY KEY,
    Brand_Name varchar(100) NOT NULL,
    Type_Vehicle varchar(10) NOT NULL
);

CREATE TABLE vehicle (
    Id SERIAL PRIMARY KEY NOT NULL,
    Year_Vehicle integer NOT NULL,
    Brand_Id integer NOT NULL REFERENCES brands(Id),
    Model varchar(50) NOT NULL,
    Plate varchar(10) NOT NULL,
    Deliveryman_Id integer REFERENCES Deliveryman(Id)
);

INSERT INTO brands (brand_name, type_vehicle) VALUES
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