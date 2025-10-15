/*DROP DATABASE IF EXISTS suporte_db;*/
CREATE DATABASE suporte_db;
USE suporte_db;

CREATE TABLE prioridade (
	id_pri INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome_pri VARCHAR(50) NOT NULL
);

INSERT INTO prioridade (nome_pri) VALUES ('Baixa'), ('Média'), ('Alta'), ('Crítica');

CREATE TABLE chamado (
	id_cha INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    titulo_cha VARCHAR(255) NOT NULL,
    descricao_cha TEXT NOT NULL,
    data_abertura_cha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP(),
	data_fechamento_cha DATETIME NULL,
    situacao_cha VARCHAR(50) NOT NULL DEFAULT 'Aberto',
    id_pri_fk INT NOT NULL,
    FOREIGN KEY (id_pri_fk) REFERENCES prioridade (id_pri)
);

INSERT INTO chamado (id_cha, titulo_cha, descricao_cha, data_fechamento_cha, situacao_cha, id_pri_fk)
VALUES 
(1, 'Erro no sistema de login', 'Usuário relata que não consegue acessar a conta com as credenciais corretas.', NULL, 'Aberto', 1),
(2, 'Falha na impressão de relatórios', 'Impressora não responde ao tentar imprimir relatórios do sistema.', '2025-09-15 10:45:00', 'Fechado', 2),
(3, 'Lentidão no sistema ERP', 'Departamento financeiro relatou lentidão excessiva ao acessar o módulo de contas a pagar.', NULL, 'Aberto', 3),
(4, 'Atualização de software', 'Solicitação para atualizar o sistema para a versão mais recente disponível.', '2025-09-14 15:30:00', 'Fechado', 4),
(5, 'Solicitação de novo usuário', 'RH solicitou criação de novo usuário para colaborador recém-contratado.', NULL, 'Aberto', 4);

SELECT * FROM chamado;