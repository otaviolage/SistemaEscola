CREATE TABLE Aluno (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100) NOT NULL,
    Usuario NVARCHAR(50) NOT NULL,
    SenhaHash NVARCHAR(256) NOT NULL
);

Select * from Aluno 

INSERT INTO Aluno (Nome, Usuario, SenhaHash)
VALUES
    ('João Silva', 'joao123', HASHBYTES('SHA2_256', 'senha1')),
    ('Maria Souza', 'maria456', HASHBYTES('SHA2_256', 'senha2')),
    ('José Oliveira', 'jose789', HASHBYTES('SHA2_256', 'senha3'));

---
CREATE TABLE Turma (
    Id INT PRIMARY KEY IDENTITY,
    CursoId INT,
    Turma VARCHAR(50),
    Ano INT
);

INSERT INTO Turma (CursoId, Turma, Ano) VALUES
(101, 'Turma A', 2024),
(102, 'Turma B', 2023),
(103, 'Turma C', 2022);

Select * from Turma

---
CREATE TABLE AlunoTurma
(
    AlunoId INT,
    TurmaId INT,
    PRIMARY KEY (AlunoId, TurmaId),
    FOREIGN KEY (AlunoId) REFERENCES Aluno (Id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (TurmaId) REFERENCES Turma (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

Select * from AlunoTurma

INSERT INTO AlunoTurma (AlunoId, TurmaId) VALUES
(1, 9),
(2, 2)

SELECT t.Turma, a.Id as IdAluno, a.Nome, a.Usuario
FROM Aluno a
INNER JOIN AlunoTurma at ON a.Id = at.AlunoId
INNER JOIN Turma t ON t.Id = at.TurmaId
WHERE t.Id = 2;