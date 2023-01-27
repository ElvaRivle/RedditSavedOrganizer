FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RedditOrganizeSaved.csproj", "./"]
RUN dotnet restore "RedditOrganizeSaved.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "RedditOrganizeSaved.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedditOrganizeSaved.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedditOrganizeSaved.dll"]
