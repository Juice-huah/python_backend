from pydantic import BaseModel
from typing import Optional

class ErrorDetails(BaseModel):
    Code: Optional[str] = ""
    Description: Optional[str] = ""

class Callback(BaseModel):
    MerchantID: str
    BillNumber: str
    TerminalID: str
    ReferenceNumber: str
    CreditMID: str
    Amount: str  
    Status: str
    Error: ErrorDetails
    CodeImgUrl: str
    CodeUrl: str

class DataReceived(BaseModel):
    MerchantID: str 
    BillNumber: str
    TerminalID: str
    ReferenceNumber: str
    CreditMID: str
    Amount: str     

class DeclinePatmentDetails(BaseModel):
    Code: str
    Message: str
    Description: str

class DeclinePayment(BaseModel):
    Fault: DeclinePatmentDetails    

class AcceptPayment(BaseModel):
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

