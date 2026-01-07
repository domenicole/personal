import React, { useState, useEffect } from 'react';
import { CustomerService } from '../model/customer_service.js';

export default function CustomerTable() {
  const [customers, setCustomers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [filter, setFilter] = useState('all');
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    loadCustomers();
  }, []);

  const loadCustomers = async () => {
    try {
      setLoading(true);
      setError(null);
      const response = await CustomerService.getAllCustomers();
      if (response.success) {
        setCustomers(response.data);
      } else {
        setError('Error al cargar los datos');
      }
    } catch (err) {
      setError('No se pudo conectar con el servidor. Asegúrate de que el backend esté ejecutándose en el puerto 8000.');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  const handleFilterChange = async (type) => {
    setFilter(type);
    if (type === 'all') {
      loadCustomers();
    } else {
      try {
        setLoading(true);
        const response = await CustomerService.getCustomersByType(type);
        if (response.success) {
          setCustomers(response.data);
        }
      } catch (err) {
        setError('Error al filtrar clientes');
      } finally {
        setLoading(false);
      }
    }
  };

  const filteredCustomers = customers.filter(customer => {
    if (!searchTerm) return true;
    const term = searchTerm.toLowerCase();
    return (
      customer.fullName?.toLowerCase().includes(term) ||
      customer.email?.toLowerCase().includes(term) ||
      customer.type?.toLowerCase().includes(term)
    );
  });

  if (loading) {
    return (
      <div style={styles.container}>
        <div style={styles.loading}>
          <div style={styles.spinner}></div>
          <p>Cargando clientes...</p>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div style={styles.container}>
        <div style={styles.error}>
          <h3>⚠️ Error</h3>
          <p>{error}</p>
          <button style={styles.retryButton} onClick={loadCustomers}>
            Reintentar
          </button>
        </div>
      </div>
    );
  }

  return (
    <div style={styles.container}>
      <div style={styles.header}>
        <h1 style={styles.title}>👥 Gestión de Clientes</h1>
        <p style={styles.subtitle}>Total de clientes: {filteredCustomers.length}</p>
      </div>

      <div style={styles.controls}>
        <div style={styles.searchContainer}>
          <input
            type="text"
            placeholder="🔍 Buscar por nombre, email o tipo..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            style={styles.searchInput}
          />
        </div>

        <div style={styles.filterContainer}>
          <button
            style={{...styles.filterButton, ...(filter === 'all' ? styles.activeFilter : {})}}
            onClick={() => handleFilterChange('all')}
          >
            Todos
          </button>
          <button
            style={{...styles.filterButton, ...(filter === 'Normal' ? styles.activeFilter : {})}}
            onClick={() => handleFilterChange('Normal')}
          >
            Normal
          </button>
          <button
            style={{...styles.filterButton, ...(filter === 'Frequent' ? styles.activeFilter : {})}}
            onClick={() => handleFilterChange('Frequent')}
          >
            Frecuente
          </button>
        </div>
      </div>

      <div style={styles.tableContainer}>
        <table style={styles.table}>
          <thead>
            <tr style={styles.tableHeader}>
              <th style={styles.th}>ID</th>
              <th style={styles.th}>Nombre Completo</th>
              <th style={styles.th}>Email</th>
              <th style={styles.th}>Tipo</th>
              <th style={styles.th}>Descuento (%)</th>
              <th style={styles.th}>Total Ventas ($)</th>
            </tr>
          </thead>
          <tbody>
            {filteredCustomers.length === 0 ? (
              <tr>
                <td colSpan="6" style={styles.noData}>
                  No se encontraron clientes
                </td>
              </tr>
            ) : (
              filteredCustomers.map((customer) => (
                <tr key={customer._id} style={styles.tableRow}>
                  <td style={styles.td}>{customer.id}</td>
                  <td style={styles.td}>{customer.fullName}</td>
                  <td style={styles.td}>{customer.email}</td>
                  <td style={styles.td}>
                    <span style={{
                      ...styles.badge,
                      ...(customer.type === 'Frequent' ? styles.badgeFrequent : styles.badgeNormal)
                    }}>
                      {customer.type}
                    </span>
                  </td>
                  <td style={styles.td}>{customer.discount}%</td>
                  <td style={styles.td}>${customer.totalSale}</td>
                </tr>
              ))
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}

const styles = {
  container: {
    maxWidth: '1400px',
    margin: '0 auto',
    padding: '20px',
    fontFamily: 'Arial, sans-serif',
    backgroundColor: '#f5f7fa',
    minHeight: '100vh',
  },
  header: {
    textAlign: 'center',
    marginBottom: '30px',
    padding: '20px',
    backgroundColor: 'white',
    borderRadius: '10px',
    boxShadow: '0 2px 8px rgba(0,0,0,0.1)',
  },
  title: {
    color: '#2c3e50',
    fontSize: '32px',
    marginBottom: '10px',
  },
  subtitle: {
    color: '#7f8c8d',
    fontSize: '16px',
  },
  controls: {
    marginBottom: '20px',
    display: 'flex',
    gap: '20px',
    flexWrap: 'wrap',
  },
  searchContainer: {
    flex: '1',
    minWidth: '250px',
  },
  searchInput: {
    width: '100%',
    padding: '12px 15px',
    fontSize: '14px',
    border: '2px solid #e1e8ed',
    borderRadius: '8px',
    outline: 'none',
    transition: 'border-color 0.3s',
  },
  filterContainer: {
    display: 'flex',
    gap: '10px',
  },
  filterButton: {
    padding: '12px 24px',
    fontSize: '14px',
    border: '2px solid #e1e8ed',
    borderRadius: '8px',
    backgroundColor: 'white',
    cursor: 'pointer',
    transition: 'all 0.3s',
    fontWeight: '500',
  },
  activeFilter: {
    backgroundColor: '#3498db',
    color: 'white',
    borderColor: '#3498db',
  },
  tableContainer: {
    backgroundColor: 'white',
    borderRadius: '10px',
    boxShadow: '0 2px 8px rgba(0,0,0,0.1)',
    overflow: 'hidden',
  },
  table: {
    width: '100%',
    borderCollapse: 'collapse',
  },
  tableHeader: {
    backgroundColor: '#34495e',
    color: 'white',
  },
  th: {
    padding: '15px',
    textAlign: 'left',
    fontWeight: '600',
    fontSize: '14px',
    textTransform: 'uppercase',
    letterSpacing: '0.5px',
  },
  tableRow: {
    borderBottom: '1px solid #e1e8ed',
    transition: 'background-color 0.2s',
    cursor: 'pointer',
  },
  td: {
    padding: '15px',
    fontSize: '14px',
    color: '#2c3e50',
  },
  badge: {
    padding: '5px 12px',
    borderRadius: '20px',
    fontSize: '12px',
    fontWeight: '600',
    display: 'inline-block',
  },
  badgeNormal: {
    backgroundColor: '#e8f5e9',
    color: '#2e7d32',
  },
  badgeFrequent: {
    backgroundColor: '#fff3e0',
    color: '#e65100',
  },
  loading: {
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    justifyContent: 'center',
    minHeight: '400px',
    color: '#7f8c8d',
  },
  spinner: {
    width: '50px',
    height: '50px',
    border: '5px solid #e1e8ed',
    borderTop: '5px solid #3498db',
    borderRadius: '50%',
    animation: 'spin 1s linear infinite',
  },
  error: {
    backgroundColor: '#fff',
    padding: '40px',
    borderRadius: '10px',
    textAlign: 'center',
    boxShadow: '0 2px 8px rgba(0,0,0,0.1)',
    color: '#e74c3c',
  },
  retryButton: {
    marginTop: '20px',
    padding: '12px 24px',
    backgroundColor: '#3498db',
    color: 'white',
    border: 'none',
    borderRadius: '8px',
    cursor: 'pointer',
    fontSize: '14px',
    fontWeight: '600',
  },
  noData: {
    padding: '40px',
    textAlign: 'center',
    color: '#7f8c8d',
    fontSize: '16px',
  },
};

// Agregar animación del spinner
const styleSheet = document.createElement('style');
styleSheet.textContent = `
  @keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
  }
  
  table tbody tr:hover {
    background-color: #f8f9fa;
  }
  
  input:focus {
    border-color: #3498db !important;
  }
  
  button:hover:not(:disabled) {
    transform: translateY(-2px);
    box-shadow: 0 4px 12px rgba(0,0,0,0.15);
  }
`;
document.head.appendChild(styleSheet);