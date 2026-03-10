from fastapi import APIRouter, Query, Request, Depends
from models.Interop_model import GenerateQR
import controllers.Interop_controller as controller

router = APIRouter(prefix="/sim", tags=["SIM"])

@router.post("/Interop-Generate-QR")
def generate_qr(data: GenerateQR):
    return controller.save_generate_QR(data)

@router.get("/Interop-Payment-Response")
def payment_response(
    mid: str, 
    amount: str,
    txntype: str,
    billnum: str = Query(alias="bill-number"),
    refID: str = Query(alias="referenceID"),
    terID: str = Query(alias="terminal-ID"),
):
    return controller.create_payment_response(
        mid, billnum, refID, terID, amount, txntype
    )
