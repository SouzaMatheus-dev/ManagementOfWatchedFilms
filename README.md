# ManagementOfWatchedFilms

Este projeto tem como objetivo fornecer uma API para o gerenciamento de filmes assistidos. A aplicação foi desenvolvida em .NET Core e está organizada em uma arquitetura em camadas para promover a separação de responsabilidades e facilitar a manutenção.

## Estrutura do Projeto

A estrutura do projeto é composta por diferentes projetos que seguem os princípios de Clean Architecture. Abaixo está uma visão geral das camadas e suas responsabilidades:

### 1. Application (`ManagementOfWatchedFilms.API`)

- **Controllers**: Contém os controladores da API, como o `MovieController.cs`. Os controladores são responsáveis por receber as requisições HTTP, delegar as operações para as camadas adequadas e retornar as respostas.
- **Models**: Define os modelos de dados utilizados na aplicação.
- **Infrastructure**: Esta pasta pode conter configurações específicas para a infraestrutura da aplicação, como serviços de terceiros, banco de dados, etc.
- **appsettings.json** e **appsettings.Development.json**: Contêm configurações da aplicação, como strings de conexão, configurações de APIs externas, etc.
- **Program.cs**: O ponto de entrada da aplicação. Contém a configuração dos serviços e do pipeline de execução da aplicação.

### 2. Domain (`ManagementOfWatchedFilms.Domain`)

- **Entity**: Contém as entidades que representam os objetos de domínio do sistema, como `Filme`, `Usuário`, etc.
- **Interface**: Define as interfaces para os repositórios e serviços. Essa camada representa as abstrações necessárias para a lógica de negócios e permite a implementação de diferentes mecanismos de persistência e lógica de negócios.

### 3. Service (`ManagementOfWatchedFilms.Service`)

- **MovieService.cs**: Implementa a lógica de negócios relacionada ao gerenciamento de filmes. Esta camada utiliza as entidades e interfaces definidas na camada de `Domain`.
- **Validator**: Contém as classes de validação que são responsáveis por validar os dados antes de serem processados pelos serviços.
- **ServiceBase.cs**: Uma classe base que pode conter funcionalidades comuns a todos os serviços, facilitando o reuso de código.
- **Dependencies**: Pode incluir injeções de dependência necessárias para os serviços.

### 4. Infrastructure

#### 4.1 Data (`ManagementOfWatchedFilms.Infrastructure.Data`)

- Lida com a persistência de dados. Contém implementações para os repositórios definidos na camada de `Domain`. Pode utilizar ORM, como Entity Framework Core, ou outras estratégias para acesso a dados.

#### 4.2 CrossCutting (`ManagementOfWatchedFilms.Infrastructure.CrossCutting`)

- **InversionOfControl**: Implementa a injeção de dependências, centralizando a configuração de DI (Dependency Injection). Contém classes como `InfrastructureDependency.cs`, `RepositoryDependency.cs`, e `ServiceDependency.cs` que configuram a injeção de dependências para os repositórios, serviços e outras infraestruturas da aplicação.
- **IMDb**: Integração com a API do IMDb. Contém as classes responsáveis por acessar dados da API externa e processá-los conforme necessário pela aplicação. A estrutura inclui:
  - **Models**: Modelos específicos para integração com o IMDb.
  - **Options**: Configurações necessárias para acessar a API do IMDb.
  - **IMDb.cs**: Implementa a lógica de acesso à API do IMDb.
  - **IMDbDependency.cs**: Configura a injeção de dependências para a integração com o IMDb.

#### 4.3 Core (`ManagementOfWatchedFilms.Infrastructure.Core`)

- Contém funcionalidades centrais e utilitários da camada de infraestrutura que são utilizados em toda a aplicação. Pode incluir lógica de manipulação de arquivos, processamento de dados, etc.

## Como Executar

1. Abra a solução `ManagementOfWatchedFilms` no Visual Studio ou outro ambiente de desenvolvimento compatível com .NET Core.
2. Compile a solução para restaurar as dependências e compilar os projetos.
3. Configure as variáveis de ambiente no `appsettings.json` e `appsettings.Development.json`.
4. Execute a aplicação para iniciar a API localmente.

## Tecnologias Utilizadas

- .NET Core
- Entity Framework Core
- MediatR (para o padrão Mediator)
- Integração com IMDb API
- Outros pacotes e bibliotecas necessárias para a aplicação.

## Contribuindo

Siga a estrutura e padrões estabelecidos ao adicionar novas funcionalidades ou corrigir problemas. As alterações devem ser feitas na camada apropriada:

- Adicione novas entidades e interfaces na camada `Domain`.
- Implemente a lógica de negócios na camada `Service`.
- Adicione novas integrações e repositórios na camada `Infrastructure`.

## Padrões Seguidos

A aplicação segue os princípios de Clean Architecture, desacoplando as diferentes responsabilidades e promovendo a reutilização e manutenção do código.
