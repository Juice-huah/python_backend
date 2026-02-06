from fastapi import APIRouter, HTTPException, status, Depends
from models.sim_model import Callback, DataReceived, TerminalApproval 
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

@router.post("/approve-payment")
def approve_payment(data: TerminalApproval = Depends()):
    return controller.approve_payment_dynamic(data)

@router.post("/decline-payment")
def decline_payment():
    return controller.decline_payment()