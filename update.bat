docker-compose down
docker image rm vehicle/frontend
docker image rm vehicle/backend
docker image rm vehicle/notifications_sevice

git pull

cd Vehicle.Frontend
docker build -t vehicle/frontend .
cd ..

docker build -t vehicle/backend .

docker build -t vehicle/notifications_sevice .

docker-compose up -d