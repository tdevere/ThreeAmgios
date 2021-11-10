#/bin/bash

echo "TDEVERE post clone script start"

/bin/bash -c nuget restore 'ThreeAmgios.sln' -DisableParallelProcessing

echo "TDEVERE post clone script end"