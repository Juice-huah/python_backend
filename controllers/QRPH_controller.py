from fastapi import HTTPException, status
from datetime import datetime
import json
import os

SIM_FILE = "data/QRPH_data.json"
#Hardcoded status, error, CodeImg, and CodeURL.
ADDTIONAL_DATA_FILE = "data/QRPH_additional_data.json"

def get_callbacks():
    if not os.path.exists(SIM_FILE):
        return []
    with open(SIM_FILE, "r") as file:
        try:
            return json.load(file)
        except json.JSONDecodeError:
            return []

def save_generated_qr(data):
    all_records = get_callbacks()
    new_entry = data.model_dump()

    #add addtional data from addtional_callback_data.json if exists
    if os.path.exists(ADDTIONAL_DATA_FILE):
        with open(ADDTIONAL_DATA_FILE, "r") as f:
            addtional_data = json.load(f)
            if isinstance(addtional_data, list) and len(addtional_data) > 0:
                extra_data = addtional_data[0]
                new_entry.update(extra_data)

    all_records.append(new_entry)
    with open(SIM_FILE, "w") as file:
        json.dump(all_records, file, indent=4)
    return new_entry

#Payment response that takes URL
def create_payment_response(ref_no, amount, date, trace):
    response = {
        "InvoiceNumber": trace, 
        "ReferenceNumber": ref_no,
        "Amount": amount,           
        "Date": date,               
        "Time": datetime.now().strftime("%H:%M:%S"),
        "CardNumber": "4834420000001110",
        "TraceNumber": trace,
        "ApprovalCode": "123456",
        "Status": "Approved",
        "Reason": "Approved"
    }
    return response
