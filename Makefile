# Project Variables

PROJECT_NAME ?= ScrumBoard

.PHONY: migrations db

migrations:
	cd ./ScrumBoard.Data && dotnet ef --startup-project ../ScrumBoard.Web migrations add $(mname) && cd ..

db:
	cd ./ScrumBoard.Data && dotnet ef --startup-project ../ScrumBoard.Web/ database update && cd ..

test:
	echo "testing"
