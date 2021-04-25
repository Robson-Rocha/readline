param(
    [string]$p1 = "Debug"
)

dotnet restore
dotnet build ".\src\ReadLine2" -c $p1
dotnet build ".\src\ReadLine2.Demo" -c $p1
dotnet build ".\test\ReadLine2.Tests" -c $p1
