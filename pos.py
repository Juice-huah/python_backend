from itertools import product
from fastapi import FastAPI, HTTPException, status
from pydantic import BaseModel
import json
import os
app = FastAPI()
JSON = "test.json"
SALE = "sale.json"


def load_inventory():
    if not os.path.exists(JSON):
        return [] 
    with open(JSON, "r") as file:
        return json.load(file)
inventory = load_inventory()

def save_inventory(inventory):  
    with open(JSON, "w") as file:
        json.dump(inventory, file, indent=4)


class Product(BaseModel):
    id: int
    name: str
    quantity: int
    price: float

@app.get("/products")
def get_products():
    if inventory is None:
        raise HTTPException(
            status_code=status.HTTP_404_NOT_FOUND, 
            detail="Inventory not loaded")
    else:
        return inventory

@app.post("/add_product")
def add_product(product: Product):
    for item in inventory:
        if item["id"] == product.id:
            raise HTTPException(
            status_code = status.HTTP_400_BAD_REQUEST,
            detail=f"Product with {product.id} ID already exists")
    inventory.append(product.model_dump())
    save_inventory(inventory)
    return {"message": "Product added successfully", "product": product}

@app.put("/update_product/{product_id}")
def update_product(product_id: int, updated_product: Product): 
    for index, product in enumerate(inventory):
        if product["id"] == product_id:
            inventory[index] = updated_product.model_dump()
            save_inventory(inventory)
            return {"message": "Product updated successfully", "product": updated_product}
    raise HTTPException(
        status_code=status.HTTP_404_NOT_FOUND,
        detail=f"Product with ID {product_id} not found")

@app.patch("/update_name/{product_id}")
def update_name(product_id: int, new_name: str):
    for product in inventory:
        if product["id"] == product_id:
            product["name"] = new_name
            save_inventory(inventory)
            return {"message": "Product name updated successfully", "product": product}
    raise HTTPException(
        status_code=status.HTTP_404_NOT_FOUND,
        detail=f"Product with ID {product_id} not found")

@app.delete("/delete_product/{product_name}")
def delete_product(product_name: str):
    for index, product in enumerate(inventory):
        if product["name"].lower() == product_name.lower():
            del inventory[index]
            save_inventory(inventory)
            return {"message": f"{product_name} has been deleted successfully"}
        else:
            raise HTTPException(
                status_code=status.HTTP_404_NOT_FOUND,
                detail=f"Product with name {product_name} not found")   

@app.post("/sell/{product_id}")
def sell_product(product_id: int, quantity: int):
    for product in inventory:
        if product["id"] == product_id:
            if product["quantity"] >= quantity:
                product["quantity"] -= quantity
                sale_record = {
                    "product_id": product_id,
                    "quantity_sold": quantity,
                    "total_price": quantity * product["price"]
                }
                if os.path.exists(SALE):
                    with open(SALE, "r") as sale_file:
                        sale = json.load(sale_file)
                else:
                    sale = []
                sale.append(sale_record)
                with open(SALE, "w") as sale_file:
                    json.dump(sale, sale_file, indent=4)
                save_inventory(inventory)
                return {"message": "Product sold successfully", "sale_record": sale_record}
            else:
                raise HTTPException(
                    status_code=status.HTTP_400_BAD_REQUEST,
                    detail="Insufficient stock to complete the sale")
    raise HTTPException(
        status_code=status.HTTP_404_NOT_FOUND,
        detail=f"Product with ID {product_id} not found")