docker-compose down
docker image rm vehicle/frontend
docker image rm vehicle/backend
docker image rm vehicle/notifications_sevice

git pull

cd Vehicle.Frontend
docker build -t vehicle/frontend .
cd ..

docker build -t vehicle/backend .

cd Vehicle.NotificationsService
docker build -t vehicle/notifications_service .
cd ..

docker-compose up -d