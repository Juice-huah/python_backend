from fastapi import APIRouter, HTTPException, status
from models.sim_model import Callback, DataReceived 
import controllers.sim_controller as controller

router = APIRouter(prefix="/sim", tags=["SIM"])

@router.get("/view")
def get_callbacks():
    callbacks = controller.get_callbacks() 
    return callbacks

@router.post("/receive")
def receive_data(data: DataReceived):
    controller.save_data_received(data)
    return {"message": "Data received and saved successfully"}