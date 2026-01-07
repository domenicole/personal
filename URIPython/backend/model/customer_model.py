from pymongo import MongoClient
from bson import ObjectId
import os
from dotenv import load_dotenv

load_dotenv()

class CustomerModel:
    def __init__(self):
        # Conexión a MongoDB
        db_password = os.getenv('DB_PASSWORD', 'tu_password_aqui')
        connection_string = f"mongodb+srv://oop:{db_password}@cluster0.9knxc.mongodb.net/?appName=Cluster0"
        
        self.client = MongoClient(connection_string)
        self.db = self.client['oop']  # Nombre de la base de datos
        self.collection = self.db['Customers']
    
    def get_all_customers(self):
        """Obtiene todos los clientes de la colección"""
        try:
            customers = list(self.collection.find())
            # Convertir ObjectId a string para JSON serialization
            for customer in customers:
                customer['_id'] = str(customer['_id'])
            return customers
        except Exception as e:
            print(f"Error al obtener clientes: {e}")
            return []
    
    def get_customer_by_id(self, customer_id):
        """Obtiene un cliente por su ID"""
        try:
            customer = self.collection.find_one({"id": customer_id})
            if customer:
                customer['_id'] = str(customer['_id'])
            return customer
        except Exception as e:
            print(f"Error al obtener cliente: {e}")
            return None
    
    def get_customers_by_type(self, customer_type):
        """Filtra clientes por tipo (Normal, Frequent)"""
        try:
            customers = list(self.collection.find({"type": customer_type}))
            for customer in customers:
                customer['_id'] = str(customer['_id'])
            return customers
        except Exception as e:
            print(f"Error al filtrar clientes: {e}")
            return []
    
    def close_connection(self):
        """Cierra la conexión a MongoDB"""
        self.client.close()