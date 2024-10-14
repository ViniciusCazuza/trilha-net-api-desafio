# Projeto API de Sistema de Tarefas | CRUD | ASP.NET Core | Entity Framework

Este projeto é uma API desenvolvida em ASP.NET Core para gerenciar tarefas, permitindo criar, consultar, atualizar e excluir tarefas (CRUD). A API organiza as tarefas com título, descrição, data e status, usando Entity Framework Core para manipular os dados em um banco SQL Server.

## Funcionalidades

- **Criação de Tarefa:** Adiciona uma nova tarefa com título, descrição, data e status.
- **Consulta de Tarefas:** Permite buscar tarefas por ID, título, data ou status.
- **Atualização de Tarefa:** Atualiza uma tarefa existente por ID.
- **Atualização Parcial (PATCH):** Permite a atualização de apenas campos específicos de uma tarefa.
- **Exclusão de Tarefa:** Remove uma tarefa do banco de dados.
  
## Tecnologias Utilizadas

- **ASP.NET Core 8.0:** Framework principal para construção da API.
- **Entity Framework Core 8.0:** ORM utilizado para manipulação dos dados.
- **SQL Server:** Banco de dados utilizado para armazenar as tarefas.
- **Swagger:** Para documentação e teste da API.
- **C#:** Linguagem de programação utilizada.

## Estrutura do Projeto

- `Controllers/`: Contém o `TarefaController`, responsável por definir os endpoints da API.
- `Models/`: Define o modelo de dados `Tarefa` e o enum `EnumStatusTarefa`.
- `Context/`: Contém o `OrganizadorContext`, que é o DbContext utilizado pelo Entity Framework Core para acessar o banco de dados.
- `Migrations/`: Contém os arquivos de migração para a criação e atualização do banco de dados.
  
## Endpoints

### POST `/Tarefa`
Cria uma nova tarefa.
- **Body:**
  ```json
  {
    "titulo": "Título da tarefa",
    "descricao": "Descrição da tarefa",
    "data": "2024-10-10T00:00:00",
    "status": 0
  }
  ```

### GET `/Tarefa/{id}`
Obtém uma tarefa específica por ID.

### GET `/Tarefa/ObterTodos`
Obtém todas as tarefas.

### GET `/Tarefa/ObterPorTitulo`
Filtra as tarefas pelo título.

### GET `/Tarefa/ObterPorData`
Filtra as tarefas por data.

### GET `/Tarefa/ObterPorStatus`
Filtra as tarefas por status (Pendente ou Finalizado).

### PUT `/Tarefa/{id}`
Atualiza uma tarefa existente.

### PATCH `/Tarefa/{id}`
Atualiza parcialmente uma tarefa existente.

### DELETE `/Tarefa/{id}`
Remove uma tarefa existente.

## Instruções para Testar

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/ViniciusCazuza/trilha-net-api-desafio.git
   cd trilha-net-api-desafio
   ```

2. **Configuração do Banco de Dados:**
   Certifique-se de que o SQL Server está rodando e a string de conexão no arquivo `appsettings.Development.json` está configurada corretamente:
   ```json
   "ConnectionStrings": {
     "ConexaoPadrao": "Data Source=localhost\SQLEXPRESS;Initial Catalog=Tarefa;Integrated Security=True;TrustServerCertificate=True"
   }
   ```

3. **Rodar as Migrações:**
   Execute o comando para aplicar as migrações e criar o banco de dados:
   ```bash
   dotnet ef database update
   ```

4. **Rodar o Projeto:**
   Para rodar o projeto localmente, execute:
   ```bash
   dotnet watch run
   ```

5. **Acessar a Documentação Swagger:**
   Após iniciar o projeto, acesse o Swagger para visualizar e testar os endpoints:
   ```
   https://localhost:{porta}/swagger/index.html
   ```

## Como Contribuir

1. Faça um fork do repositório.
2. Crie uma nova branch:
   ```bash
   git checkout -b feature/nova-funcionalidade
   ```
3. Faça suas alterações e commit:
   ```bash
   git commit -m "feat: Adiciona nova funcionalidade"
   ```
4. Faça o push para a branch:
   ```bash
   git push origin feature/nova-funcionalidade
   ```
5. Abra um Pull Request.

## Autor

Projeto desenvolvido pela DIO para o Bootcamp FullStack Developer .NET e React, e feito por Vinicius Cazuza.


##


# DIO - Trilha .NET - API e Entity Framework
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de API e Entity Framework, da trilha .NET da DIO.

## Contexto
Você precisa construir um sistema gerenciador de tarefas, onde você poderá cadastrar uma lista de tarefas que permitirá organizar melhor a sua rotina.

Essa lista de tarefas precisa ter um CRUD, ou seja, deverá permitir a você obter os registros, criar, salvar e deletar esses registros.

A sua aplicação deverá ser do tipo Web API ou MVC, fique a vontade para implementar a solução que achar mais adequado.

A sua classe principal, a classe de tarefa, deve ser a seguinte:

![Diagrama da classe Tarefa](diagrama.png)

Não se esqueça de gerar a sua migration para atualização no banco de dados.

## Métodos esperados
É esperado que você crie o seus métodos conforme a seguir:


**Swagger**


![Métodos Swagger](swagger.png)


**Endpoints**


| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| GET    | /Tarefa/{id}            | id        | N/A           |
| PUT    | /Tarefa/{id}            | id        | Schema Tarefa |
| DELETE | /Tarefa/{id}            | id        | N/A           |
| GET    | /Tarefa/ObterTodos      | N/A       | N/A           |
| GET    | /Tarefa/ObterPorTitulo  | titulo    | N/A           |
| GET    | /Tarefa/ObterPorData    | data      | N/A           |
| GET    | /Tarefa/ObterPorStatus  | status    | N/A           |
| POST   | /Tarefa                 | N/A       | Schema Tarefa |

Esse é o schema (model) de Tarefa, utilizado para passar para os métodos que exigirem

```json
{
  "id": 0,
  "titulo": "string",
  "descricao": "string",
  "data": "2022-06-08T01:31:07.056Z",
  "status": "Pendente"
}
```


## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.