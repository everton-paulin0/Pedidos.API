# Pedidos.API

CRUD (Create, Read, Update, Delete) para gerenciar pedidos.
Cada pedido deve contém:
o Identificador único (ID).
o Nome do cliente.
o Data do pedido.
o Data de Atualização
o Itens do pedido (nome do item, quantidade, valor unitário).
o Valor total do pedido (calculado com base nos itens).
3. Permitir filtrar os pedidos por data e/ou nome do cliente

Requisitos Técnicos Utilizados:
1. Utilize .NET 8 ou superior.
2. Banco de dados  - SQLite.
3. Exponha uma API REST com os seguintes endpoints:
o POST /orders: Criar um pedido.
o GET /orders: Listar todos os pedidos.
o GET /orders/{id}: Obter um pedido por ID.
o PUT /orders/{id}: Atualizar um pedido.
o DELETE /orders/{id}: Excluir um pedido.
4. Implemente testes unitários usando xUnit.

Extras
1. Documentação da API usando Swagger.
2. Validação dos dados de entrada (por exemplo, não permitir valores negativos para
quantidade ou preço).
3.  MediatR:
4.Clean Architecture
5. Implemente padrões CQRS para separar comandos e queries.
o Use Requests e Handlers do MediatR para processar as operações do
CRUD.
6. Configure injeção de dependência e modularize o projeto para facilitar a
escalabilidade
