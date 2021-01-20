
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/20/2021 23:49:03
-- Generated from EDMX file: E:\BMWportal_260918\DataModel\WebApiDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [omindori_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Counters'
CREATE TABLE [dbo].[Counters] (
    [sno] int IDENTITY(1,1) NOT NULL,
    [counts] int  NULL,
    [createDate] datetime  NULL
);
GO

-- Creating table 'DepositFileAttachmentDetails'
CREATE TABLE [dbo].[DepositFileAttachmentDetails] (
    [PK_AttachmenDetailIdDep] int IDENTITY(1,1) NOT NULL,
    [Sno] int  NULL,
    [FK_DeptId] int  NULL,
    [UserName] nvarchar(20)  NULL,
    [FilePath] nvarchar(100)  NULL,
    [CreateDate] datetime  NULL
);
GO

-- Creating table 'Deposits'
CREATE TABLE [dbo].[Deposits] (
    [PK_DepositId] int  NOT NULL,
    [GivenBy] nvarchar(50)  NULL,
    [ReceivedBy] nvarchar(50)  NULL,
    [ReceivedDate] datetime  NULL,
    [Description] varchar(1000)  NULL,
    [ReceivingMode] nvarchar(10)  NULL,
    [CRNNo] int  NULL,
    [CRNDate] datetime  NULL,
    [Amount] int  NULL,
    [DepositAcc] nvarchar(5)  NULL,
    [CreateDate] datetime  NULL,
    [FilePath] nvarchar(500)  NULL,
    [AdjustedAmount] int  NULL,
    [BalanceAmount] int  NULL
);
GO

-- Creating table 'ExpenseClearings'
CREATE TABLE [dbo].[ExpenseClearings] (
    [PK_TranId] int  NOT NULL,
    [ClearingDate] datetime  NULL,
    [ClearedBy] nvarchar(50)  NULL,
    [ReceiptMode] nvarchar(10)  NULL,
    [Amount] int  NULL
);
GO

-- Creating table 'Expenses'
CREATE TABLE [dbo].[Expenses] (
    [PK_ExpId] int IDENTITY(1,1) NOT NULL,
    [ExpensesBy] nvarchar(50)  NULL,
    [Description] nvarchar(1000)  NULL,
    [ExpDate] datetime  NULL,
    [ExpType] nvarchar(500)  NULL,
    [ExpenseMode] nvarchar(50)  NULL,
    [ExpCRNNo] nvarchar(50)  NULL,
    [ExpCRNDate] datetime  NULL,
    [TotalClearAmt] int  NULL,
    [IsCleared] bit  NULL,
    [FilePath] nvarchar(200)  NULL,
    [Owner] nvarchar(5)  NULL,
    [CrearDate] datetime  NULL,
    [FK_DepositId] int  NULL
);
GO

-- Creating table 'FileAttachmentDetails'
CREATE TABLE [dbo].[FileAttachmentDetails] (
    [PK_AttachmenDetailId] int IDENTITY(1,1) NOT NULL,
    [Sno] int  NULL,
    [FK_ExpId] int  NULL,
    [UserName] nvarchar(20)  NULL,
    [FilePath] nvarchar(100)  NULL,
    [CreateDate] datetime  NULL
);
GO

-- Creating table 'HospitalMasters'
CREATE TABLE [dbo].[HospitalMasters] (
    [PK_HospitalId] int IDENTITY(1,1) NOT NULL,
    [HospitalName] nvarchar(100)  NULL,
    [NameOfOwner] nvarchar(50)  NULL,
    [Address1] nvarchar(100)  NULL,
    [Address2] nvarchar(100)  NULL,
    [City] nvarchar(50)  NULL,
    [District] nvarchar(50)  NULL,
    [State] nvarchar(50)  NULL,
    [ContactPerson] nvarchar(100)  NULL,
    [MobileNo] nvarchar(20)  NULL,
    [EmailId] nvarchar(50)  NULL,
    [BedNos] int  NULL,
    [RegDate] datetime  NULL,
    [UserName] nvarchar(10)  NULL,
    [Password] nvarchar(10)  NULL,
    [ConfirmPassword] nvarchar(10)  NULL,
    [IsActive] bit  NULL,
    [ActiveDate] datetime  NULL,
    [UserType] int  NULL,
    [GSTINNo] nvarchar(50)  NULL,
    [OWNER] nvarchar(5)  NULL,
    [PlantId] int  NULL,
    [UnitType] nvarchar(2)  NULL,
    [Pincode] int  NULL,
    [RenewDate] datetime  NULL
);
GO

-- Creating table 'HospitalTransactions'
CREATE TABLE [dbo].[HospitalTransactions] (
    [PK_UserId] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(20)  NULL,
    [HospitalName] nvarchar(50)  NULL,
    [Address] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [District] nvarchar(50)  NULL,
    [State] nvarchar(50)  NULL,
    [WasteWeight] decimal(18,2)  NULL,
    [WasteDate] datetime  NULL,
    [RedBag] decimal(18,2)  NULL,
    [YellowBag] decimal(18,2)  NULL,
    [BlueBag] decimal(18,2)  NULL,
    [WhiteBag] decimal(18,2)  NULL,
    [CodeAll] nvarchar(max)  NULL,
    [CodeRed] nvarchar(max)  NULL,
    [CodeYellow] nvarchar(max)  NULL,
    [CodeBlue] nvarchar(max)  NULL,
    [CodeWhite] nvarchar(max)  NULL,
    [RedBagNos] smallint  NULL,
    [BlueBagNos] smallint  NULL,
    [YellowBagNos] smallint  NULL,
    [WhiteBagNos] smallint  NULL,
    [AllImgPath] nvarchar(200)  NULL,
    [RedImgPath] nvarchar(200)  NULL,
    [YellowImgPath] nvarchar(200)  NULL,
    [BlueImgPath] nvarchar(200)  NULL,
    [WhiteImgPath] nvarchar(200)  NULL,
    [TotalString] nvarchar(50)  NULL,
    [SeqNo1] nvarchar(10)  NULL,
    [SeqNo2] nvarchar(10)  NULL,
    [SeqNo3] nvarchar(10)  NULL,
    [SeqNo4] nvarchar(10)  NULL,
    [IsDeleted] bit  NULL,
    [ReportFrom] nvarchar(5)  NULL
);
GO

-- Creating table 'PaymentDetails'
CREATE TABLE [dbo].[PaymentDetails] (
    [PK_PaymentDetailId] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [UserName] nvarchar(10)  NULL,
    [BankName] nvarchar(50)  NULL,
    [RegistrationFee] int  NULL,
    [PaymentDate] datetime  NULL,
    [ChequeDate] datetime  NULL,
    [ChequeNo] nvarchar(30)  NULL,
    [PaymentMode] nvarchar(10)  NULL,
    [GSTINNo] nvarchar(50)  NULL,
    [bmwPlusWebsite] int  NULL,
    [bmwAmt] decimal(6,0)  NULL,
    [WebDev] decimal(6,0)  NULL,
    [Domain] decimal(6,0)  NULL,
    [Hosting] decimal(6,0)  NULL,
    [Discount] decimal(6,0)  NULL,
    [Total] decimal(6,0)  NULL,
    [Misc] decimal(6,0)  NULL,
    [GTotal] decimal(6,0)  NULL,
    [Owner] nvarchar(5)  NULL
);
GO

-- Creating table 'UserMasters'
CREATE TABLE [dbo].[UserMasters] (
    [PK_UserId] int  NOT NULL,
    [UserName] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [ConfirmPassword] nvarchar(50)  NULL,
    [HospitalName] nvarchar(50)  NULL,
    [Address] nvarchar(50)  NULL,
    [FK_CityId] int  NULL,
    [FK_StateId] int  NULL,
    [IsActive] bit  NULL,
    [UserType] int  NULL
);
GO

-- Creating table 'CityMasters'
CREATE TABLE [dbo].[CityMasters] (
    [PK_ID] int  NOT NULL,
    [CityName] nvarchar(255)  NULL,
    [DistrictName] nvarchar(255)  NULL,
    [StateName] nvarchar(255)  NULL
);
GO

-- Creating table 'ARs'
CREATE TABLE [dbo].[ARs] (
    [InternalKey] int  NOT NULL,
    [Code] varchar(16)  NOT NULL,
    [Name] varchar(40)  NULL,
    [SPerson] varchar(10)  NULL,
    [PAddress1] varchar(25)  NULL,
    [PAddress2] varchar(25)  NULL,
    [PAddress3] varchar(25)  NULL,
    [PPostCode] varchar(11)  NULL,
    [Phone] varchar(15)  NULL,
    [Fax] varchar(15)  NULL,
    [Bank] varchar(4)  NULL,
    [Branch] varchar(30)  NULL,
    [CrLimit_] decimal(19,4)  NULL,
    [CrLimitTime] smallint  NULL,
    [Profile] varchar(13)  NULL,
    [Instructions] varchar(max)  NULL,
    [BillTo] int  NULL,
    [OweFuture] decimal(19,4)  NULL,
    [OweCurrent] decimal(19,4)  NULL,
    [Owe30] decimal(19,4)  NULL,
    [Owe60] decimal(19,4)  NULL,
    [Owe90] decimal(19,4)  NULL,
    [SalesFuture] decimal(19,4)  NULL,
    [SalesMTD] decimal(19,4)  NULL,
    [SalesYTD] decimal(19,4)  NULL,
    [SalesLastYr] decimal(19,4)  NULL,
    [COSalesFuture] decimal(19,4)  NULL,
    [COSalesMTD] decimal(19,4)  NULL,
    [COSalesYTD] decimal(19,4)  NULL,
    [COSalesLastYr] decimal(19,4)  NULL,
    [OnOrder] decimal(19,4)  NULL,
    [LastRecAmt] decimal(19,4)  NULL,
    [BFBal] decimal(19,4)  NULL,
    [UnAlloc] decimal(19,4)  NULL,
    [DateLastPurch] datetime  NULL,
    [DateLastPay] datetime  NULL,
    [DateOpened] datetime  NULL,
    [Interest] float  NULL,
    [ServiceFee] decimal(19,4)  NULL,
    [SType] varchar(4)  NULL,
    [TaxNo] varchar(15)  NULL,
    [PriceLevel] varchar(4)  NULL,
    [TermType] varchar(1)  NULL,
    [TermDays] smallint  NULL,
    [MinInvAmt4Disc] decimal(19,4)  NULL,
    [PrintBalOnInvoices] bit  NOT NULL,
    [PrintSetlDiscOnInvoices] bit  NOT NULL,
    [PrintDiscOnStatements] bit  NOT NULL,
    [PrintInvoices] bit  NOT NULL,
    [PrintDockets] bit  NOT NULL,
    [PrintInvCrSummary] bit  NOT NULL,
    [Notes] varchar(max)  NULL,
    [StopCredit] bit  NOT NULL,
    [CashAC] bit  NOT NULL,
    [ACExpiry] datetime  NULL,
    [GSTExInv] bit  NOT NULL,
    [InvoiceLayout] varchar(4)  NULL,
    [FaxStatement] bit  NOT NULL,
    [PrintStatement] bit  NOT NULL,
    [FaxInvoice] bit  NOT NULL,
    [PO] bit  NOT NULL,
    [STaxJurisdiction] varchar(4)  NULL,
    [TaxCode] varchar(4)  NULL,
    [AreaCode] varchar(4)  NULL,
    [Layby] bit  NOT NULL,
    [Email] varchar(255)  NULL,
    [GSTFuture] decimal(19,4)  NULL,
    [GSTMTD] decimal(19,4)  NULL,
    [GSTYTD] decimal(19,4)  NULL,
    [GSTLastYr] decimal(19,4)  NULL,
    [DateLastUpdate] datetime  NULL,
    [LoyaltyCard] varchar(20)  NULL,
    [ReceiptLayout2] varchar(5)  NULL,
    [ReceiptLayout3] varchar(5)  NULL,
    [InvoiceLayout2] varchar(5)  NULL,
    [InvoiceLayout3] varchar(5)  NULL,
    [ReceiptLayout] varchar(5)  NULL,
    [PrintReceipts] bit  NULL,
    [PrintReceiptDockets] bit  NULL,
    [origin] int  NULL,
    [ReplicatedDateLastUpdate] datetime  NULL,
    [PriceLevel2] varchar(4)  NULL,
    [MinInvoiceAmount] decimal(19,4)  NULL,
    [cartageCalcMethod] varchar(30)  NULL,
    [cartageCode] varchar(30)  NULL,
    [LastEditedBy] varchar(255)  NULL,
    [LoyaltyBalance] int  NOT NULL,
    [accruePoints] bit  NULL,
    [InvoiceCopies] int  NOT NULL,
    [ReceiptCopies] int  NOT NULL,
    [ForceChargedByAtPOS] bit  NOT NULL,
    [SignatureOnInvoice] bit  NOT NULL,
    [UseBillToPricing] bit  NULL,
    [eMailInvoice] bit  NOT NULL,
    [eMailQuotes] bit  NOT NULL,
    [PromptAtPOSForEmailQuotes] bit  NOT NULL,
    [isBranch] bit  NOT NULL,
    [eMailStatementLayout] varchar(255)  NULL,
    [eMailStmtRequest] datetime  NULL,
    [eMailStmtSent] datetime  NULL,
    [eMailStatements] bit  NOT NULL,
    [eMailForStatements] varchar(255)  NOT NULL,
    [BaseSettlement] decimal(18,6)  NOT NULL,
    [takeCODeposits] bit  NOT NULL,
    [eMailInvoiceToBillTo] bit  NOT NULL,
    [BranchCreated] varchar(10)  NULL,
    [DonationRounding] bit  NULL,
    [DonationRoundingVal] decimal(19,4)  NULL,
    [BFDeferred] decimal(19,4)  NULL,
    [PromptTaxInvoice] bit  NULL,
    [PopupUserFieldsAtPos] bit  NULL,
    [BPayNo] varchar(50)  NULL,
    [TermDaysYN] bit  NOT NULL,
    [TermNoOfMonth] int  NULL,
    [PreventAutoAllocate] bit  NOT NULL,
    [PresentSubaccountListAtPos] bit  NULL,
    [eMailReceipts] bit  NOT NULL,
    [UseBillToCreditLimit] bit  NULL,
    [HideSalePriceFromSignature] bit  NOT NULL,
    [EditedBy] varchar(50)  NULL,
    [eMailForQuotes] varchar(255)  NOT NULL,
    [eMailForReceipts] varchar(255)  NOT NULL,
    [LastSocketUpdate] datetime  NULL,
    [nonEmailStmtsSent] datetime  NULL,
    [PromptForDeliveryDate] bit  NOT NULL,
    [PinpointUpdateAction] char(1)  NOT NULL,
    [BulkEmailableStmtSent] datetime  NULL,
    [AccType] varchar(10)  NULL,
    [LoyaltyEnrolment] datetime  NULL,
    [Locked] bit  NULL,
    [TaskColour] bigint  NULL
);
GO

-- Creating table 'UserTypeMasters'
CREATE TABLE [dbo].[UserTypeMasters] (
    [PK_UserTypeId] int IDENTITY(1,1) NOT NULL,
    [UserTypeName] nvarchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [IsIncenerator] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [sno] in table 'Counters'
ALTER TABLE [dbo].[Counters]
ADD CONSTRAINT [PK_Counters]
    PRIMARY KEY CLUSTERED ([sno] ASC);
GO

-- Creating primary key on [PK_AttachmenDetailIdDep] in table 'DepositFileAttachmentDetails'
ALTER TABLE [dbo].[DepositFileAttachmentDetails]
ADD CONSTRAINT [PK_DepositFileAttachmentDetails]
    PRIMARY KEY CLUSTERED ([PK_AttachmenDetailIdDep] ASC);
GO

-- Creating primary key on [PK_DepositId] in table 'Deposits'
ALTER TABLE [dbo].[Deposits]
ADD CONSTRAINT [PK_Deposits]
    PRIMARY KEY CLUSTERED ([PK_DepositId] ASC);
GO

-- Creating primary key on [PK_TranId] in table 'ExpenseClearings'
ALTER TABLE [dbo].[ExpenseClearings]
ADD CONSTRAINT [PK_ExpenseClearings]
    PRIMARY KEY CLUSTERED ([PK_TranId] ASC);
GO

-- Creating primary key on [PK_ExpId] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [PK_Expenses]
    PRIMARY KEY CLUSTERED ([PK_ExpId] ASC);
GO

-- Creating primary key on [PK_AttachmenDetailId] in table 'FileAttachmentDetails'
ALTER TABLE [dbo].[FileAttachmentDetails]
ADD CONSTRAINT [PK_FileAttachmentDetails]
    PRIMARY KEY CLUSTERED ([PK_AttachmenDetailId] ASC);
GO

-- Creating primary key on [PK_HospitalId] in table 'HospitalMasters'
ALTER TABLE [dbo].[HospitalMasters]
ADD CONSTRAINT [PK_HospitalMasters]
    PRIMARY KEY CLUSTERED ([PK_HospitalId] ASC);
GO

-- Creating primary key on [PK_UserId] in table 'HospitalTransactions'
ALTER TABLE [dbo].[HospitalTransactions]
ADD CONSTRAINT [PK_HospitalTransactions]
    PRIMARY KEY CLUSTERED ([PK_UserId] ASC);
GO

-- Creating primary key on [PK_PaymentDetailId] in table 'PaymentDetails'
ALTER TABLE [dbo].[PaymentDetails]
ADD CONSTRAINT [PK_PaymentDetails]
    PRIMARY KEY CLUSTERED ([PK_PaymentDetailId] ASC);
GO

-- Creating primary key on [PK_UserId] in table 'UserMasters'
ALTER TABLE [dbo].[UserMasters]
ADD CONSTRAINT [PK_UserMasters]
    PRIMARY KEY CLUSTERED ([PK_UserId] ASC);
GO

-- Creating primary key on [PK_ID] in table 'CityMasters'
ALTER TABLE [dbo].[CityMasters]
ADD CONSTRAINT [PK_CityMasters]
    PRIMARY KEY CLUSTERED ([PK_ID] ASC);
GO

-- Creating primary key on [InternalKey] in table 'ARs'
ALTER TABLE [dbo].[ARs]
ADD CONSTRAINT [PK_ARs]
    PRIMARY KEY CLUSTERED ([InternalKey] ASC);
GO

-- Creating primary key on [PK_UserTypeId] in table 'UserTypeMasters'
ALTER TABLE [dbo].[UserTypeMasters]
ADD CONSTRAINT [PK_UserTypeMasters]
    PRIMARY KEY CLUSTERED ([PK_UserTypeId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------