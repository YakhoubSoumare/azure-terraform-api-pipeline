# API Development Commands

## After Changing the Connection String

```bash
    dotnet build
    dotnet ef database update
    dotnet run
```


## After Modifying a Model

```bash
    dotnet ef migrations add <MigrationName>
    dotnet ef database update
```


## To Reapply Latest Migration (e.g., after DB reset)

```bash
    dotnet ef database update
```

## Test the API

- Run app with the HTTPS profile
```bash
    dotnet run --launch-profile "https"
```
or

```bash
    dotnet run
```