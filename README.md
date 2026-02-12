# Produtos API

API RESTful para catálogo de produtos de uma loja virtual.

## Tecnologias
- .NET 8
- Entity Framework Core
- SQL Server (ou SQLite)

## Como rodar
1. Restaure os pacotes:
   ```
   dotnet restore
   ```
2. Aplique as migrations (opcional):
   ```
   dotnet ef database update
   ```
3. Rode a API:
   ```
   dotnet run --project Produtos.Api
   ```

## Endpoints principais
- `GET /api/produtos` — Lista produtos (filtros: categoria, paginação opcional)
- `GET /api/produtos/{id}` — Detalhe do produto
- `POST /api/produtos` — Cria produto
- `PUT /api/produtos/{id}` — Atualiza produto
- `DELETE /api/produtos/{id}` — Remove produto
- `GET /api/produtos/categorias` — Lista categorias

## Paginação
Opcional: use `?page=1&pageSize=10` nos endpoints de listagem.

## Decisões técnicas
- Separação por camadas (Controller, Service, DTO, Model)
- Validações por DataAnnotations
- Paginação não quebra compatibilidade com o frontend

---

Dúvidas? Abra uma issue ou entre em contato.
