mkdir .\build\lib\net40
xcopy /y .\DynamicObjectMapper\bin\Debug\DynamicObjectMapper.* .\build\lib\net40
nuget pack .\build\DynamicObjectMapper.nuspec
