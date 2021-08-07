## Run

`docker build -t webapi:v1 .`

`docker network create webapitren`

`docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db --network=webapitren mongo`

`docker run -ti --rm -p 8080:80 -e MongoDBSetting:Host=mongo --network=webapitren wepapi:v1`