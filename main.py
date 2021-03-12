from typing import List, Optional

from fastapi import FastAPI

app = FastAPI()
from pydantic import BaseModel

class Item(BaseModel):
    name: str
    price: float
    cov: List[float] = []


@app.get("/")
def read_root():
    return {"Hello": "World"}


@app.get("/items/{item_id}")
def read_item(item_id: int, q: Optional[str] = None):
    return {"item_id": item_id, "q": q}


@app.post("/items/")
async def create_item(item: Item):
    return item