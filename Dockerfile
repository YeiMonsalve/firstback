# Etapa de construcción 
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build 
WORKDIR /app 
# Copiar archivos del proyecto y restaurar dependencias 
COPY . .  
RUN dotnet restore  
# Compilar y publicar la aplicación 
RUN dotnet publish -c Release -o /out  
# Etapa de ejecución en una imagen optimizada 
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime 
WORKDIR /app 
# Copiar la aplicación publicada 
COPY --from=build /out .  
# Exponer el puerto para la aplicación 
EXPOSE 8080 
# Comando para ejecutar la aplicación 
ENTRYPOINT ["dotnet", "BackendProject.dll"]
