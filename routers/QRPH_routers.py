from fastapi import APIRouter, HTTPException, Query, status
from models.QRPH_model import Callback, DataReceived 
import controllers.QRPH_controller as controller

router = APIRouter(prefix="/sim", tags=["SIM"])

@router.get("/view")
def get_callbacks():
    callbacks = controller.get_callbacks() 
    return callbacks

@router.post("/QRPH-Generate-QR")
def generate_qr(data: DataReceived):
    appended_data = controller.save_generated_qr(data)
    return appended_data

#The {ref_no} takes any input after "QRPH-Response"
#Takes URL query parameters for amount, transaction-date, and trace-number
@router.get("/QRPH-Response{ref_no}")
def payment_response(
    ref_no: str, 
    amount: str, 
    transaction_date: str = Query(alias="transaction-date"), 
    trace_number: str = Query(alias="trace-number")
):
    return controller.create_payment_response(
        ref_no, amount, transaction_date, trace_number
    )