Para criar o banco de dados selecione o projeto Web.Api.Infra como default project no Package Manager Console e navegue até a pasta "src/Web.Api.Infra".

Após estar dentro da pasta do projeto Web.Api.Infra use o comando abaixo:

dotnet ef database update --startup-project "../Web.Api.Servico"
