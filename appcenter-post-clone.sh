#/bin/bash

echo "TDEVERE post clone script start - from solution directory"

/bin/bash -c nuget restore 'ThreeAmgios.sln' -DisableParallelProcessing

echo "TDEVERE post clone script end"