# MOVESTestPermitMicroServices
11 POC MOVES Test Permit Micro Services

This is a sample POC .NET Application that was modelled from the existing MOVES Test Permit Display screen.

The .NET application is based on .NET Core Version 5.0. It was built using Visual Studio for MAC.

The .NET solution is compose of 2 projects: TestPermitMicroFrontEnd, which is the Web UI, and the TestPermitMicroAPI, which is the API layer that connects to the database. The database is built using PostGresSQL DB. The architecture is shown in this diagram.

![Architecture Diagram](TestPermitArchitecture.jpg?raw=true "Architecture Diagram")

For the TestPermitMicroAPI, the API layer uses API Web solution utilizes the dotnet tools: dotnet-aspnet-codegenerator (used to generate API controllers) and dotnet-ef (used to generate entity framework migration). To add the tools, the following script are executed in the developer workstation:
```
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-ef
```
The TestPermitMicroAPI project also uses the following libraries:
- Microsoft.VisualStudio.Web.CodeGeneration.Design Version 5
- Microsoft.EntityFrameworkCore.Design Version 5
- Microsoft.EntityFrameworkCore.SqlServer Version 5
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore Version 5
- Npgsql.EntityFrameworkCore.PostgreSQL Version 5
- EFCore.NamingConventions Version 5
- Swashbuckle.AspNetCore Version 5
```
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version=5.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version=5.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version=5.0
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --version=5.0
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version=5.0
dotnet add package EFCore.NamingConventions --version=5.0
dotnet add package Swashbuckle.AspNetCore --version=5.0
```

These are commands are used to generate the DB Migration (Code First Approach) and API Controller:
```
dotnet ef migrations add AddTables
dotnet aspnet-codegenerator controller \
    -name OperatorAuxsController \
    -m OperatorAux \
    -dc OperatorMicroServicesContext \
    -async \
    -api \
    -outDir Controllers
```
Within the OpenShift environment, the TestPermitMicroAPI is deployed on the cluster using Source to Image (S2I) feature of OpenShift. By default, OpenShift creates the application with the following key OpenShift/Kubernetes artifacts:
- BuildConfig
- Deployment
- ReplicaSet
- Pod
- Service

A configmap (testpermit-microservices-config) was create which contains the information such as the database service and database name and injected as configuration to the pod as Environment Variables. 

The TestPermitMicroAPI also makes use of Vault to store the database user name and password. Within Vault, a key value secret (testpermit-psql-credential) was created with policy and auth roles created to allow the service account (testpermit-microservices-serviceaccount) access the keys. The service account is created within the OpenShift cluster.
```
cat <<EOF > /home/vault/tpmicro-policy.hcl
path "secret*" {
  capabilities = ["read"]
}
EOF

vault policy write testpemit-microservices-policy /home/vault/tpmicro-policy.hcl

vault write auth/kubernetes/role/testpermit-microservices-role \
   bound_service_account_names=testpermit-microservices-serviceaccount \
   bound_service_account_namespaces=test-permit \
   policies=testpemit-microservices-policy \
   ttl=1h
   
vault kv put secret/testpermit-psql-credential username=user123 password=HARDpassWORD4Me
```
As the final step, the TestPermitMicroAPI make use of the Kubernetes Mutating Admission Hook feature to add the Vault Agent Injection init / side car pod to the deployment. This is done by applying the proper annotations to the deployment yaml configuration.
```
spec:
  template:
    metadata:
      annotations:
        vault.hashicorp.com/agent-inject: "true"
        vault.hashicorp.com/agent-inject-status: "update"
        vault.hashicorp.com/agent-inject-secret-testpermit-psql-credential.txt: "secret/testpermit-psql-credential"
        vault.hashicorp.com/agent-inject-template-testpermit-psql-credential.txt: |
          {{- with secret "secret/testpermit-psql-credential" -}}
          databaseuser={{ .Data.username }}
          databasepassword={{ .Data.password }}
          {{- end -}}
        vault.hashicorp.com/role: "testpermit-microservices-role"
```
The init / sidecar pod connects to vault via token to retrieve the keys and write the credential in a property file under "/vault/secret/testpermit-psql-credential.txt" which is mounted unto the web API pod. The application is then configured to read the properties at startup to retrieve the database credentials.
See the following references:
- https://learn.hashicorp.com/tutorials/vault/kubernetes-sidecar?in=vault/kubernetes
- https://www.hashicorp.com/blog/injecting-vault-secrets-into-kubernetes-pods-via-a-sidecar

As for the TestPermitMicroFrontEnd project, the web application is built using ASP.NET Razor with the following libraries:
- Bootstrap 4.3.1
- Newtonsoft.Json
```
dotnet add package Newtonsoft.Json
```
The TestPermitMicroFrontEnd project is deployed to the OpenShift cluster using Containerfile build file. Once deployed on OpenShift, the application is setup with a configmap (testpermit-microservices-config) in order to configure the API URL. As with API project, the configuration is injected to the pod using environment variable.
