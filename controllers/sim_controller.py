from fastapi import HTTPException, status
import json
import os

SIM_FILE = "data/sim_data.json"
RESPONSE_FILE = "data/response.json"

def get_callbacks():
    """Helper to load the current stored data."""
    if not os.path.exists(SIM_FILE):
        return []
    with open(SIM_FILE, "r") as file:
        try:
            return json.load(file)
        except json.JSONDecodeError:
            return []

def save_data_received(data):
    # 1. Load the existing list of data from sim_data.json
    all_records = get_callbacks()
    
    # 2. Convert the user's input (Pydantic model) into a standard Dictionary
    new_entry = data.model_dump()
    
    # 3. Load the data from response.json
    if os.path.exists(RESPONSE_FILE):
        with open(RESPONSE_FILE, "r") as f:
            response_list = json.load(f)
            # Since response.json is a list (based on your file content), 
            # we take the first item to merge.
            if isinstance(response_list, list) and len(response_list) > 0:
                extra_data = response_list[0]
                
                # 4. MERGE: Add the fields from response.json into our new_entry
                # This adds "Status", "Error", "CodeImgUrl", etc.
                new_entry.update(extra_data)

    # 5. Append the combined data to our main list and save
    all_records.append(new_entry)
    with open(SIM_FILE, "w") as file:
        json.dump(all_records, file, indent=4)
        
    return new_entry