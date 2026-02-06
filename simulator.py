from fastapi import FastAPI
from routers.sim_routers import router as sim_routers

app = FastAPI(title="SIMULATION API")

app.include_router(sim_routers)

@app.get("/")
def home():
    return {"message": "SIM API is online"}
