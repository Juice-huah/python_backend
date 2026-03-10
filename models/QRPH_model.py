from pydantic import BaseModel
from typing import Optional

class ErrorDetails(BaseModel):
    Code: Optional[str] = ""
    Description: Optional[str] = ""

class DataReceived(BaseModel):
    MerchantID: str 
    BillNumber: str
    TerminalID: str
    ReferenceNumber: str
    CreditMID: str
    Amount: str

class ProcessPayment(BaseModel):
    InvoiceNumber: str
    ReferenceNumber: str
    Amount: str
    Date: str
    Time: str
    CardNumber: str
    TraceNumber: str
    ApprovalCode: str
    Status: str
    Reason: str