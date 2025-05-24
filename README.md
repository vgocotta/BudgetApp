# 💸 Budget

Aplicativo de controle de despesas pessoais desenvolvido como projeto da disciplina **Gestão e Qualidade de Software (GQS)**, utilizando .NET MAUI e boas práticas de desenvolvimento profissional.

---

## 🚀 Funcionalidades

- ✅ Cadastro de **categorias** de despesa
- ✅ Cadastro de **despesas** com valor, data e categoria
- ✅ Tela inicial com despesas do **mês atual**
- ✅ Marcação de despesas como **pagas**
- ✅ Relacionamento entre categorias e despesas
- ✅ Persistência local com **SQLite**
- ✅ Aplicação das boas práticas:
  - Clean Code
  - TDD
  - Tratamento de erros
  - CI/CD (opcional)
  - Git Semântico

---

## 🧱 Estrutura do Projeto

\`\`\`plaintext
Budget.sln
├── src/
│   ├── Budget.App           # Projeto MAUI (interface e navegação)
│   ├── Budget.Core          # Entidades, regras de negócio, interfaces
│   ├── Budget.Infrastructure# EF Core e repositórios
│   └── Budget.Migrator      # Projeto Console para aplicar migrations
├── test/
│   └── Budget.Tests         # Testes unitários (xUnit)
\`\`\`

---

## 🛠️ Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- [MAUI](https://learn.microsoft.com/en-us/dotnet/maui/)
- [SQLite + EF Core](https://learn.microsoft.com/en-us/ef/core/)
- [xUnit](https://xunit.net/) + [Moq](https://github.com/moq)
- Git + GitFlow + Commits Semânticos
- (Opcional) GitHub Actions para CI

---

## 🧪 Testes

- Localizados em `test/Budget.Tests`
- Executados com `xUnit`
- Abrangem:
  - `CategoryService`
  - `ExpenseService`

### Como executar os testes

No terminal:
\`\`\`bash
dotnet test
\`\`\`

---

## 🧩 Banco de Dados

- Utiliza **SQLite** local (arquivo `.db` na pasta AppData)
- Migrations aplicadas via projeto `Budget.Migrator`

### Aplicar migrations:
\`\`\`bash
cd src/Budget.Migrator
dotnet run
\`\`\`

---

## 🧪 Rodando o App

1. Clone o repositório
2. Abra a solução no **Visual Studio 2022**
3. Execute o projeto **`Budget.App`**
4. O banco será criado automaticamente se não existir

---

## 📌 Versão

- Release atual: `v1.0`
- Tag criada no merge da branch `develop` → `master`

---

## 📝 Licença

Este projeto está licenciado sob a **Licença Apache 2.0**. Veja o arquivo [`LICENSE`](./LICENSE) para mais detalhes.
