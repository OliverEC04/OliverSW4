-- Del 1 og 2:

-- CREATE TABLE Address(
--     cuh_id INT IDENTITY(1,1),
--     num INT, 
--     street CHAR(100), 
--     postal_code INT, 
--     PRIMARY KEY (cuh_id)
-- );

-- CREATE TABLE Customer(
--     cuh_id INT, 
--     cuh_name CHAR(100), 
--     age INT, 
--     PRIMARY KEY(cuh_id),
--     FOREIGN KEY (cuh_id) REFERENCES Address(cuh_id) ON UPDATE CASCADE
-- );

-- Del 3:

-- CREATE TABLE Customer(
--     cuh_id INT IDENTITY(1,1), 
--     cuh_name CHAR(100), 
--     age INT, 
--     PRIMARY KEY(cuh_id)
-- );

-- CREATE TABLE Oorder(
--     cuh_id INT,
--     PRIMARY KEY(cuh_id),
--     FOREIGN KEY (cuh_id) REFERENCES Customer(cuh_id) ON UPDATE CASCADE
-- );

-- Del 4:

CREATE TABLE Oorder(
    cuh_id INT,
    PRIMARY KEY(cuh_id),
    FOREIGN KEY (cuh_id) REFERENCES Customer(cuh_id) ON UPDATE CASCADE
);

CREATE TABLE ejtems(

);
