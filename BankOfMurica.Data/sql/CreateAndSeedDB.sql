USE BankOfMurica;
GO

CREATE TABLE dbo.Customers
	(
		CustomerID int PRIMARY KEY IDENTITY (1, 1) NOT NULL,
		FirstName nvarchar(50) NOT NULL,
		LastName nvarchar(50) NOT NULL,
	);
GO

USE BankOfMurica;
GO


CREATE TABLE dbo.Accounts 
	(
		AccountID INT IDENTITY (1, 1) NOT NULL,
		AccountNumber INT NOT NULL,
		Balance MONEY NOT NULL,
		Pin TINYINT NOT NULL,
		CustomerID INT NOT NULL,
		CONSTRAINT [Pk_dbo.AccountId] PRIMARY KEY CLUSTERED ([AccountId] ASC), 
		CONSTRAINT [FK_dbo.Accounts_dbo.Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]) ON DELETE CASCADE
	);

CREATE TABLE dbo.Transactions
	(TransactionID int IDENTITY (1, 1) NOT NULL,
	AccountID int NOT NULL,
	TransactionType nvarchar(25) NOT NULL,
	BalanceDifference money NOT NULL,
	TransactionDate date NOT NULL,

	CONSTRAINT [PK_dbo.TransactionID] PRIMARY KEY CLUSTERED ([TransactionID] ASC),
	CONSTRAINT [FK_dbo.Transactions_dbo.Accounts_AccoundID] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Accounts] ([AccountId]) ON DELETE CASCADE
	);
GO