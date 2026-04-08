from fastapi import APIRouter, Query, Request, Depends
from models.QRPH_model import DataReceived
import controllers.QRPH_controller as controller

router = APIRouter(prefix="/sim", tags=["SIM"])

@router.post("/QRPH-Generate-QR")
def generate_qr(data: DataReceived):
    return controller.save_generated_qr(data)

@router.get("/QRPH-Payment-Response{ref_no}")
def payment_response(
    ref_no: str, 
    amount: str, 
    status: str = "Approved",
    transaction_date: str = Query(alias="transaction-date"), 
    trace_number: str = Query(alias="trace-number")
):
    return controller.create_payment_response(
        ref_no, amount, transaction_date, trace_number, status
    )