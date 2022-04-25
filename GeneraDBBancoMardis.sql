SELECT *
  FROM BankMardis.CUENTA;
SELECT *
  FROM BankMardis.CLIENTE;
SELECT *
  FROM BankMardis.PERSONA;
SELECT *
  FROM BankMardis.TRANSACCION;

--DROP TABLE BankMardis.transaccion
--DROP TABLE BankMardis.Cuenta
--DROP TABLE BankMardis.cliente
--DROP TABLE BankMardis.persona

/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     24/4/2022 18:29:16                           */
/*==============================================================*/

--CREATE SCHEMA BankMardis.

IF EXISTS (   SELECT 1
                FROM sys.sysreferences r
                JOIN sys.sysobjects o
                  ON (   o.id   = r.constid
                   AND   o.type = 'F')
               WHERE r.fkeyid = OBJECT_ID('CLIENTE')
                 AND o.name   = 'FK_CLIENTE_RELATIONS_PERSONA')
    ALTER TABLE BankMardis.CLIENTE
    DROP CONSTRAINT FK_CLIENTE_RELATIONS_PERSONA;
GO

IF EXISTS (   SELECT 1
                FROM sys.sysreferences r
                JOIN sys.sysobjects o
                  ON (   o.id   = r.constid
                   AND   o.type = 'F')
               WHERE r.fkeyid = OBJECT_ID('CUENTA')
                 AND o.name   = 'FK_CUENTA_RELATIONS_CLIENTE')
    ALTER TABLE BankMardis.CUENTA DROP CONSTRAINT FK_CUENTA_RELATIONS_CLIENTE;
GO

IF EXISTS (   SELECT 1
                FROM sys.sysreferences r
                JOIN sys.sysobjects o
                  ON (   o.id   = r.constid
                   AND   o.type = 'F')
               WHERE r.fkeyid = OBJECT_ID('TRANSACCION')
                 AND o.name   = 'FK_TRANSACC_RELATIONS_CUENTA')
    ALTER TABLE BankMardis.TRANSACCION
    DROP CONSTRAINT FK_TRANSACC_RELATIONS_CUENTA;
GO

IF EXISTS (   SELECT 1
                FROM sysindexes
               WHERE id    = OBJECT_ID('CLIENTE')
                 AND name  = 'RELATIONSHIP_1_FK'
                 AND indid > 0
                 AND indid < 255)
    DROP INDEX CLIENTE.RELATIONSHIP_1_FK;
GO

IF EXISTS (   SELECT 1
                FROM sysobjects
               WHERE id   = OBJECT_ID('CLIENTE')
                 AND type = 'U')
    DROP TABLE BankMardis.CLIENTE;
GO

IF EXISTS (   SELECT 1
                FROM sysindexes
               WHERE id    = OBJECT_ID('CUENTA')
                 AND name  = 'RELATIONSHIP_2_FK'
                 AND indid > 0
                 AND indid < 255)
    DROP INDEX CUENTA.RELATIONSHIP_2_FK;
GO

IF EXISTS (   SELECT 1
                FROM sysobjects
               WHERE id   = OBJECT_ID('CUENTA')
                 AND type = 'U')
    DROP TABLE BankMardis.CUENTA;
GO

IF EXISTS (   SELECT 1
                FROM sysobjects
               WHERE id   = OBJECT_ID('PERSONA')
                 AND type = 'U')
    DROP TABLE BankMardis.PERSONA;
GO

IF EXISTS (   SELECT 1
                FROM sysindexes
               WHERE id    = OBJECT_ID('TRANSACCION')
                 AND name  = 'RELATIONSHIP_3_FK'
                 AND indid > 0
                 AND indid < 255)
    DROP INDEX TRANSACCION.RELATIONSHIP_3_FK;
GO

IF EXISTS (   SELECT 1
                FROM sysobjects
               WHERE id   = OBJECT_ID('TRANSACCION')
                 AND type = 'U')
    DROP TABLE BankMardis.TRANSACCION;
