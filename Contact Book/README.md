# Agenda de Contatos (Razor Pages + API)

Projeto .NET 8 com Razor Pages que expõe uma API para gerenciar contatos (CRUD) e uma interface simples usando Vue 3 e Bootstrap 5.

## Tecnologias
- .NET 8
- ASP.NET Core (Razor Pages + Controllers)
- Entity Framework Core + Pomelo MySQL
- Vue 3 (via CDN)
- Bootstrap 5

## Funcionalidades
- Listar contatos com busca
- Consultar detalhes em modal
- Criar novo contato em modal
- Editar contato em modal
- Remover contato com confirmação em modal
- Validação básica no cliente (telefone opcional)

## Estrutura
- `Contact Book/Controllers/ContactController.cs`: API REST (`GET`, `GET/{id}`, `POST`, `PUT/{id}`, `DELETE/{id}`)
- `Contact Book/Data/AppDbContext.cs`: contexto EF Core
- `Contact Book/Models/Contact.cs`: entidade de contato
- `Contact Book/Views/Home/Index.cshtml`: página Razor com Vue e Bootstrap
- `Contact Book/appsettings.json`: configurações

## Migrations
- Criar migration: `Add-Migration Initial`
- Atualizar banco: `Update-Database`

Se o banco já tiver tabelas sem histórico, crie um baseline (ou recrie o banco) antes de aplicar migrations.

## Execução
1. `dotnet restore`
2. `dotnet build`
3. `dotnet run`
4. Acesse a UI: `https://localhost:7162/`
   - API base: `/api/contact`

## Endpoints da API
- `GET /api/contact` — lista contatos
- `GET /api/contact/{id}` — contato por id
- `POST /api/contact` — cria contato
- `PUT /api/contact/{id}` — atualiza contato
- `DELETE /api/contact/{id}` — remove contato

## Observações de UI
- Para evitar conflitos com Razor, o template Vue usa `v-text`/`v-on:` em vez de `{{ }}`.
- Modais Bootstrap são controlados via `bootstrap.Modal`.

## Licença
Este projeto é para estudo/demonstração. Atualize com sua licença preferida.