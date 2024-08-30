using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatosLayer;
using System.Net;
using System.Reflection;


namespace ConexionEjemplo
{
    public partial class Form1 : Form
    {
        CustomerRepository customerRepository = new CustomerRepository(); // Instancia del repositorio de clientes que se utilizará para interactuar con la base de datos

        // Constructor 
        public Form1()
        {
            InitializeComponent();  // Inicializa los componentes del formulario
        }

        private void btnCargar_Click(object sender, EventArgs e) // Evento que se ejecuta cuando se hace clic en el botón "btnCargar"
        {
            var Customers = customerRepository.ObtenerTodos();  // Obtiene todos los clientes desde el repositorio
            dataGrid.DataSource = Customers;  // Asigna la lista de clientes al DataGrid para su visualización
        }

        private void textBox1_TextChanged(object sender, EventArgs e)  // Evento que se ejecuta cuando cambia el texto en el TextBox "textBox1"
        {
           // var filtro = Customers.FindAll( X => X.CompanyName.StartsWith(tbFiltro.Text));
           // dataGrid.DataSource = filtro;
        }

        private void Form1_Load(object sender, EventArgs e) // Evento que se ejecuta cuando el formulario se carga
        { 
            
         /*  DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
          DatosLayer.DataBase.ConnectionTimeout = 30;

          string cadenaConexion = DatosLayer.DataBase.ConnectionString;
            var conxion = DatosLayer.DataBase.GetSqlConnection();
         */
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text); // Llama al método ObtenerPorID del repositorio para obtener un cliente específico basado en el ID ingresado en el TextBox txtBuscar

            // Asigna los valores obtenidos del cliente a los campos de texto del formulario para mostrar los detalles del cliente
            tboxCustomerID.Text = cliente.CustomerID;
            tboxCompanyName.Text = cliente.CompanyName;
            tboxContacName.Text = cliente.ContactName;
            tboxContactTitle.Text= cliente.ContactTitle;
            tboxAddress.Text = cliente.Address;
            tboxCity.Text = cliente.City;


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var resultado = 0;  // Inicializa una variable para almacenar el resultado de la operación de inserción


            var nuevoCliente = ObtenerNuevoCliente();   // Llama al método ObtenerNuevoCliente para crear un nuevo objeto Customers con los datos ingresados en el formulario


            // hayNull= validarCampoNull(nuevoCliente) ? true : false ;

            /*  if (tboxCustomerID.Text != "" || 
                  tboxCompanyName.Text !="" ||
                  tboxContacName.Text != "" ||
                  tboxContacName.Text != "" ||
                  tboxAddress.Text != ""    ||
                  tboxCity.Text != "")
              {
                  resultado = customerRepository.InsertarCliente(nuevoCliente);
                  MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
              }
              else {
                  MessageBox.Show("Debe completar los campos por favor");
              }

              */

            /*
            if (nuevoCliente.CustomerID == "") {
                MessageBox.Show("El Id en el usuario debe de completarse");
               return;    
            }

            if (nuevoCliente.ContactName == "")
            {
                MessageBox.Show("El nombre de usuario debe de completarse");
                return;
            }
            
            if (nuevoCliente.ContactTitle == "")
            {
                MessageBox.Show("El contacto de usuario debe de completarse");
                return;
            }
            if (nuevoCliente.Address == "")
            {
                MessageBox.Show("la direccion de usuario debe de completarse");
                return;
            }
            if (nuevoCliente.City == "")
            {
                MessageBox.Show("La ciudad de usuario debe de completarse");
                return;
            }

            */

            if (validarCampoNull(nuevoCliente) == false)  // Valida que ninguno de los campos del nuevo cliente sea nulo
            {
                // Si la validación es exitosa, llama al método InsertarCliente del repositorio para insertar el nuevo cliente en la base de datos
                resultado = customerRepository.InsertarCliente(nuevoCliente);
                MessageBox.Show("Guardado" + "Filas modificadas = " + resultado); // Muestra un mensaje al usuario indicando que el cliente fue guardado con éxito y muestra el número de filas modificadas
            }
            else {
                MessageBox.Show("Debe completar los campos por favor");  // Si la validación falla, muestra un mensaje de advertencia 
            }
        }
        // si encautnra un null enviara true de lo caontrario false
        public Boolean validarCampoNull(Object objeto) {

            // Recorre todas las propiedades del objeto pasado como parámetro
            foreach (PropertyInfo property in objeto.GetType().GetProperties()) {
                object value = property.GetValue(objeto, null);  // Obtiene el valor de la propiedad actual

                // Verifica si el valor es una cadena vacía
                if ((string)value == "") {
                    return true; // Si encuentra una cadena vacía
                }
            }
            return false;  // Si no encuentra campos vacíos, devuelve false
        }
      
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            // Llama al método ObtenerNuevoCliente para crear un objeto Customers con los datos actualizados del formulario
            var actualizarCliente = ObtenerNuevoCliente();
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente);  // Llama al método ActualizarCliente del repositorio para actualizar el cliente en la base de datos
            MessageBox.Show($"Filas actualizadas = {actualizadas}");  // Muestra un mensaje al usuario indicando cuántas filas fueron actualizadas
        }

        private Customers ObtenerNuevoCliente() {

            
            var nuevoCliente = new Customers   // Crea una nueva instancia de Customers y asigna los valores de los campos del formulario a sus propiedades
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContacName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddress.Text,
                City = tboxCity.Text
            };

            return nuevoCliente; // Devuelve el objeto Customers con los datos ingresados en el formulario
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           int elimindas = customerRepository.EliminarCliente(tboxCustomerID.Text);  // Llama al método EliminarCliente del repositorio para eliminar el cliente con el ID proporcionado en tboxCustomerID
            MessageBox.Show("Filas eliminadas = " + elimindas);  // Muestra un mensaje al usuario indicando cuántas filas fueron eliminadas
        }
    }
}
