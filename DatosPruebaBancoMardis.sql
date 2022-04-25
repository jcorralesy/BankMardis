INSERT INTO BankMardis.PERSONA (NOMBRE,
                     APELLIDO,
                     DOCUMENTO,
                     FECHANACIMIENTO,
                     GENERO,
                     DIRECCION,
                     TELEFONO,
                     TIPOPERSONA)
VALUES 
('Andres','Corrales','1722720784','2015-01-02','M','Calderon','0984445196','N'),
('Jessica','Marquez','1789769845','2018-01-02','F','Quito','0984445196','J'),
('Ivan','Reyes','1719116871','2019-01-02','M','Valle','0984445196','N')

INSERT INTO BankMardis.CLIENTE (IDPERSONA,
                                CONTRASENA,
                                ESTADO)
VALUES (1, -- IDPERSONA - int
        'acorrales', -- CONTRASENA - varchar(10)
        'A' -- ESTADO - varchar(1)
    ),
    (2, -- IDPERSONA - int
        'jmarquez', -- CONTRASENA - varchar(10)
        'A' -- ESTADO - varchar(1)
    ),
    (3, -- IDPERSONA - int
        'ireyes', -- CONTRASENA - varchar(10)
        'A' -- ESTADO - varchar(1)
    )

INSERT INTO BankMardis.CUENTA (IDCLIENTE,
                               NUMEROCUENTA,
                               ESTADO)
VALUES (1, -- IDCLIENTE - int
        '10001', -- NUMEROCUENTA - varchar(5)
        'A' -- ESTADO - varchar(1)
    ),
    (2, -- IDCLIENTE - int
        '10002', -- NUMEROCUENTA - varchar(5)
        'A' -- ESTADO - varchar(1)
    ),
    (3, -- IDCLIENTE - int
        '10003', -- NUMEROCUENTA - varchar(5)
        'A' -- ESTADO - varchar(1)
    )

INSERT INTO BankMardis.TRANSACCION (IDCUENTA,
                                    FECHA,
                                    TIPOMOVIMIENTO,
                                    VALOR,
                                    SALDO)
VALUES (1, -- IDCUENTA - int
        GETDATE(), -- FECHA - datetime
        'POS', -- TIPOMOVIMIENTO - varchar(5)
        3000, -- VALOR - float
        3000 -- SALDO - float
    ),
    (1, -- IDCUENTA - int
        GETDATE(), -- FECHA - datetime
        'NEG', -- TIPOMOVIMIENTO - varchar(5)
        500, -- VALOR - float
        2500 -- SALDO - float
    ),
    (1, -- IDCUENTA - int
        GETDATE(), -- FECHA - datetime
        'POS', -- TIPOMOVIMIENTO - varchar(5)
        10, -- VALOR - float
        2510 -- SALDO - float
    )