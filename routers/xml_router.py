from fastapi import APIRouter, Query
from pydantic import BaseModel
from controllers.xml_controller import create_payment_response, generate_qr, get_all_transactions_xml

router = APIRouter()

# What type of data
class QRRequest(BaseModel):
    MerchantID: str
    BillNumber: str
    TerminalID: str
    ReferenceNumber: str
    CreditMID: str
    Amount: str

@router.post("/XML-Generate-QR")
def generate(payload: QRRequest):
    return generate_qr(payload.model_dump())

@router.get("/XML-View-Transactions")
def view_transactions():
    return get_all_transactions_xml()
    
# Changed to GET and added the 'status' parameter to match the JSON backend
@router.get("/XML-Payment-Response/{ref_no}")
def payment_response(
    ref_no: str,
    amount: str,
    status: str = "Approved", 
    transaction_date: str = Query(alias="transaction-date"),
    trace_number: str = Query(alias="trace-number")
):
    return create_payment_response(ref_no, amount, transaction_date, trace_number, status)