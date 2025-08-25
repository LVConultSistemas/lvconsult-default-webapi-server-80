# LvConsult - Template de Projeto .NET

Este é um template de projeto .NET que serve como base para criação de novos projetos seguindo as melhores práticas de arquitetura limpa (Clean Architecture) e padrões de desenvolvimento.

## 🏗️ Arquitetura

O projeto segue a arquitetura em camadas com separação clara de responsabilidades:

```
src/
├── LvConsult.Api/                 # Camada de apresentação (Controllers, Filters)
├── LvConsult.Domain/              # Camada de domínio (Entities, Services, Repositories)
├── LvConsult.Infrastructure/      # Camada de infraestrutura (DataAccess, Services)
└── LvConsult.Exception/           # Camada de exceções customizadas
```

### Estrutura das Camadas

#### **LvConsult.Api**

- Controllers da API
- Filters para tratamento de exceções
- Configurações de autenticação/autorização
- Health checks
- Configurações de injeção de dependência

#### **LvConsult.Domain**

- Entidades do domínio
- Interfaces de repositórios
- Serviços de domínio
- Interfaces de segurança (tokens, criptografia)
- Value objects

#### **LvConsult.Infrastructure**

- Implementação do DbContext
- Repositórios concretos
- Serviços de infraestrutura
- Migrações do banco de dados
- Configurações de injeção de dependência

#### **LvConsult.Exception**

- Exceções customizadas do projeto
- Mensagens de erro centralizadas
- Tratamento padronizado de erros

## 🚀 Como Usar Este Template

### 1. Clone o Repositório

```bash
git clone https://github.com/LVConultSistemas/lvconsult-default-webapi-server-80.git
cd lvconsult-default-webapi-server-80
```

### 2. Renomeie o Projeto

Substitua todas as ocorrências de "LvConsult" pelo nome do seu novo projeto:

```bash
# Exemplo: substituir por "MeuProjeto"
find . -name "*.cs" -o -name "*.csproj" -o -name "*.json" | xargs sed -i 's/LvConsult/MeuProjeto/g'
```

### 3. Atualize os Namespaces

Atualize todos os namespaces nos arquivos `.cs` para refletir o novo nome do projeto.

### 4. Configure o Banco de Dados

Edite o arquivo `src/LvConsult.Api/appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "Connection": "Server=localhost;Database=meuprojetodb;Uid=root;Pwd=sua_senha;"
  }
}
```

### 5. Execute as Migrações

```bash
cd src/LvConsult.Api
dotnet ef database update
```

## 🛠️ Tecnologias Utilizadas

- **.NET 8.0** - Framework principal
- **Entity Framework Core** - ORM para acesso a dados
- **MySQL** - Banco de dados (configurável)
- **JWT** - Autenticação baseada em tokens
- **AutoMapper** - Mapeamento de objetos
- **FluentValidation** - Validação de dados
- **Swagger/OpenAPI** - Documentação da API

## 📋 Pré-requisitos

- .NET 8.0 SDK
- MySQL Server (ou outro banco de dados suportado pelo EF Core)
- IDE (Visual Studio, VS Code, Rider)

## 🔧 Configuração do Ambiente

### 1. Instalação das Dependências

```bash
dotnet restore
```

### 2. Configuração do Banco de Dados

```bash
# Instalar ferramentas do Entity Framework
dotnet tool install --global dotnet-ef

# Criar migração inicial (se necessário)
dotnet ef migrations add InitialMigration --project src/LvConsult.Infrastructure --startup-project src/LvConsult.Api

# Aplicar migrações
dotnet ef database update --project src/LvConsult.Infrastructure --startup-project src/LvConsult.Api
```

### 3. Executar o Projeto

```bash
cd src/LvConsult.Api
dotnet run
```

A API estará disponível em: `https://localhost:7001` ou `http://localhost:5001`

## 📚 Padrões Implementados

### Clean Architecture

- Separação clara entre camadas
- Inversão de dependência
- Domínio independente de frameworks

### Repository Pattern

- Abstração do acesso a dados
- Facilita testes unitários
- Desacoplamento da camada de dados

### Unit of Work

- Gerenciamento de transações
- Consistência de dados
- Padrão para operações em lote

### Exception Handling

- Tratamento centralizado de exceções
- Exceções customizadas por domínio
- Respostas padronizadas de erro

### Dependency Injection

- Injeção de dependência nativa do .NET
- Configuração centralizada
- Facilita testes e manutenção

## 🧪 Testes

### Estrutura de Testes Recomendada

```
tests/
├── LvConsult.UnitTests/           # Testes unitários
├── LvConsult.IntegrationTests/    # Testes de integração
└── LvConsult.FunctionalTests/     # Testes funcionais
```

### Executar Testes

```bash
dotnet test
```

## 📝 Convenções de Código

### Nomenclatura

- **Classes**: PascalCase (ex: `UserRepository`)
- **Métodos**: PascalCase (ex: `GetUserById`)
- **Variáveis**: camelCase (ex: `userName`)
- **Constantes**: UPPER_CASE (ex: `MAX_RETRY_COUNT`)
- **Interfaces**: Prefixo "I" (ex: `IUserRepository`)

### Estrutura de Arquivos

- Um arquivo por classe
- Namespace igual ao caminho do arquivo
- Usings organizados (System, Microsoft, bibliotecas de terceiros, projeto)

### Comentários

- Use comentários XML para APIs públicas
- Comentários explicativos para lógica complexa
- Evite comentários óbvios

## 🔒 Segurança

### JWT Configuration

```json
{
  "Settings": {
    "Jwt": {
      "SigningKey": "sua_chave_secreta_aqui",
      "ExpiresMinutes": 1000
    }
  }
}
```

### Criptografia

- Senhas sempre criptografadas
- Chaves sensíveis em variáveis de ambiente
- Validação de entrada em todas as APIs

## 📦 Deploy

### Docker

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/LvConsult.Api/LvConsult.Api.csproj", "src/LvConsult.Api/"]
COPY ["src/LvConsult.Domain/LvConsult.Domain.csproj", "src/LvConsult.Domain/"]
COPY ["src/LvConsult.Infrastructure/LvConsult.Infrastructure.csproj", "src/LvConsult.Infrastructure/"]
COPY ["src/LvConsult.Exception/LvConsult.Exception.csproj", "src/LvConsult.Exception/"]
RUN dotnet restore "src/LvConsult.Api/LvConsult.Api.csproj"
COPY . .
WORKDIR "/src/src/LvConsult.Api"
RUN dotnet build "LvConsult.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LvConsult.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LvConsult.Api.dll"]
```

### Variáveis de Ambiente

```bash
# Produção
ASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__Connection=Server=prod-server;Database=meuprojetodb;Uid=user;Pwd=password;
Settings__Jwt__SigningKey=chave_secreta_producao
```

## 🤝 Contribuição

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 🆘 Suporte

Para dúvidas ou problemas:

- Abra uma issue no repositório
- Consulte a documentação da API em `/swagger`
- Verifique os logs da aplicação

## 🔄 Atualizações

Para manter o template atualizado:

1. Faça backup das suas customizações
2. Atualize o template base
3. Aplique suas customizações novamente
4. Teste todas as funcionalidades

---

**Nota**: Este template é um ponto de partida. Adapte conforme as necessidades específicas do seu projeto.
