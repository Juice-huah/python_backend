import models.xml_model as model
from datetime import datetime

def generate_qr(payload: dict):
    # Matches JSON exactly
    payload["Status"] = ""
    payload["Error"] = {
        "Code": "",
        "Description": ""
    }
    # Uses the same API and IP logic from your JSON config
    payload["CodeImgUrl"] = "https://api.qrserver.com/v1/create-qr-code/?size=250x250&data=https://192.168.1.64:8000/xml/QRPH-Response001"
    payload["CodeUrl"] = "https://api.qrserver.com/v1/create-qr-code/?size=250x250&data=https://192.168.1.64:8000/xml/QRPH-Response001"
    payload["IsProcessed"] = "false"
    
    model.save_to_xml(payload)
    
    return model.dict_to_xml_response("DataReceived", payload)


def get_all_transactions_xml():
    return model.read_from_xml()


def create_payment_response(ref_no, amount, transaction_date, trace_number, status_choice="Approved"):
    payload = {}
    payload["InvoiceNumber"] = trace_number
    payload["ReferenceNumber"] = ref_no
    payload["Amount"] = amount
    payload["Date"] = transaction_date  # Changed to "Date" to match JSON
    payload["Time"] = datetime.now().strftime("%H:%M:%S")
    payload["CardNumber"] = "4834420000001110"
    payload["TraceNumber"] = trace_number
    
    # Conditional logic exactly like JSON
    payload["ApprovalCode"] = "123456" if status_choice == "Approved" else "000000"
    payload["Status"] = status_choice
    payload["Reason"] = status_choice
    payload["IsProcessed"] = "false"

    model.save_payment_response_to_xml(payload)
    
    return model.dict_to_xml_response("PaymentResponse", payload)