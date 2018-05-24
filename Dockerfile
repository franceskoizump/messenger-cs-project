#FROM ubuntu:latest
#RUN apt-get update
#RUN apt-get install mysql-server -y
#RUN apt-get install mysql-client -y
#RUN apt install wget -y
#RUN ["wget","https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb"]
#RUN dpkg -i packages-microsoft-prod.deb
FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY —from=build-env /app/out .
ENTRYPOINT ["dotnet", "aspnetapp.dll"]
