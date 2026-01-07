from django.http import JsonResponse
from django.views.decorators.csrf import csrf_exempt
from django.views.decorators.http import require_http_methods
from backend.model.customer_model import CustomerModel

# Instancia del modelo
customer_model = CustomerModel()

@csrf_exempt
@require_http_methods(["GET"])
def get_all_customers(request):
    """Endpoint para obtener todos los clientes"""
    try:
        customers = customer_model.get_all_customers()
        return JsonResponse({
            'success': True,
            'data': customers,
            'count': len(customers)
        }, safe=False)
    except Exception as e:
        return JsonResponse({
            'success': False,
            'error': str(e)
        }, status=500)

@csrf_exempt
@require_http_methods(["GET"])
def get_customer_by_id(request, customer_id):
    """Endpoint para obtener un cliente por ID"""
    try:
        customer = customer_model.get_customer_by_id(int(customer_id))
        if customer:
            return JsonResponse({
                'success': True,
                'data': customer
            })
        else:
            return JsonResponse({
                'success': False,
                'error': 'Cliente no encontrado'
            }, status=404)
    except Exception as e:
        return JsonResponse({
            'success': False,
            'error': str(e)
        }, status=500)

@csrf_exempt
@require_http_methods(["GET"])
def get_customers_by_type(request, customer_type):
    """Endpoint para filtrar clientes por tipo"""
    try:
        customers = customer_model.get_customers_by_type(customer_type)
        return JsonResponse({
            'success': True,
            'data': customers,
            'count': len(customers)
        }, safe=False)
    except Exception as e:
        return JsonResponse({
            'success': False,
            'error': str(e)
        }, status=500)

@csrf_exempt
@require_http_methods(["GET"])
def health_check(request):
    """Endpoint para verificar el estado del servidor"""
    return JsonResponse({
        'status': 'OK',
        'message': 'API funcionando correctamente'
    })