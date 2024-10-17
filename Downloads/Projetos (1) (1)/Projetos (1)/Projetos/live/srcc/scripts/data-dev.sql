-- Inserir dados na tabela T_CRIME
insert into T_CRIME (id, descricao, data_ocorrencia) values (nextval('T_CRIME_seq'), 'Crimes contra o patrimônio', '2024-01-15');
insert into T_CRIME (id, descricao, data_ocorrencia) values (nextval('T_CRIME_seq'), 'Crimes de homicídio', '2024-02-10');
insert into T_CRIME (id, descricao, data_ocorrencia) values (nextval('T_CRIME_seq'), 'Crimes de trânsito', '2024-03-05');
insert into T_CRIME (id, descricao, data_ocorrencia) values (nextval('T_CRIME_seq'), 'Crimes cibernéticos', '2024-04-20');
insert into T_CRIME (id, descricao, data_ocorrencia) values (nextval('T_CRIME_seq'), 'Crimes contra a mulher', '2024-05-15');

-- Inserir dados na tabela T_EMERGENCIA
insert into T_EMERGENCIA (id, tipo_emergencia, localizacao) values (nextval('T_EMERGENCIA_seq'), 'Incêndio', 'Rua A, 123');
insert into T_EMERGENCIA (id, tipo_emergencia, localizacao) values (nextval('T_EMERGENCIA_seq'), 'Acidente de trânsito', 'Avenida B, 456');
insert into T_EMERGENCIA (id, tipo_emergencia, localizacao) values (nextval('T_EMERGENCIA_seq'), 'Desastre natural', 'Zona C');

-- Inserir dados na tabela T_HABITANTE
insert into T_HABITANTE (id, nome_habitante, data_nascimento) values (nextval('T_HABITANTE_seq'), 'João da Silva', '1980-05-21');
insert into T_HABITANTE (id, nome_habitante, data_nascimento) values (nextval('T_HABITANTE_seq'), 'Maria Oliveira', '1992-08-15');
insert into T_HABITANTE (id, nome_habitante, data_nascimento) values (nextval('T_HABITANTE_seq'), 'Carlos Pereira', '1975-11-10');

-- Inserir dados na tabela T_RECURSOS_POLICIAIS
insert into T_RECURSOS_POLICIAIS (id, tipo_recurso, quantidade) values (nextval('T_RECURSOS_POLICIAIS_seq'), 'Viatura', 10);
insert into T_RECURSOS_POLICIAIS (id, tipo_recurso, quantidade) values (nextval('T_RECURSOS_POLICIAIS_seq'), 'Policial', 50);
insert into T_RECURSOS_POLICIAIS (id, tipo_recurso, quantidade) values (nextval('T_RECURSOS_POLICIAIS_seq'), 'Equipamento de comunicação', 20);

-- Inserir dados na tabela T_SISTEMA_VIGILANCIA
insert into T_SISTEMA_VIGILANCIA (id, tipo_camera, localizacao) values (nextval('T_SISTEMA_VIGILANCIA_seq'), 'Câmera IP', 'Praça Central');
insert into T_SISTEMA_VIGILANCIA (id, tipo_camera, localizacao) values (nextval('T_SISTEMA_VIGILANCIA_seq'), 'Câmera analógica', 'Escola Municipal');
insert into T_SISTEMA_VIGILANCIA (id, tipo_camera, localizacao) values (nextval('T_SISTEMA_VIGILANCIA_seq'), 'Câmera de segurança', 'Banco do Brasil');

-- Inserir dados na tabela T_TIPO_DE_CRIME
insert into T_TIPO_DE_CRIME (id, tipo_crime) values (nextval('T_TIPO_DE_CRIME_seq'), 'Crimes contra o patrimônio');
insert into T_TIPO_DE_CRIME (id, tipo_crime) values (nextval('T_TIPO_DE_CRIME_seq'), 'Crimes de homicídio');
insert into T_TIPO_DE_CRIME (id, tipo_crime) values (nextval('T_TIPO_DE_CRIME_seq'), 'Crimes de trânsito');
insert into T_TIPO_DE_CRIME (id, tipo_crime) values (nextval('T_TIPO_DE_CRIME_seq'), 'Crimes cibernéticos');
insert into T_TIPO_DE_CRIME (id, tipo_crime) values (nextval('T_TIPO_DE_CRIME_seq'), 'Crimes contra a mulher');



