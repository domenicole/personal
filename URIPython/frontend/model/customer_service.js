// Servicio para comunicarse con el backend
const API_BASE_URL = 'http://localhost:3018/api';

export class CustomerService {
  /**
   * Obtiene todos los clientes
   */
  static async getAllCustomers() {
    try {
      const response = await fetch(`${API_BASE_URL}/customers/`);
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      const data = await response.json();
      return data;
    } catch (error) {
      console.error('Error al obtener clientes:', error);
      throw error;
    }
  }

  /**
   * Obtiene un cliente por ID
   */
  static async getCustomerById(customerId) {
    try {
      const response = await fetch(`${API_BASE_URL}/customers/${customerId}/`);
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      const data = await response.json();
      return data;
    } catch (error) {
      console.error('Error al obtener cliente:', error);
      throw error;
    }
  }

  /**
   * Filtra clientes por tipo
   */
  static async getCustomersByType(customerType) {
    try {
      const response = await fetch(`${API_BASE_URL}/customers/type/${customerType}/`);
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      const data = await response.json();
      return data;
    } catch (error) {
      console.error('Error al filtrar clientes:', error);
      throw error;
    }
  }

  /**
   * Verifica el estado del servidor
   */
  static async healthCheck() {
    try {
      const response = await fetch(`${API_BASE_URL}/health/`);
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      const data = await response.json();
      return data;
    } catch (error) {
      console.error('Error al verificar estado del servidor:', error);
      throw error;
    }
  }
}