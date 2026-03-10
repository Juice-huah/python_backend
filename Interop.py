from fastapi import FastAPI
from routers.Interop_routers import router as sim_routers

app = FastAPI(title="SIMULATION API")

app.include_router(sim_routers)

@app.get("/")
def home():
    return {"message": "Interop API is online"}
