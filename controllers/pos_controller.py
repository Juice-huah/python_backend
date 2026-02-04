from fastapi import HTTPException, status
import json
import os

JSON_FILE = "data/test.json"
SALE_FILE = "data/sale.json"

def load_inventory():
    if not os.path.exists(JSON_FILE):
        return []
    with open(JSON_FILE, "r") as file:
        return json.load(file)

def save_inventory(inventory):
    with open(JSON_FILE, "w") as file:
        json.dump(inventory, file, indent=4)

def process_sale(inventory, product_id, quantity):
    for product in inventory:
        if product["id"] == product_id:
            if product["quantity"] >= quantity:
                product["quantity"] -= quantity
                
                sale_record = {
                    "product_id": product_id,
                    "quantity_sold": quantity,
                    "total_price": round(quantity * product["price"], 2)
                }
                
                sales = []
                if os.path.exists(SALE_FILE):
                    with open(SALE_FILE, "r") as f:
                        try: sales = json.load(f)
                        except: sales = []
                
                sales.append(sale_record)
                with open(SALE_FILE, "w") as f:
                    json.dump(sales, f, indent=4)
                
                save_inventory(inventory)
                return sale_record
    return None

def add_product(inventory, product):
    for item in inventory:
        if item["id"] == product.id:
            return None
        
    inventory.append(product.model_dump())
    save_inventory(inventory)
    return {"message": "Success", "product": product}

def delete_product(inventory, product_name):
    for item in inventory:
        if item["name"].lower() == product_name.lower():
            inventory.remove(item)
            save_inventory(inventory)
            return {"message": f"Product '{product_name}' deleted successfully"}
        else:
            return None