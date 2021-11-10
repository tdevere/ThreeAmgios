#/bin/bash

echo "TDEVERE post clone script start - from solution directory"

ls -l

/bin/bash -c nuget restore './ThreeAmgios.sln' 

echo "TDEVERE post clone script end"