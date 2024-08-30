using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class CustomerRepository
    {
        // Método para obtener todos los registros de la tabla "Customers" de la base de datos
        public List<Customers> ObtenerTodos() {
            using (var conexion= DataBase.GetSqlConnection()) {  // Abre una conexión a la base de datos utilizando el método GetSqlConnection de la clase DataBase
                // Construye una consulta SQL para seleccionar todos los campos de la tabla "Customers"
                String selectFrom = "";
                selectFrom = selectFrom + "SELECT [CustomerID] " + "\n";
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
                selectFrom = selectFrom + "      ,[Address] " + "\n";
                selectFrom = selectFrom + "      ,[City] " + "\n";
                selectFrom = selectFrom + "      ,[Region] " + "\n";
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
                selectFrom = selectFrom + "      ,[Country] " + "\n";
                selectFrom = selectFrom + "      ,[Phone] " + "\n";
                selectFrom = selectFrom + "      ,[Fax] " + "\n";
                selectFrom = selectFrom + "  FROM [dbo].[Customers]";

                // Crea un objeto SqlCommand para ejecutar la consulta SQL en la base de datos
                using (SqlCommand comando = new SqlCommand(selectFrom, conexion)) {
                    SqlDataReader reader = comando.ExecuteReader();  // Ejecuta la consulta y obtiene un SqlDataReader para leer los resultados
                    List<Customers> Customers = new List<Customers>();   // Crea una lista para almacenar los objetos Customers que se obtendrán de la consulta

                    // Lee cada fila del resultado de la consulta
                    while (reader.Read())
                    {
                        // Llama al método LeerDelDataReader para mapear los datos de la fila actual a un objeto Customers
                        var customers = LeerDelDataReader(reader);
                        Customers.Add(customers);  // Agrega el objeto Customers a la lista
                    }
                    return Customers;
                }
            }
           
        }
        public Customers ObtenerPorID(string id) {
            // Abre una conexión a la base de datos utilizando el método GetSqlConnection de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection()) {
                // Construye una consulta SQL para seleccionar los campos de la tabla 
                String selectForID = "";
                selectForID = selectForID + "SELECT [CustomerID] " + "\n";
                selectForID = selectForID + "      ,[CompanyName] " + "\n";
                selectForID = selectForID + "      ,[ContactName] " + "\n";
                selectForID = selectForID + "      ,[ContactTitle] " + "\n";
                selectForID = selectForID + "      ,[Address] " + "\n";
                selectForID = selectForID + "      ,[City] " + "\n";
                selectForID = selectForID + "      ,[Region] " + "\n";
                selectForID = selectForID + "      ,[PostalCode] " + "\n";
                selectForID = selectForID + "      ,[Country] " + "\n";
                selectForID = selectForID + "      ,[Phone] " + "\n";
                selectForID = selectForID + "      ,[Fax] " + "\n";
                selectForID = selectForID + "  FROM [dbo].[Customers] " + "\n";
                selectForID = selectForID + $"  Where CustomerID = @customerId";
                // Crea un objeto SqlCommand para ejecutar la consulta SQL en la base de datos
                using (SqlCommand comando = new SqlCommand(selectForID, conexion))
                {
                    // Agrega un parámetro a la consulta para evitar inyección de SQL
                    comando.Parameters.AddWithValue("customerId", id);

                    // Ejecuta la consulta y obtiene un SqlDataReader para leer los resultados
                    var reader = comando.ExecuteReader();
                    // Inicializa un objeto Customers como null, que se llenará si se encuentra un registro
                    Customers customers = null;

                    // Si se encuentra un registro (reader.Read() retorna true)
                    if (reader.Read()) {

                        customers = LeerDelDataReader(reader);  // Llama al método LeerDelDataReader para mapear los datos de la fila actual a un objeto Customers
                       
                    }
                    return customers;   // Retorna el objeto Customers 
                }

            }
        }
        public Customers LeerDelDataReader( SqlDataReader reader) {
            // Crea un nuevo objeto Customers para almacenar los datos del lector
            Customers customers = new Customers();
            customers.CustomerID = reader["CustomerID"] == DBNull.Value ? " " : (String)reader["CustomerID"]; // Asigna el valor de "CustomerID" del lector al objeto Customers
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"]; // Asigna el valor de "CompanyName" del lector al objeto Customers
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"]; // Asigna el valor de "ContactName" del lector al objeto Customers
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];  // Asigna el valor de "ContactTitle" del lector al objeto Customers
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];  // Asigna el valor de "Address" del lector al objeto Customers
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"];  // Asigna el valor de "City" del lector al objeto Customers
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"]; // Asigna el valor de "Region" del lector al objeto Customers
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];  // Asigna el valor de "PostalCode" del lector al objeto Customers
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];   // Asigna el valor de "Country" del lector al objeto Customers
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];  // Asigna el valor de "Phone" del lector al objeto Customers
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];  // Asigna el valor de "Fax" del lector al objeto Customers
            return customers;  // Devuelve el objeto Customers con todos los datos asignados
        }
        //-------------
        public int InsertarCliente(Customers customer) {
            // Abre una conexión a la base de datos utilizando el método GetSqlConnection de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection()) {
                // Construye una consulta SQL para insertar un nuevo registro en la tabla "Customers"
                String insertInto = "";
                insertInto = insertInto + "INSERT INTO [dbo].[Customers] " + "\n";
                insertInto = insertInto + "           ([CustomerID] " + "\n";
                insertInto = insertInto + "           ,[CompanyName] " + "\n";
                insertInto = insertInto + "           ,[ContactName] " + "\n";
                insertInto = insertInto + "           ,[ContactTitle] " + "\n";
                insertInto = insertInto + "           ,[Address] " + "\n";
                insertInto = insertInto + "           ,[City]) " + "\n";
                insertInto = insertInto + "     VALUES " + "\n";
                insertInto = insertInto + "           (@CustomerID " + "\n";
                insertInto = insertInto + "           ,@CompanyName " + "\n";
                insertInto = insertInto + "           ,@ContactName " + "\n";
                insertInto = insertInto + "           ,@ContactTitle " + "\n";
                insertInto = insertInto + "           ,@Address " + "\n";
                insertInto = insertInto + "           ,@City)";

                // Crea un objeto SqlCommand para ejecutar la consulta SQL en la base de datos
                using (var comando = new SqlCommand( insertInto,conexion )) {
                  int  insertados = parametrosCliente(customer, comando);  // Llama al método `parametrosCliente` para agregar los parámetros de la consulta y ejecutar el comando
                    return insertados;  // Retorna la cantidad de registros insertados
                }

            }
        }
        //-------------
        public int ActualizarCliente(Customers customer) {
            // Abre una conexión a la base de datos utilizando el método GetSqlConnection de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection()) {
                // Construye una consulta SQL para actualizar un registro en la tabla "Customers" basado en el CustomerID
                String ActualizarCustomerPorID = "";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "UPDATE [dbo].[Customers] " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "   SET [CustomerID] = @CustomerID " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[CompanyName] = @CompanyName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactName] = @ContactName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactTitle] = @ContactTitle " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[Address] = @Address " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[City] = @City " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + " WHERE CustomerID= @CustomerID";
                // Crea un objeto SqlCommand para ejecutar la consulta SQL en la base de datos
                using (var comando = new SqlCommand(ActualizarCustomerPorID, conexion)) {

                    int actualizados = parametrosCliente(customer, comando);  // Llama al método `parametrosCliente` para agregar los parámetros de la consulta y ejecutar el comando

                    return actualizados; // Retorna la cantidad de registros actualizados, debería ser 1 si la actualización fue exitosa :)
                }
            } 
        }

        // Añade un parámetro al comando SQL con el valor de todos los campos del objeto Customers
        public int parametrosCliente(Customers customer, SqlCommand comando) {
            comando.Parameters.AddWithValue("CustomerID", customer.CustomerID);
            comando.Parameters.AddWithValue("CompanyName", customer.CompanyName);
            comando.Parameters.AddWithValue("ContactName", customer.ContactName);
            comando.Parameters.AddWithValue("ContactTitle", customer.ContactName);
            comando.Parameters.AddWithValue("Address", customer.Address);
            comando.Parameters.AddWithValue("City", customer.City);
            var insertados = comando.ExecuteNonQuery();
            return insertados;
        }

        public int EliminarCliente(string id) {
            // Abre una conexión a la base de datos utilizando el método GetSqlConnection de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection() ){
                // Construye una consulta SQL para eliminar un registro de la tabla "Customers" basado en el CustomerID
                String EliminarCliente = "";
                EliminarCliente = EliminarCliente + "DELETE FROM [dbo].[Customers] " + "\n";
                EliminarCliente = EliminarCliente + "      WHERE CustomerID = @CustomerID";
                // Crea un objeto SqlCommand para ejecutar la consulta SQL en la base de datos
                using (SqlCommand comando = new SqlCommand(EliminarCliente, conexion)) {
                    comando.Parameters.AddWithValue("@CustomerID", id); // Añade el parámetro CustomerID al comando SQL
                    int elimindos = comando.ExecuteNonQuery();  // Ejecuta el comando SQL y devuelve la cantidad de filas eliminadas
                    return elimindos;
                }
            }
        }
    }
}
