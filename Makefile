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

check_pnpm:
	@command -v pnpm >/dev/null 2>&1 || { echo >&2 "pnpm is required but it's not installed.  Aborting."; exit 1; }

cypress_install: check_pnpm
	cd CypressWebTests; pnpm install

test_cypress: cypress_install
	cd CypressWebTests; env NODE_OPTIONS=--no-warnings pnpm run test

cypress_open: cypress_install
	cd CypressWebTests; pnpm exec cypress open

cypress_clean:
	cd CypressWebTests; pnpm -r exec rm -rf node_modules