GO

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
CREATE TABLE BankMardis.CLIENTE (ID INT IDENTITY(1, 1) NOT NULL,
                                 IDPERSONA INT NULL,
                                 CONTRASENA VARCHAR(10) NULL,
                                 ESTADO VARCHAR(1) NULL,
                                 CONSTRAINT PK_CLIENTE
                                     PRIMARY KEY NONCLUSTERED (ID));
GO

/*==============================================================*/
/* Index: RELATIONSHIP_1_FK                                     */
/*==============================================================*/
CREATE INDEX RELATIONSHIP_1_FK ON BankMardis.CLIENTE (IDPERSONA ASC);
GO

/*==============================================================*/
/* Table: CUENTA                                                */
/*==============================================================*/
CREATE TABLE BankMardis.CUENTA (ID INT IDENTITY(1, 1) NOT NULL,
                                IDCLIENTE INT NULL,
                                NUMEROCUENTA VARCHAR(5) NULL,
                                ESTADO VARCHAR(1) NULL,
                                CONSTRAINT PK_CUENTA
                                    PRIMARY KEY NONCLUSTERED (ID));
GO

/*==============================================================*/
/* Index: RELATIONSHIP_2_FK                                     */
/*==============================================================*/
CREATE INDEX RELATIONSHIP_2_FK ON BankMardis.CUENTA (IDCLIENTE ASC);
GO

/*==============================================================*/
/* Table: PERSONA                                               */
/*==============================================================*/
CREATE TABLE BankMardis.PERSONA (NOMBRE VARCHAR(100) NULL,
                                 APELLIDO VARCHAR(100) NULL,
                                 DOCUMENTO VARCHAR(13) NULL,
                                 FECHANACIMIENTO DATETIME NULL,
                                 GENERO VARCHAR(1) NULL,
                                 DIRECCION VARCHAR(500) NULL,
                                 TELEFONO VARCHAR(10) NULL,
                                 TIPOPERSONA VARCHAR(1) NULL,
                                 ID INT IDENTITY(1, 1) NOT NULL,
                                 CONSTRAINT PK_PERSONA
                                     PRIMARY KEY NONCLUSTERED (ID));
GO

/*==============================================================*/
/* Table: TRANSACCION                                           */
/*==============================================================*/
CREATE TABLE BankMardis.TRANSACCION (ID INT IDENTITY(1, 1) NOT NULL,
                                     IDCUENTA INT NULL,
                                     FECHA DATETIME NULL,
                                     TIPOMOVIMIENTO VARCHAR(5) NULL,
                                     VALOR FLOAT NULL,
                                     SALDO FLOAT NULL,
                                     CONSTRAINT PK_TRANSACCION
                                         PRIMARY KEY NONCLUSTERED (ID));
GO

/*==============================================================*/
/* Index: RELATIONSHIP_3_FK                                     */
/*==============================================================*/
CREATE INDEX RELATIONSHIP_3_FK ON BankMardis.TRANSACCION (IDCUENTA ASC);
GO

ALTER TABLE BankMardis.CLIENTE
ADD CONSTRAINT FK_CLIENTE_RELATIONS_PERSONA
    FOREIGN KEY (IDPERSONA)
    REFERENCES BankMardis.PERSONA (ID);
GO

ALTER TABLE BankMardis.CUENTA
ADD CONSTRAINT FK_CUENTA_RELATIONS_CLIENTE
    FOREIGN KEY (IDCLIENTE)
    REFERENCES BankMardis.CLIENTE (ID);
GO

ALTER TABLE BankMardis.TRANSACCION
ADD CONSTRAINT FK_TRANSACC_RELATIONS_CUENTA
    FOREIGN KEY (IDCUENTA)
    REFERENCES BankMardis.CUENTA (ID);
GO

