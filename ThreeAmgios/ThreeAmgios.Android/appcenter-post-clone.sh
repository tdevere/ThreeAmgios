echo "TDEVERE BEGIN"

/bin/sh -c 'if [ -f yarn.lock ]; then { yarn install --network-timeout=600000 && yarn list --depth=0; } else npm install; fi'

echo "TDEVERE END"