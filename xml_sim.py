import uvicorn
from fastapi import FastAPI
from routers.xml_router import router as xml_router

app = FastAPI()
app.include_router(xml_router, prefix="/xml")

if __name__ == "__main__":
    uvicorn.run("xml_sim:app", host="127.0.0.1", port=8000, reload=True)