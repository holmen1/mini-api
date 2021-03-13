# mini-api

Test of FastAPI https://fastapi.tiangolo.com/

Dockerize numpy calculation, call from C#

Passing matrix A: [[1.0, 0.032], [0.032, 1.0]]

Factorize A = U S Vh

Check that A == A' = S[0] U[:,0] Vh[0,:] + S[1] U[:,1] Vh[1,:] 



## api

/api$ uvicorn main:app --reload

$ curl -X POST localhost:8000/items/ -H "accept: application/json" -H "Content-Type: application/json" -d "{\"name\":\"Foo\",\"A\":[[1.0, 0.032], [0.032, 1.0]]}"

## Docker

/api$ docker build . -t svd

/api$ docker run -i -d -p 8080:5000 svd

$ curl -X POST localhost:8080/items/ -H "accept: application/json" -H "Content-Type: application/json" -d "{\"name\":\"Foo\",\"A\":[[1.0, 0.032], [0.032, 1.0]]}"

{"U":[[-0.7071067811865472,-0.7071067811865478],[-0.707106781186548,0.7071067811865472]],"S":[1.0319999999999998,0.968],"Vh":[[-0.7071067811865472,-0.7071067811865479],[-0.7071067811865479,0.7071067811865472]]}

## console

/console$ dotnet run

{"name":"Foo","A":[[1.0, 0.032], [0.032, 1.0]]}

Factorize A = U S Vh

a11: 1 		 a12: 0.032

a21: 0.032 	 a22: 1




