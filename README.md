# mini-api

Test of FastAPI https://fastapi.tiangolo.com/

$ uvicorn main:app --reload

$ curl -X POST localhost:8000/items/ -H  "accept: application/json" -H  "Content-Type: application/json" -d "{\"name\":\"Foo\",\"price\":45.2}"