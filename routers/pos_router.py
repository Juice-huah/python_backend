from fastapi import APIRouter, HTTPException, status
from models.product import Product
import controllers.pos_controller as controller

router = APIRouter(prefix="/pos", tags=["POS"])

@router.get("/products")
def get_products():
    inventory = controller.load_inventory() 
    return inventory

@router.post("/sell/{product_id}")
def sell(product_id: int, quantity: int):
    inventory = controller.load_inventory() 
    result = controller.process_sale(inventory, product_id, quantity)
    
    if result:
        return {"message": "Success", "data": result}
    raise HTTPException(status_code=400, detail="Sale failed (Check ID or Stock)")

@router.post("/add_product")
def add_product(product: Product):
    inventory = controller.load_inventory()
    result = controller.add_product(inventory, product)

    if result is None:
        raise HTTPException(status_code=400, detail="ID already exists")
    return result

@router.delete("/delete_product/{product_name}")
def delete_product(product_name: str):
    inventory = controller.load_inventory()
    result = controller.delete_product(inventory, product_name)
    
    if result is None:
        raise HTTPException(status_code=400, detail="Product not found")
    return result