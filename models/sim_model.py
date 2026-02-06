from pydantic import BaseModel
from typing import Optional

class ErrorDetails(BaseModel):
    Code: Optional[int] = ""
    Description: Optional[str] = ""

class Callback(BaseModel):
    MerchantID: int
    BillNumber: int
    TerminalID: int
    ReferenceNumber: int
    CreditMID: int
    Amount: float  
    Status: str
    Error: ErrorDetails
    CodeImgUrl: str
    CodeUrl: str

class DataReceived(BaseModel):
    MerchantID: int 
    BillNumber: int
    TerminalID: int
    ReferenceNumber: int
    CreditMID: int
    Amount: float     