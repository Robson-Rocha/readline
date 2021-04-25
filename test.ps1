dotnet test .\test\ReadLine2.Tests\ReadLine2.Tests.csproj
if ($LastExitCode -ne 0) { $host.SetShouldExit($LastExitCode) }