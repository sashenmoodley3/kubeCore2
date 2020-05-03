FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
WORKDIR /app

RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENV ASPNETCORE_URLS http://*:8080;https://*:443
EXPOSE 8080
EXPOSE 443

ENTRYPOINT ["dotnet", "FlateOrchestrationLayer.dll"]