from fastapi import HTTPException, status
from datetime import datetime
import json
import os

from controllers.pos_controller import JSON_FILE

SIM_FILE = "data/sim_data.json"
RESPONSE_FILE = "data/response.json"
APPROVED_FILE = "data/approved.json"
DECLINE_FILE = "data/decline.json"

temp_amount = ""

def get_callbacks():
    """Helper to load the current stored data."""
    if not os.path.exists(SIM_FILE):
        return []
    with open(SIM_FILE, "r") as file:
        try:
            return json.load(file)
        except json.JSONDecodeError:
            return []

def save_data_received(data):
    all_records = get_callbacks()
    new_entry = data.model_dump()

    global temp_amount
    temp_amount = str(data.Amount)

    if os.path.exists(RESPONSE_FILE):
        with open(RESPONSE_FILE, "r") as f:
            response_list = json.load(f)
            if isinstance(response_list, list) and len(response_list) > 0:
                extra_data = response_list[0]
                new_entry.update(extra_data)

    all_records.append(new_entry)
    with open(SIM_FILE, "w") as file:
        json.dump(all_records, file, indent=4)
    return new_entry

def approve_payment_dynamic(data):
    # Access the data using dot notation (e.g., data.amount)
    response = {
        "InvoiceNumber": data.trace_number,
        "ReferenceNumber": "1234567890",
        "Amount": data.amount,
        "Date": data.transaction_date,
        "Time": datetime.now().strftime("%H:%M:%S"),
        "MerchantID": data.merchant_id,
        "TerminalID": data.terminal_id,
        "TraceNumber": data.trace_number,
        "Status": "Approved"
    }
    
    # ... your existing save/log logic ...
    return response
    
def decline_payment():
    if not os.path.exists(DECLINE_FILE):
        return []
    with open(DECLINE_FILE, "r") as file:
        return json.load(file)