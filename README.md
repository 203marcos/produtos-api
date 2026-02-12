
# Catálogo de Produtos - Backend

API para gerenciar produtos de uma loja virtual.

## Tecnologias utilizadas
- .NET 8
- Entity Framework Core
- SQL Server ou SQLite

## Como instalar e rodar
1. Clone o repositório e acesse a pasta do projeto.
2. Restaure os pacotes:
   ```
   dotnet restore
   ```
3. (Opcional) Rode as migrations para criar o banco:
   ```
   dotnet ef database update
   ```
4. Inicie a API:
   ```
   dotnet run --project Produtos.Api
   ```

## Funcionalidades implementadas
- CRUD de produtos
- Filtro por categoria
- Paginação opcional na listagem
- Listagem de categorias

### Endpoints
- `GET /api/produtos` — Lista produtos (filtros: categoria, paginação)
- `GET /api/produtos/{id}` — Detalha produto
- `POST /api/produtos` — Cria produto
- `PUT /api/produtos/{id}` — Atualiza produto
- `DELETE /api/produtos/{id}` — Remove produto
- `GET /api/produtos/categorias` — Lista categorias

## Decisões técnicas
- Organização em camadas (Controller, Service, DTO, Model)
- Validações usando DataAnnotations
- Paginação implementada sem quebrar o front já existente
- Usei SQLite para facilitar testes locais, mas pode ser trocado por SQL Server

### Desafios e melhorias
- O maior desafio foi garantir compatibilidade com o frontend já pronto
- Com mais tempo, faria testes mais completos e implementaria paginação com metadados

---

Qualquer dúvida, só chamar!
