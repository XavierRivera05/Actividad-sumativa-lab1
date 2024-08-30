using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // La clase Customers representa un cliente en la base de datos
    public class Customers
    {
      
        public string CustomerID { get; set; }   // Propiedad que almacena el ID único del cliente
        
        public string CompanyName { get; set; } // Propiedad que almacena el nombre de la empresa del cliente
        
        public string ContactName { get; set; } // Propiedad que almacena el nombre del contacto principal del cliente
        
        public string ContactTitle { get; set; } // Propiedad que almacena el título del contacto principal del cliente

        
        public string Address { get; set; } // Propiedad que almacena la dirección del cliente

        
        public string City { get; set; } // Propiedad que almacena la ciudad donde se encuentra el cliente

        public string Region { get; set; } // Propiedad que almacena la región o estado donde se encuentra el cliente

        public string PostalCode { get; set; }  // Propiedad que almacena el código postal del cliente

        public string Country { get; set; }  // Propiedad que almacena el país donde se encuentra el cliente

        public string Phone { get; set; }  // Propiedad que almacena el número de teléfono del cliente

        public string Fax { get; set; }  // Propiedad que almacena el número de fax del cliente
    }
}
