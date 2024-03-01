-- 1:
SELECT * 
FROM BkStock;

-- 2:
SELECT *
FROM BkAddress;

-- 3:
SELECT * 
FROM BakingGood_Order
WHERE OrderId = 1;

-- 4:
SELECT IngredientName
FROM Ingredient_Batch
WHERE BatchId = 1;

-- 5:
SELECT BkDeliveryTrackId 
FROM BkOrder
WHERE Id = 1;

-- 6:
SELECT *
FROM BkBakingGood;

-- 7:
SELECT AVG([Delay]) AS AverageDelay
FROM BkBatch;