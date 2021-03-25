# Iteris.Meetup.CQRS
Projeto de exemplo de utilização do padrão CRQS no .NET com Mediatr.

Ele implementa padrão DDD com eventos de domínio e a utilização de `Pipeline Behaviors`.

Os `commands` fazem a gravação na base SQLite `data.db` disponível no repositório (como em um banco de persistência), e a `query` faz a consulta do dado pronto a partir de um cache em memória que simula um banco de dados de leitura (o cache só é preenchido após a execução das gravações).

## Bibliotecas utilizadas:
- MediatR
- FluentValidation
- Dapper
- Microsoft.Extensions.Caching.Memory
- Swashbuckle.AspNetCore
- System.Data.SQLite


## Execução
Para executar o projeto, em um terminal, execute o seguinte comando a partir do diretório raiz do projeto:

```dotnet run -p .\src\Iteris.Meetup.CQRS.Api\Iteris.Meetup.CQRS.Api.csproj```

Após o serviço iniciar, acesse a página do Swagger por um navegador para verificar e executar os endpoints disponíveis no projeto:

```https://localhost:5001/swagger/```

- POST /users - Criação de usuário com endereço
- POST /users/{userId}/address - Criação de endereço para um usuário
- GET /users/{userId}/addresses - Retorna os endereços cadastrados para um usuário

Utilize o arquivo `exemplos_cadastros.txt` disponível no repositório para obter modelos dos objetos das chamadas.