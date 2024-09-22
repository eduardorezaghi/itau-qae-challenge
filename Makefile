SOLUTION_FILE = itau-qae-challenge.sln
PROJECT_FILE = IonAppSpecFlow/IonAppSpecFlow.csproj
NUNIT_PROJECT_FILE = NUnitBackendTests/NUnitBackendTests.csproj

dotnet_restore:
	dotnet restore $(SOLUTION_FILE)

dotnet_build: dotnet_restore
	dotnet build $(SOLUTION_FILE)

test_appium: dotnet_build
	dotnet test $(PROJECT_FILE) --logger:trx --property:WarningLevel=0

dotnet_appium_clean:
	dotnet clean $(PROJECT_FILE)

clean: dotnet_clean

dotnet_restore_nunit:
	dotnet restore $(NUNIT_PROJECT_FILE)

dotnet_build_nunit: dotnet_restore_nunit
	dotnet build $(NUNIT_PROJECT_FILE)

test_nunit: dotnet_build_nunit
	dotnet test $(NUNIT_PROJECT_FILE) --logger:trx --property:WarningLevel=0

dotnet_clean_nunit:
	dotnet clean $(NUNIT_PROJECT_FILE)

dotnet_clean: dotnet_appium_clean dotnet_clean_nunit
