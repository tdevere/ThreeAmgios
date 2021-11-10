#/bin/bash

echo "TDEVERE post clone script start - from solution directory"

ls -l

nuget restore './ThreeAmgios.sln' 

echo "TDEVERE post clone script end"