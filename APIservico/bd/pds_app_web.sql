CREATE DATABASE suporte_db;
USE suporte_db;

CREATE TABLE chamado (
	id_cha INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    titulo_cha VARCHAR(255) NOT NULL,
    descricao_cha TEXT NOT NULL,
    data_abertura_cha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP(),
	data_fechamento_cha DATETIME NULL,
    situacao_cha VARCHAR(50) NOT NULL DEFAULT 'Aberto'
);

INSERT INTO chamado (id_cha, titulo_cha, descricao_cha, data_fechamento_cha, situacao_cha)
VALUES 
(1, 'Erro no sistema de login', 'Usuário relata que não consegue acessar a conta com as credenciais corretas.', NULL, 'Aberto'),
(2, 'Falha na impressão de relatórios', 'Impressora não responde ao tentar imprimir relatórios do sistema.', '2025-09-15 10:45:00', 'Fechado'),
(3, 'Lentidão no sistema ERP', 'Departamento financeiro relatou lentidão excessiva ao acessar o módulo de contas a pagar.', NULL, 'Aberto'),
(4, 'Atualização de software', 'Solicitação para atualizar o sistema para a versão mais recente disponível.', '2025-09-14 15:30:00', 'Fechado'),
(5, 'Solicitação de novo usuário', 'RH solicitou criação de novo usuário para colaborador recém-contratado.', NULL, 'Aberto');

SELECT * FROM chamado;