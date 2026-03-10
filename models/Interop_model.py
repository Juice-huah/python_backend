from pydantic import BaseModel
from typing import Optional

class ErrorDetails(BaseModel):
    Code: Optional[str] = ""
    Description: Optional[str] = ""

class GenerateQR(BaseModel):
    Amount: str
    CreditMID: str
    MerchantID: str
    TerminalID: str
    MerchantKey: str
    BillNumber: str
    ReferenceNumber: str    

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

class ReceivePaymentApproval(BaseModel):
    MID: str
    BillNumber: str
    ReferenceID: str
    TerminalID: str
    Amount: str
    TxnType: str