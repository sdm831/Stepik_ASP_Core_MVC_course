#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Stepik_ASP_Core_MVC_course/Stepik_ASP_Core_MVC_course.csproj", "Stepik_ASP_Core_MVC_course/"]
RUN dotnet restore "Stepik_ASP_Core_MVC_course/Stepik_ASP_Core_MVC_course.csproj"
COPY . .
WORKDIR "/src/Stepik_ASP_Core_MVC_course"
RUN dotnet build "Stepik_ASP_Core_MVC_course.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stepik_ASP_Core_MVC_course.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stepik_ASP_Core_MVC_course.dll"]