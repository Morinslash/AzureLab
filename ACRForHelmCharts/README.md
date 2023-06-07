[offical doc](https://learn.microsoft.com/en-us/azure/container-registry/container-registry-helm-repos)

## Azure CLI
```bash
docker run -it --rm --name azure-cli -v ${pwd}\ACRForHelmCharts:/work -w /work --entrypoint /bin/sh mcr.microsoft.com/azure-cli:latest
```

```bash
az login
```
Azure CLI should display available subscriptions after successful login

```bash
az account set --subscription <subscription_id>
```

## Creating ACR

```bash
az group create --name testRegistryGroup --location westeurope 
```

```bash
az acr create --name morinslashtestregistry --resource-group testRegistryGroup --sku basic
```

```bash
az acr show --name morinslashtestregistry --resource-group testRegistryGroup --query "{acrLoginServer: loginServer}" --output table
```

## Log into regiry

```bash
az acr login --name morinslashtestregistry
```

## Creating Helm chart
```bash
helm create testchartapp
```

## Install default Chart
```bash
cd testchartapp
helm install testchartapp .
```

## Packaging and uploading to registry

```bash
helm package ./testchartapp --version 0.1.0
```

```bash
helm push testchartapp-0.1.0.tgz oci://morinslashtestregistry.azurecr.io/helm
```
## Installing from ACR
```bash
helm install testapp oci://morinslashtestregistry.azurecr.io/helm/testchartapp --version 0.1.0
```

## Pull locally
```bash
helm pull oci://morinslashtestregistry.azurecr.io/helm/testchartapp --version 0.1.0
```
