cd ..
cd ..
cd MakeDoc
MarkdownGenerator.exe KKBOX.OpenAPI.Universal.dll
IF EXIST ".\md\Home.md" copy ".\md\Home.md" "..\Doc"
IF EXIST ".\md\KKBOX.OpenAPI.md" copy ".\md\KKBOX.OpenAPI.md" "..\Doc"
IF EXIST ".\md\KKBOX.OpenAPI.ServiceModel.md" copy ".\md\KKBOX.OpenAPI.ServiceModel.md" "..\Doc"