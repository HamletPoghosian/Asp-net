#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 51201
EXPOSE 44372

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["UsersData/UsersData.csproj", "UsersData/"]
RUN dotnet restore "UsersData/UsersData.csproj"
COPY . .
WORKDIR "/src/UsersData"
RUN dotnet build "UsersData.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UsersData.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UsersData.dll"]