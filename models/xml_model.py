import xml.etree.ElementTree as ET
from fastapi import Response
import os

XML_PATH = "data/sim_xml.xml"
PAYMENT_PATH = "data/payment_response.xml"

def dict_to_xml_response(root_tag: str, data: dict):
    """Converts a dictionary to an XML Response so the client gets actual XML"""
    root = ET.Element(root_tag)
    for key, value in data.items():
        if isinstance(value, dict):
            child = ET.SubElement(root, key)
            for sub_k, sub_v in value.items():
                ET.SubElement(child, sub_k).text = str(sub_v)
        else:
            ET.SubElement(root, key).text = str(value)
            
    xml_string = ET.tostring(root, encoding='unicode')
    return Response(content=xml_string, media_type="application/xml")


def save_to_xml(data: dict):
    # This APPENDS to the transaction history
    os.makedirs("data", exist_ok=True)
    
    if not os.path.exists(XML_PATH):
        root = ET.Element("Transactions")
        tree = ET.ElementTree(root)
    else:
        tree = ET.parse(XML_PATH)
        root = tree.getroot()

    item = ET.SubElement(root, "item")
    for key, value in data.items():
        if key == "Error" and isinstance(value, dict):
            err = ET.SubElement(item, "Error")
            ET.SubElement(err, "Code").text = str(value.get("Code", ""))
            ET.SubElement(err, "Description").text = str(value.get("Description", ""))
        else:
            ET.SubElement(item, key).text = str(value)

    ET.indent(tree, space="    ")
    tree.write(XML_PATH, encoding="utf-8", xml_declaration=True)


def read_from_xml():
    if not os.path.exists(XML_PATH):
        return Response(content="<Transactions></Transactions>", media_type="application/xml")
    
    tree = ET.parse(XML_PATH)
    root = tree.getroot()
    
    xml_string = ET.tostring(root, encoding='unicode') 
    return Response(content=xml_string, media_type="application/xml")


def save_payment_response_to_xml(response: dict):
    # OVERWRITES the payment response file completely, matching JSON behavior
    os.makedirs("data", exist_ok=True)
    
    root = ET.Element("PaymentResponse")
    
    for key, value in response.items():
        ET.SubElement(root, key).text = str(value)

    tree = ET.ElementTree(root)
    ET.indent(tree, space="    ")
    tree.write(PAYMENT_PATH, encoding="utf-8", xml_declaration=True)