using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    public class DataBase
    {
        //Esta es una propiedad que obtiene la cadena de conexión a la base de datos
        public static string ConnectionString {
            get
            {
                // Se obtiene la cadena de conexión desde el archivo de configuración
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;
                // Se crea un objeto "SqlConnectionStringBuilder" para poder manipular 
                // la cadena de conexión de una manera más controlada
                SqlConnectionStringBuilder conexionBuilder = 
                    new SqlConnectionStringBuilder(CadenaConexion);
                // Si ApplicationName tiene un valor, se asigna a la propiedad 
              
                conexionBuilder.ApplicationName = 
                    ApplicationName ?? conexionBuilder.ApplicationName;
                // Si ConnectionTimeout es mayor que 0, se asigna ese valor; 
                
                conexionBuilder.ConnectTimeout = ( ConnectionTimeout > 0 ) 
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;
                // Se devuelve la cadena de conexión como una cadena de texto
                return conexionBuilder.ToString();
            }


        }
        // propiedad estática para obtener el tiempo de espera de la conexión
        public static int ConnectionTimeout { get; set; }
        // propiedad estática para obtener el nombre de la aplicación
        public static string ApplicationName { get; set; }
        // método estático que retorna una nueva conexión SQL ya "abrida" broma, abierta
        public static SqlConnection GetSqlConnection()
        {
            // Se crea una nueva conexión SQL utilizando la cadena de conexión generada
            SqlConnection conexion = new SqlConnection(ConnectionString);
            // Se abre la conexión antes de devolverla
            conexion.Open();
            // Se retorna el objeto SqlConnection ya abierto
            return conexion;
            
        } 
    }
}
