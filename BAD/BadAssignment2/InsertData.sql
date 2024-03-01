INSERT INTO BkIngredient
VALUES ('Red salami', 17);

INSERT INTO BkBakingGood
VALUES ('Salamikage', 2, 30);

INSERT INTO BkCustomer
VALUES ('Walmaaaart');

INSERT INTO BkAddress
VALUES (140, 'Snogebeksvej', 8210, 'Aarhus V');

INSERT INTO BkDelivery
VALUES (1, '2023-03-01', 140, 'Snogebeksvej', 8210);

INSERT INTO BkStock
VALUES ('Red salami', 17);

INSERT INTO BkOrder(BkCustomerName, BkDeliveryTrackId)
VALUES ('Walmaaaart', 1);

INSERT INTO BkBatch([Delay], BkOrderId)
VALUES (3, 1);

INSERT INTO BakingGood_Order
VALUES (1, 'Salamikage');

INSERT INTO BakingGood_Ingredient
VALUES ('Salamikage', 'Red salami');

INSERT INTO Ingredient_Batch
VALUES ('Red salami', 1);