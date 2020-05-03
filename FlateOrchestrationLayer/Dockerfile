FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app

ENV ASPNETCORE_URLS http://*:8080;https://*:443
EXPOSE 8080
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["FlateOrchestrationLayer/FlateOrchestrationLayer.csproj", "FlateOrchestrationLayer/"]
RUN dotnet restore "FlateOrchestrationLayer/FlateOrchestrationLayer.csproj"
COPY . .
WORKDIR "/src/FlateOrchestrationLayer"
RUN dotnet build "FlateOrchestrationLayer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FlateOrchestrationLayer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .


ENTRYPOINT ["dotnet", "FlateOrchestrationLayer.dll"]