from fastapi import APIRouter, HTTPException, status
from models.sim_model import Callback, DataReceived 
import controllers.sim_controller as controller

router = APIRouter(prefix="/sim", tags=["SIM"])

@router.get("/view")
def get_callbacks():
    callbacks = controller.get_callbacks() 
    return callbacks

@router.post("/receive")
def generate_qr(data: DataReceived):
    appended_data = controller.save_data_received(data)
    return appended_data

@router.get("/approve-payment")
def approve_payment(
    amount: str, 
    transaction_date: str, 
    merchant_id: str, 
    terminal_id: str, 
    trace_number: str
):
    return controller.approve_payment_dynamic(
        amount, transaction_date, merchant_id, terminal_id, trace_number
    )

@router.get("/decline-payment")
def decline_payment():
    return controller.decline_payment()