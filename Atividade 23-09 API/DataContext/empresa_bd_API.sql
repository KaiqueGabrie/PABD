CREATE DATABASE empresas_db;
USE empresas_db;

CREATE TABLE empresas(
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	cnpj VARCHAR(14) NOT NULL UNIQUE,
    razao VARCHAR(250) NOT NULL,
    nome VARCHAR(250) NOT NULL,
    inscr_estad VARCHAR(10),
    telefone VARCHAR(10) NOT NULL,
    email VARCHAR(100) NOT NULL,
    cidade TEXT NOT NULL,
    estado TEXT NOT NULL,
	cep VARCHAR(10) NOT NULL,
    data_cad DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP()
);

INSERT INTO empresas (cnpj, razao, nome, inscr_estad, telefone, email, cidade, estado, cep) VALUES
('12345678000199', 'Empresa Alpha LTDA', 'Alpha', '1234567890', '1199999999', 'contato@alpha.com.br', 'São Paulo', 'SP', '01001000'),
('98765432000155', 'Beta Comércio ME', 'Beta', NULL, '2198888888', 'beta@comercio.com', 'Rio de Janeiro', 'RJ', '20020000'),
('11122233000144', 'Gama Serviços SA', 'Gama', '1122334455', '3197777777', 'contato@gamaservicos.com', 'Belo Horizonte', 'MG', '30140000'),
('44455566000133', 'Delta Indústria ME', 'Delta', NULL, '4196666666', 'delta@industria.com', 'Curitiba', 'PR', '80010000'),
('55566677000122', 'Epsilon Soluções LTDA', 'Epsilon', '5566778899', '5195555555', 'epsilon@solucoes.com.br', 'Porto Alegre', 'RS', '90020000');

SELECT * FROM empresas;