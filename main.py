from fastapi import FastAPI
from routers.pos_router import router as pos_router

app = FastAPI(title="Professional POS System")

# Register your router
app.include_router(pos_router)

@app.get("/")
def home():
    return {"message": "API is online"}