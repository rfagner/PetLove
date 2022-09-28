/* DML - Data Manipulation Language -> Linguagem de Manipulação de Dados*/

/* Inserir */
/* Forma 1 */
INSERT INTO TipoUsuario(Tipo) 
	VALUES 
		('Desenvolvedor'), 
		('Medico'), 
		('Paciente');


INSERT INTO Usuario (Nome, Email, Senha, IdTipoUsuario)
	VALUES 
		-- Desenvolvedor
		('Fernanda', 'fernanda@edusync.com', '$2b$10$RUK/V5KMRsVTlsCb6ghaBuX7O9BzR2frZmDrA9vdccDpvV2UgYRP2', 1), --1
		('Sérgio', 'sergio@edusync.com', '$2b$10$5LMovtayfiW5SO2BBQ.5Ye.gPzdxIcxNU5vq1ocbK/v/gx/obXibS', 1),     --2
		('Celso', 'celso@edusync.com.com', '$2b$10$HNgf6ffl3fu9Jt5joDEOeuArAnIhbu6NyUa8QJ6eoK/KYTRsc.OJK', 1),   --3 

		-- Médicos
		('Maria', 'maria@email.com', '$2b$10$7AmXHnSNNzfDHsV.TYB/Ve4AfPZi2WRTc5DWDz6FLGxVdkgNKfnAC', 2),         --4
		('João', 'joao@email.com', '$2b$10$I55Jtu9lv9X/98wBRKfGx.YnismMMq3AQLBRAcXkX2ZZMvI4wwJ7u', 2),           --5
		('Pedro', 'pedro@email.com', '$2b$10$rugWWmClZkSxeKqTuxHeveQMPcHSKfpeeQIkM/.NOp1yUAopA8aIy', 2),         --6  
		('Leonardo', 'leonardo@email.com', '$2b$10$NzFyNvYLBsPpMl3fdKFlPO01ml5nVNVHlL42r41ZaHzeHfQbYne4i', 2),   --7
		('Carla', 'carla@email.com', '$2b$10$1/rv28jCbFz2DER3MJ4ZP.54xsTEkHuzGvqNDhjVSjEFRm0PjMhLa', 2),         --8 

		-- Pacientes
		('Paulo', 'paulo@email.com', '$2b$10$hZ1exkfVNdq4HK2VpER23.6uimyVn4WoTKd0DgXW/gVZx3ccaHKSy', 3),         --9
		('Claudio', 'claudio@email.com', '$2b$10$iYdnxziBv3We/ZpaaiCc.OQmOottLl5EpGojriwrv/IHEb1pljUdy', 3),     --10
		('Henrique', 'henrique@email.com', '$2b$10$9YQnBGwpjRkwV3UNDA1XJe84v.cV5/8MdksmDmxPX.9uCrEZYojMq', 3),   --11
		('Lorena', 'lorena@email.com', '$2b$10$NuCKlLjLgVDhHMFIuncTv.RoXf3whoqSvRkKrnbdmxr/5Jv4rMHnC', 3),       --12 
		('Viviane', 'viviane@email.com', '$2b$10$4V8q0Eq9xByBLvzW/.yMHe4FSz1rE5EnWySkZMfKh10JWMoJ31gmm', 3);     --13 


INSERT INTO Especialidade(Categoria) 
	VALUES
		('Clínico Geral'), 
		('Radiologia'), 
		('Cardiologia'),
		('Dermatologia'),
		('Ginecologia e Obstetrícia'),
		('Ortopedia'),
		('Pediatria'),
		('Oftalmologia'),
		('Oncologia'),
		('Anestesiologia');

INSERT INTO Paciente (Carteirinha, DataNascimento, Ativo, IdUsuario) 
	VALUES 
		('SUS12345', '2000-09-05', 1, 9), 
		('SUS45678', '1998-10-10', 1, 10),
		('SUS45698', '1993-01-14', 1, 11),
		('SUS78963', '1973-05-11', 1, 12),
		('SUS20225', '1997-08-01', 1, 13);


INSERT INTO Medico (CRM, IdEspecialidade, IdUsuario) 
	VALUES 
		('CRM12345',  1, 4), 
		('CRM45678',  2, 5),
		('CRM45698',  3, 6),
		('CRM78963',  4, 7),
		('CRM20225',  5, 8);

INSERT INTO Consulta(DataHora, IdMedico, IdPaciente) 
	VALUES 
		('2022-09-05 08:30', 1, 1), 
		('2022-10-10 08:50', 2, 2),
		('2022-01-14 09:30', 3, 3),
		('2022-05-11 10:30', 4, 4),
		('2022-08-01 15:00', 5, 5);

/* Alterar */
--UPDATE Categorias SET Categoria = 'Show' WHERE Id = 1;

/* Excluir */
--DELETE FROM Categorias WHERE Id = 9;