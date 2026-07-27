# WebApp - API de Boletos

## Tecnologias
- .NET 6
- Entity Framework Core
- PostgreSQL
- AutoMapper
- JWT

## Como rodar

1. Instalar o PostgreSQL e criar um banco vazio
2. Configurar a connection string em `appsettings.json`
3. Rodar as migrations:
```
dotnet ef database update --project Infraestrutura --startup-project WebApp
```

## Autenticação

1. Criar um usuário: `POST /api/Usuario`
2. Fazer login: `POST /api/Usuario/login`
3. Copiar o token retornado
4. Clicar em **Authorize** no Swagger e colar: `Bearer {token}`

## Endpoints

### Banco
- `GET /api/Banco` - lista todos
- `GET /api/Banco/codigo/{codigo}` - busca por código
- `POST /api/Banco` - cria

### Boleto
- `GET /api/Boleto` - lista todos
- `GET /api/Boleto/{id}` - busca por id (calcula juros se vencido)
- `POST /api/Boleto` - cria

### Usuario
- `POST /api/Usuario` - cria (sem login)
- `POST /api/Usuario/login` - gera token (sem login)
