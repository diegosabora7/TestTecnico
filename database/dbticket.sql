
CREATE DATABASE dbticket

CREATE TABLE tcliente (
idCliente INT PRIMARY KEY  NOT NULL,
nombre VARCHAR(50) NOT NULL
);
CREATE TABLE tcola (
idCola INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
nombre VARCHAR(40) NOT NULL
);
CREATE TABLE tcoladetalle (
    idCola int NOT NULL,
    id int NOT NULL,
    PRIMARY KEY (idCola,id),
  CONSTRAINT FK_ColaColaDetalle FOREIGN KEY (idCola)
    REFERENCES tcola(idCola)
      
);
INSERT INTO tcola VALUES ('COLA 1')
INSERT INTO tcola VALUES('COLA 2')