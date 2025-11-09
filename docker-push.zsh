docker build --rm -t xotaapi .
docker tag xotaapi docker.lan:5000/xotaapi
docker push docker.lan:5000/xotaapi