--CREATE DATABASE Bakery

CREATE TABLE Stock (
  Name VARCHAR(255) NOT NULL PRIMARY KEY
);

CREATE TABLE Ingredient (
  Name VARCHAR(255) NOT NULL PRIMARY KEY,
  Validity DATE NOT NULL,
  Amount INT NOT NULL
);

CREATE TABLE Batch (
  Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  Date DATE NOT NULL
);

CREATE TABLE Baking_Good (
  Name VARCHAR(255) NOT NULL PRIMARY KEY
);

CREATE TABLE Order (
  Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  Track VARCHAR(255)
);

CREATE TABLE Customer (
  Address_Id INT NOT NULL,
  Name VARCHAR(255) NOT NULL,
  PRIMARY KEY (Address_Id),
  FOREIGN KEY (Address_Id) REFERENCES Addres(Id)
);

CREATE TABLE Address (
  Id INT NOT NULL IDENTITY(0, 1) PRIMARY KEY,
  Street VARCHAR(255) NOT NULL,
  Number INT NOT NULL,
  Postal_code VARCHAR(255) NOT NULL,
  City VARCHAR(255) NOT NULL
);

CREATE TABLE Containss (
  Stock_Name VARCHAR(255) NOT NULL,
  Ingredient_Name VARCHAR(255) NOT NULL,
  Amount INT NOT NULL,
  FOREIGN KEY (Stock_Name) REFERENCES Stock(Name),
  FOREIGN KEY (Ingredient_Name) REFERENCES Ingredient(Name),
  PRIMARY KEY (Stock_Name, Ingredient_Name)
);

CREATE TABLE Used_In (
  Batch_Id INT NOT NULL,
  Ingredient_Name VARCHAR(255) NOT NULL,
  Amount INT NOT NULL,
  FOREIGN KEY (Batch_Id) REFERENCES Batch(Id),
  FOREIGN KEY (Ingredient_Name) REFERENCES Ingredient(Name),
  PRIMARY KEY (Batch_Id, Ingredient_Name)
);

CREATE TABLE Produces (
  Batch_Id INT NOT NULL,
  Baking_Good_Name VARCHAR(255) NOT NULL,
  Amount INT NOT NULL,
  FOREIGN KEY (Batch_Id) REFERENCES Batch(Id),
  FOREIGN KEY (Baking_Good_Name) REFERENCES Baking_Good(Name),
  PRIMARY KEY (Batch_Id, Baking_Good_Name)
);

CREATE TABLE Has (
  Order_Id INT NOT NULL,
  Baking_Good_Name VARCHAR(255) NOT NULL,
  Amount INT NOT NULL,
  FOREIGN KEY (Order_Id) REFERENCES Order(Id),
  FOREIGN KEY (Baking_Good_Name) REFERENCES Baking_Good(Name),
  PRIMARY KEY (Order_Id, Baking_Good_Name)
);

CREATE TABLE Can_Place (
  Customer_Address_Id INT NOT NULL,
  Order_Id INT NOT NULL,
  FOREIGN KEY (Customer_Address_Id) REFERENCES Customer(Address_Id),
  FOREIGN KEY (Order_Id) REFERENCES Order(Id),
  PRIMARY KEY (Customer_Address_Id, Order_Id)
);
