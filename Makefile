build:
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
watch:
	dotnet watch --project TodoApp.Api/TodoApp.Api.csproj run
run:
	dotnet run --project TodoApp.Api/TodoApp.Api.csproj
