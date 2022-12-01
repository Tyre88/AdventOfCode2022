#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AdventOfCode2022/AdventOfCode2022.csproj", "AdventOfCode2022/"]
RUN dotnet restore "AdventOfCode2022/AdventOfCode2022.csproj"
COPY . .
WORKDIR "/src/AdventOfCode2022"
RUN dotnet build "AdventOfCode2022.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdventOfCode2022.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdventOfCode2022.dll"]