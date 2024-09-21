SOLUTION_FILE = itau-qae-challenge.sln
PROJECT_FILE = IonAppSpecFlow/IonAppSpecFlow.csproj

dotnet_restore:
	dotnet restore $(SOLUTION_FILE)

dotnet_build: dotnet_restore
	dotnet build $(SOLUTION_FILE)

test_appium: dotnet_build
	dotnet test $(PROJECT_FILE) --logger:trx --property:WarningLevel=0

dotnet_clean:
	dotnet clean $(SOLUTION_FILE)

clean: dotnet_clean

