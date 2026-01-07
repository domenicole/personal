from django.contrib import admin
from django.urls import path

# Importar las funciones directamente
from backend.controller.customer_controller import (
    health_check,
    get_all_customers,
    get_customer_by_id,
    get_customers_by_type
)

urlpatterns = [
    path('admin/', admin.site.urls),
    path('api/health/', health_check, name='health_check'),
    path('api/customers/', get_all_customers, name='get_all_customers'),
    path('api/customers/<int:customer_id>/', get_customer_by_id, name='get_customer_by_id'),
    path('api/customers/type/<str:customer_type>/', get_customers_by_type, name='get_customers_by_type'),
]