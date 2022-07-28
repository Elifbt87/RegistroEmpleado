using System.Data.SqlClient;

namespace RegistroEmpleados.Datos
{
    public class Conexion
    {
        //Declaración e inicialización de variables
        private string cadenaSQL = string.Empty;
        //Constructor de clase
        public Conexion()
        {
            //Instancia a la clase de conexión
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();//Obtener la cadena de conexión del archivo appsetting.json
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;// la cadena de conexión la guardo en la variable cadenaSQL
                                                              
        }
        //Método para devolver la cadena de conexión
        public string obtenerCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
