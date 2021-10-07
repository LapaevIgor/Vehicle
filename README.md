# Vehicle
The application of the purchase and sale of vehicles.

docker run -p 8025:8025 -p 1025:1025 mailhog/mailhog
docker run -d --name dev-rabbit -p 5672:5672 -p 5673:5673 -p 15672:15672 rabbitmq:3-management
docker run -p 9000:9000 -p 9001:9001 minio/minio server /data --console-address ":9001"
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU13-ubuntu-20.04