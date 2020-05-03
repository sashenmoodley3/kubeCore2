docker build -t slashy/orc-api:latest -t slashy/orc-api:$SHA -f ./FlateOrchestrationLayer/Dockerfile ./FlateOrchestrationLayer

docker push slashy/orc-api:latest

docker push slashy/orc-api:$SHA

kubectl apply -f k8s
kubectl set image deployments/orcapi-deployment server=slashy/orc-api:$SHA
