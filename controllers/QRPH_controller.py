from datetime import datetime
import json
import os

SIM_FILE = "data/QRPH_data.json"
RESPONSE = "data/QRPH_payment_response.json"

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

    extra_data = {
        "Status": "",
        "Error": {
            "Code": "",
            "Description": ""
        },
        "CodeImgUrl": "https://api.qrserver.com/v1/create-qr-code/?size=250x250&data=https://192.168.1.64:8000/sim/QRPH-Response001",
        "CodeUrl": "https://api.qrserver.com/v1/create-qr-code/?size=250x250&data=https://192.168.1.64:8000/sim/QRPH-Response001",
    }
    new_entry.update(extra_data)

    all_records.append(new_entry)
    with open(SIM_FILE, "w") as file:
        json.dump(all_records, file, indent=4)
    return new_entry

def create_payment_response(ref_no, amount, date, trace, status_choice="Approved"):
    response = {
        "InvoiceNumber": trace, 
        "ReferenceNumber": ref_no,
        "Amount": amount,           
        "Date": date,               
        "Time": datetime.now().strftime("%H:%M:%S"),
        "CardNumber": "4834420000001110",
        "TraceNumber": trace,
        "ApprovalCode": "123456" if status_choice == "Approved" else "000000",
        "Status": status_choice,
        "Reason": status_choice,
    }

    with open(RESPONSE, "w") as file:
            json.dump(response, file, indent=4)

    return response
