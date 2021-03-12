from typing import List, Optional
from fastapi import FastAPI

import numpy as np


app = FastAPI()
from pydantic import BaseModel

class Item(BaseModel):
    name: str
    # to be matrix
    A: List[List[float]] = []


@app.get("/")
def read_root():
    return {"Hello": "World"}


@app.get("/items/{item_id}")
def read_item(item_id: int, q: Optional[str] = None):
    return {"item_id": item_id, "q": q}


@app.post("/items/")
async def create_item(item: Item):
    A = np.array(item.A)
    U, S, Vh = np.linalg.svd(A)
    return {"U": U.tolist(),"S": S.tolist(),"Vh": Vh.tolist()}