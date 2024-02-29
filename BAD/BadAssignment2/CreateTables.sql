CREATE TABLE BkIngredient (
  [Name] CHAR(100) PRIMARY KEY NOT NULL,
  Amount INT
);

CREATE TABLE BkBakingGood (
  [Name] CHAR(100) PRIMARY KEY,
  Amount INT,
  Validity INT
);

CREATE TABLE BkCustomer (
  [Name] CHAR(100) PRIMARY KEY
);

CREATE TABLE BkAddress (
  [Number] INT NOT NULL,
  Street CHAR(100),
  PostalCode INT NOT NULL,
  City CHAR(100) NOT NULL,
  PRIMARY KEY ([Number], Street, PostalCode)
);

CREATE TABLE BkDelivery(
    TrackId INT,
    [Date] DATE,
    [Number] INT,
    Street CHAR(100),
    PostalCode INT,
    PRIMARY KEY (TrackId, [Number], Street, PostalCode),
    FOREIGN KEY ([Number]) REFERENCES BkAddress,
    FOREIGN KEY (Street) REFERENCES BkAddress,
    FOREIGN KEY (PostalCode) REFERENCES BkAddress
);

CREATE TABLE BkStock (
  [Name] CHAR(100) PRIMARY KEY,
  Amount INT NOT NULL,
  FOREIGN KEY ([Name]) REFERENCES BkIngredient
);

CREATE TABLE BkOrder (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  BkCustomerName CHAR(100),
  BkDeliveryTrackId INT,
  FOREIGN KEY (BkCustomerName) REFERENCES BkCustomer,
  FOREIGN KEY (BkDeliveryTrackId) REFERENCES BkDelivery
);

CREATE TABLE BkBatch (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  [Delay] INT,
  BkOrderId INT,
  FOREIGN KEY (BkOrderId) REFERENCES BkOrder
);

-- Relations:

CREATE TABLE BakingGood_Order(
  OrderId INT,
  BakingGoodName CHAR(100),
  PRIMARY KEY (OrderId, BakingGoodName),
  FOREIGN KEY (OrderId) REFERENCES BkOrder,
  FOREIGN KEY (BakingGoodName) REFERENCES BkBakingGood
);

CREATE TABLE BakingGood_Ingredient(
  BakingGoodName CHAR(100),
  IngredientName CHAR(100),
  PRIMARY KEY (BakingGoodName, IngredientName),
  FOREIGN KEY (BakingGoodName) REFERENCES BkBakingGood,
  FOREIGN KEY (IngredientName) REFERENCES BkIngredient
);

CREATE TABLE Ingredient_Batch(
  IngredientName CHAR(100),
  BatchId INT,
  PRIMARY KEY (IngredientName, BatchId),
  FOREIGN KEY (IngredientName) REFERENCES BkIngredient,
  FOREIGN KEY (BatchId) REFERENCES BkBatch
);