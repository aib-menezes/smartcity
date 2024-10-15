# Smart City

Bem-vindo à nossa API para gestão de segurança em cidades inteligentes! 🚀

## Pré-requisitos

Antes de tudo, vamos garantir que você tenha as ferramentas necessárias para rodar a aplicação. Você vai precisar de:

- **Java 21**
- **Git**
- **Docker**

## Estrutura do Projeto

Dê uma olhada na estrutura do nosso projeto. Ele é organizado assim:

- **Controllers**: Aqui estão os controladores da API, responsáveis por gerenciar as requisições.
- **Models**: São as definições dos nossos modelos de dados.
- **Services**: Onde a mágica acontece! Contém a lógica de negócios da aplicação.
- **Views**: Representações para a camada de visualização, se necessário.
- **wwwroot**: O lugar para os arquivos estáticos da aplicação.

Além disso, você encontrará alguns arquivos de configuração importantes:

- **Dockerfile**: Este arquivo diz ao Docker como construir a imagem.
- **compose.yaml**: Configurações dos serviços do Docker.
- **appsettings.Development.json**: Configurações específicas para o seu ambiente de desenvolvimento.
- **requirements.txt** e **pom.xml**: Listas de dependências para gerenciar as bibliotecas que usamos.

## Inicializando e Executando o Projeto

Vamos lá! Aqui estão os passos para você colocar a aplicação para rodar:

1. **Clone o repositório:**

   Primeiro, pegue uma cópia do nosso projeto. Use o comando abaixo:

   ```sh
   git clone <URL_DO_REPOSITORIO>
   ```

2. **Acesse o diretório do projeto:**

   Navegue até a pasta onde você clonou o projeto:

   ```sh
   cd live
   ```

3. **Inicie a aplicação com Docker:**

   Agora, é hora de colocar tudo para funcionar! Execute o seguinte comando:

   ```sh
   docker compose up --build
   ```

   Isso vai construir as imagens necessárias e iniciar os serviços que definimos.

4. **Verifique se tudo está rodando:**

   Após a inicialização, você pode acessar a API em `http://localhost:5095/index.html`. Faça um teste!

## Testes Unitários

Quer garantir que tudo está funcionando? Execute os testes unitários com este comando:

```sh
./mvnw test
```

## Documentação Online (OpenAPI)

Ah, e não se esqueça de conferir a documentação da API! Você pode acessá-la através da interface do Swagger em:

[Swagger UI](http://localhost:5095/swagger-ui/index.html)