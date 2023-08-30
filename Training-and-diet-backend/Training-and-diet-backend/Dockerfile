#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Training-and-diet-backend/Training-and-diet-backend.csproj", "Training-and-diet-backend/"]
RUN dotnet restore "Training-and-diet-backend/Training-and-diet-backend.csproj"
COPY . .
WORKDIR "/src/Training-and-diet-backend"
RUN dotnet build "Training-and-diet-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Training-and-diet-backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Training-and-diet-backend.dll"]