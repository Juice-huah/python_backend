from fastapi import FastAPI
from pydantic import BaseModel

app = FastAPI()



# "Database"
inventory = [
    {"id": 1, "name": "Laptop", "quantity": 10, "price": 999.99},
    {"id": 2, "name": "Smartphone", "quantity": 25, "price": 599.99},
    {"id": 3, "name": "Tablet", "quantity": 15, "price": 399.99},
    {"id": 4, "name": "Headphones", "quantity": 50, "price": 149.99},
    {"id": 5, "name": "Smartwatch", "quantity": 30, "price": 249.99}
]

class Product(BaseModel):
    id: int
    name: str
    quantity: int
    price: float

@app.get("/products")
def get_products():
    return inventory

@app.post("/add_product")
def add_product(product: Product):
    inventory.append(product.model_dump())
    return {"message": "Product added successfully", "product": product}