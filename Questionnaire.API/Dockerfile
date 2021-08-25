#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Questionnaire.API/Questionnaire.API.csproj", "Questionnaire.API/"]
COPY ["Questionnaire.Infrastructure/Questionnaire.Infrastructure.csproj", "Questionnaire.Infrastructure/"]
COPY ["Questionnaire.Core/Questionnaire.Core.csproj", "Questionnaire.Core/"]
COPY ["Questionnaire.Application/Questionnaire.Application.csproj", "Questionnaire.Application/"]
RUN dotnet restore "Questionnaire.API/Questionnaire.API.csproj"
COPY . .
WORKDIR "/src/Questionnaire.API"
RUN dotnet build "Questionnaire.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Questionnaire.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Questionnaire.API.dll"]
