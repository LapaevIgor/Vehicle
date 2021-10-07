docker-compose down
docker image rm vehicle/frontend
docker image rm vehicle/backend

git pull

cd Vehicle.Frontend
docker build -t vehicle/frontend .
cd ..

docker build -t vehicle/backend .

docker-compose up -d