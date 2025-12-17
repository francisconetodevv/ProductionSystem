CREATE DATABASE ProductionControlDB;

USE ProductionControlDB;

CREATE TABLE Products (
	ProductId INT PRIMARY KEY IDENTITY(1,1),
	Code VARCHAR(50) NOT NULL UNIQUE,
	ProductName VARCHAR(100) NOT NULL,
	ProductDescription VARCHAR(250),
	UOM VARCHAR(10) NOT NULL
);

CREATE TABLE RawMaterial (
	RawMaterialId INT PRIMARY KEY IDENTITY(1,1),
	Code VARCHAR(50) NOT NULL UNIQUE,
	RawMaterialName VARCHAR(100) NOT NULL,
	StockQuantity DECIMAL(30,5) NOT NULL,
	UOM VARCHAR(10) NOT NULL
);

CREATE TABLE ProductionOrder (
	ProductionOrderId INT PRIMARY KEY IDENTITY(1,1),
	OrderNumber VARCHAR(15) NOT NULL,
	ProductId INT,
	FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
	QuantityToProduce DECIMAL(30,5) NOT NULL,
	CreationDate DATETIME NOT NULL,
	OrderStatus VARCHAR(20) NOT NULL
);

CREATE TABLE ProductionOrderRawMaterials (
	ProductionOrderId INT,
	RawMaterialId INT,
	PRIMARY KEY (ProductionOrderId, RawMaterialId),
	FOREIGN KEY (ProductionOrderId) REFERENCES ProductionOrder(ProductionOrderId),
	FOREIGN KEY (RawMaterialId) REFERENCES RawMaterial(RawMaterialId),
	ConsumedQuantity DECIMAL(30,5) NOT NULL
);

CREATE TABLE SystemLogs (
	LogId INT PRIMARY KEY IDENTITY(1,1),
	DateTimeActual DATETIME NOT NULL,
	Username VARCHAR(50) NOT NULL,
	ActionActivity VARCHAR(100) NOT NULL,
	TableName VARCHAR(100) NOT NULL,
	DescriptionValue VARCHAR(500) NOT NULL,
	Success BIT NOT NULL
);