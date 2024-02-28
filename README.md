# Sistema de Cadastro de Condomínio

Um sistema para gerenciamento de condomínios, permitindo o cadastro de blocos, unidades, moradores e usuários com diferentes níveis de permissão.

## Instalação

1. Clone o repositório para o seu ambiente local:
> git clone https://github.com/seu-usuario/seu-projeto.git

2. Instale as dependências do projeto:
> dotnet add package microsoft.entityframeworkcore.sqlserver
> dotnet add package microsoft.entityframeworkcore.design
> dotnet add package Microsoft.AspnetCore.Authentication
> dotnet add package Microsoft.AspnetCore.Authentication.JwtBearer
> dotnet add package SecureIdentity

3. Configure o banco de dados e as credenciais do Identity de acordo com as instruções no arquivo `config.js` e digite o comando a baixo para criar o banco.
> dotnet ef migrations add inicialDb
> dotnet ef database update

## Uso

1. Acesse a API utilizando uma ferramenta de cliente HTTP, como: Postman, Insomnia, curl, HTTPie entre outras 

2. Utilize os endpoints da API para realizar operações como cadastro de blocos, unidades, moradores e usuários.

## Contribuição
Contribuições são bem-vindas! Se você deseja contribuir com melhorias, novas funcionalidades ou correções de bugs, siga estes passos:
1. Fork o repositório.
2. Crie uma branch para a sua feature (git checkout -b feature/NomeDaFeature).
3. Commit suas mudanças (git commit -am 'Adicionando uma nova feature').
4. Push para a branch (git push origin feature/NomeDaFeature).
5. Crie um novo Pull Request.