from datetime import datetime
import json
import os

SIM_FILE = "data/Interop_genQR_callback.json"
ADDTIONAL_DATA_FILE = "data/Interop_additional_data.json"
RESPONSE_FILE = "data/Interop_payment_response.json"

def get_callbacks():
    if not os.path.exists(SIM_FILE):
        return []
    
    with open(SIM_FILE, "r") as file:
        try:
            data = json.load(file)
            if isinstance(data, dict):
                return [data] 
            return data if isinstance(data, list) else []
        except json.JSONDecodeError:
            return []

def save_generate_QR(data):
    all_records = get_callbacks() 

    response_data = {
        "MerchantID": data.MerchantID,
        "BillNumber": data.BillNumber,
        "TerminalID": data.TerminalID,
        "ReferenceNumber": data.ReferenceNumber,
        "CreditMID": data.CreditMID,
        "Amount": data.Amount,
        "MerchantKey" : data.MerchantKey
    }

    if os.path.exists(ADDTIONAL_DATA_FILE):
        with open(ADDTIONAL_DATA_FILE, "r") as f:
            additional = json.load(f)
            if additional:
                response_data.update(additional[0])

    all_records.append(response_data) 

    with open(SIM_FILE, "w") as file:
        json.dump(all_records, file, indent=4) 

    return response_data

def create_payment_response(mid, billnum, refID, terID, amount, txntype):
    return save_payment_response({
        "Status": "Success",
        "MID": mid,
        "BillNumber": billnum,
        "ReferenceID": refID,
        "ConsentID": "10202603041066657388",
        "TxnType": txntype,
        "Currency": "PHP",
        "TerminalID": terID,
        "RRN": "026063327372",
        "ApprovalCode": "327372",
        "AuthCode": "00",
        "AccountType": "2",
        "CardNo": "001419****9533",
        "AuthTimeStamp": "03042026150448",
        "Ref Num": "QR-PAY2-17726078-91007776",
        "Amount": amount,
        "OutTradeNo": "006004",
        "OutTransactionID": "QR-PAY2-17726078-91007776"
    })

def save_payment_response(data):
    with open(RESPONSE_FILE, "w") as file:
        json.dump(data, file, indent=4) 

    response_data = {
        "MID": data["MID"],
        "BillNumber": data["BillNumber"],
        "ReferenceID": data["ReferenceID"],
        "TerminalID": data["TerminalID"],
        "Amount": data["Amount"],
        "TxnType": data["TxnType"]
    }

    return response_data