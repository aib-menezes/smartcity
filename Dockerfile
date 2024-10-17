# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Cria um diretório para o aplicativo
WORKDIR /app

# Copia o arquivo .csproj e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante do código-fonte e compila o aplicativo
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de execução
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Cria um diretório para o aplicativo
WORKDIR /app

# Copia o aplicativo publicado da etapa de construção
COPY --from=build /app/out .

# Define a variável de ambiente
ENV ASPNETCORE_ENVIRONMENT=Production

# Expõe a porta 8080 que o aplicativo irá escutar
EXPOSE 8080

# Define o comando de entrada
ENTRYPOINT ["dotnet", "SmartCitySecurity.dll"]
