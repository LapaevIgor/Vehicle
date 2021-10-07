docker-compose down
docker image rm vehicle/frontend
docker image rm vehicle/backend

git pull

cd FrontendClientApp
docker build -t vehicle/frontend .
cd ..

docker build -t vehicle/backend .

docker-compose up -d