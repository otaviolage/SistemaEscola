# SistemaEscola

### Tecnologias Utilizadas
- .NET 8
- Dapper
- SQL Server
- Razor

### Kanban do Projeto:

![alt text](image.png)

### Regras de Negócio

As regras de negócio são concentradas no domínio, seguindo os princípios do Domain-Driven Design (DDD):

- [x] Sistema não pode permitir Turmas com o mesmo nome (coluna turma no diagrama).
- [x] Sistema não pode permitir o mesmo Aluno relacionado na mesma Turma duas vezes.
- [x] Sistema não pode permitir cadastrar senhas fracas.
- [x] Sistema não pode permitir criar Turmas com datas anteriores da atual.
- [x] A senha deve ser salva em formato de hash.

### Diferenciais

- **Design Pattern utilizado:** Injeção de Dependência
- **Extension Method:** `Utils/ToSHA256Hash`, para implementar o hash a uma string
- **Middleware:** Validando JWT Token ao acessar API via endpoints mapeados na controller

### Testes Unitários com XUnit
Este projeto utiliza testes unitários com XUnit para garantir a qualidade do código e a conformidade com as regras de negócio estabelecidas. (Entregue: AlunoService)

### Melhorias Futuras

- [ ] 100% de testes unitários da Domain (onde concentram-se as regras de negócio)
- [ ] Mapear mensagens de erro nas validações de negócio (requisitos)
- [ ] Validação de inputs
- [ ] Trazer todos os métodos para a controller
