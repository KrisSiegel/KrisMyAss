 #!/usr/bin/env bash

rm -rf ./KrisMyAss
git clone https://github.com/KrisSiegel/KrisMyAss.git
cd ./KrisMyAss
dotnet restore
dotnet build -c release