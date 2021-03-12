# mini-api

Test of FastAPI https://fastapi.tiangolo.com/

$ uvicorn main:app --reload

$ curl -X POST localhost:8000/items/ -H "accept: application/json" -H "Content-Type: application/json" -d "{\"name\":\"Foo\",\"A\":[[1.0, 0.032], [0.032, 1.0]]}"

## Docker

$ docker build . -t svd

$ docker run -i -d -p 8080:5000 svd

$ curl -X POST localhost:8080/items/ -H "accept: application/json" -H "Content-Type: application/json" -d "{\"name\":\"Foo\",\"A\":[[1.0, 0.032], [0.032, 1.0]]}"
