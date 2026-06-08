docker run --rm \
  --name JNpostgre \
  -e POSTGRES_PASSWORD=4649 \
  -e POSTGRES_USER=Jadmin \
  -e POSTGRES_DB=JabNetDatabase \
  -p 5432:5432 \
  -it postgres:17
