FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/KnockoutJS.Web/KnockoutJS.Web.csproj src/KnockoutJS.Web/
COPY src/KnockoutJS.Core/KnockoutJS.Core.csproj src/KnockoutJS.Core/
COPY src/KnockoutJS.EFCore/KnockoutJS.EFCore.csproj src/KnockoutJS.EFCore/
COPY src/KnockoutJS.Application/KnockoutJS.Application.csproj src/KnockoutJS.Application/
RUN dotnet restore src/KnockoutJS.Web/KnockoutJS.Web.csproj
COPY . .
WORKDIR /src/src/KnockoutJS.Web
RUN dotnet build KnockoutJS.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish KnockoutJS.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
RUN cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
ENTRYPOINT ["dotnet", "KnockoutJS.Web.dll"]
