using System.Data.SqlClient;
using RegistroEmpleados.Models;
using System.Data;
namespace RegistroEmpleados.Datos
{
    public class ContactoDatos
    {
        //Método para obtener la lista de empleados registrados
        public List<ContactoModel> Listar()
        {
            var lista = new List<ContactoModel>();// Crear una lista de los empleados

            var cxn = new Conexion();//Instancia de clase Conexion para obtener la cadena de conexión

            using (var conexion = new SqlConnection(cxn.obtenerCadenaSQL()))//Establecer la cadena de conexión 
            {
                conexion.Open();//Abrimos laconexión
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);//Ejecutar el procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                using (var leer = cmd.ExecuteReader())//Leer los datos del procedimiento
                {
                    while (leer.Read())
                    {
                        lista.Add(new ContactoModel()//Leemos cada registro y crea cada elemento en la lista
                        {
                            ID = Convert.ToInt32(leer["ID"]),
                            Nombre = leer["Nombre"].ToString(),
                            PrimerApellido = leer["PrimerApellido"].ToString(),
                            SegundoApellido = leer["SegundoApellido"].ToString(),
                            Edad = Convert.ToInt32(leer["Edad"]),
                            FechaNacimiento = Convert.ToDateTime(leer["FechaNacimiento"]),
                            Genero = leer["Genero"].ToString(),
                            Telefono = leer["Telefono"].ToString(),
                            Direccion = leer["Direccion"].ToString(),
                            CorreoElectronico = leer["CorreoElectronico"].ToString(),
                            FechaIngreso = Convert.ToDateTime(leer["FechaIngreso"]),
                            Departamento = leer["Departamento"].ToString()
                        });

                    }
                }

            }
            return lista;
        }
        //Método para obtener un contacto en especifico
        public ContactoModel Obtener(int ID)
        {
            var empleado = new ContactoModel();// Crear una lista de los empleados

            var cxn = new Conexion();//Instancia de clase Conexion para obtener la cadena de conexión

            using (var conexion = new SqlConnection(cxn.obtenerCadenaSQL()))//Establecer la cadena de conexión 
            {
                conexion.Open();//Abrimos laconexión
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);//Ejecutar el procedimiento almacenado
                cmd.Parameters.AddWithValue("ID", ID);//Enviamos un parametro
                cmd.CommandType = CommandType.StoredProcedure;

                using (var leer = cmd.ExecuteReader())//Obtiene los datos del procedimiento
                {
                    while (leer.Read())
                    {
                        empleado.ID = Convert.ToInt32(leer["ID"]);
                        empleado.Nombre = leer["Nombre"].ToString();
                        empleado.PrimerApellido = leer["PrimerApellido"].ToString();
                        empleado.PrimerApellido = leer["PrimerApellido"].ToString();
                        empleado.PrimerApellido = leer["PrimerApellido"].ToString();
                        empleado.SegundoApellido = leer["SegundoApellido"].ToString();
                        empleado.Edad = Convert.ToInt32(leer["Edad"]);
                        empleado.FechaNacimiento = Convert.ToDateTime(leer["FechaNacimiento"]);
                        empleado.Genero = leer["Genero"].ToString();
                        empleado.Telefono = leer["Telefono"].ToString();
                        empleado.Direccion = leer["Direccion"].ToString();
                        empleado.CorreoElectronico = leer["CorreoElectronico"].ToString();
                        empleado.FechaIngreso = Convert.ToDateTime(leer["FechaIngreso"]);
                        empleado.Departamento = leer["Departamento"].ToString();
                    }
                }
            }
            return empleado;
        }
        //Método para guardar un empleado
        public bool Guardar(ContactoModel gEmpleado)
        {
            bool respuesta;

            try
            {
                var cxn = new Conexion();//Instancia de clase Conexion para obtener la cadena de conexión

                using (var conexion = new SqlConnection(cxn.obtenerCadenaSQL()))//Establecer la cadena de conexión 
                {
                    conexion.Open();//Abrimos laconexión
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);//Ejecutar el procedimiento almacenado
                    cmd.Parameters.AddWithValue("Nombre", gEmpleado.Nombre);//Enviamos un parametro
                    cmd.Parameters.AddWithValue("PrimerApellido", gEmpleado.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", gEmpleado.SegundoApellido);
                    cmd.Parameters.AddWithValue("Edad", gEmpleado.Edad);
                    cmd.Parameters.AddWithValue("FechaNacimiento", gEmpleado.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Genero", gEmpleado.Genero);
                    cmd.Parameters.AddWithValue("Telefono", gEmpleado.Telefono);
                    cmd.Parameters.AddWithValue("Direccion", gEmpleado.Direccion);
                    cmd.Parameters.AddWithValue("CorreoElectronico", gEmpleado.CorreoElectronico);
                    cmd.Parameters.AddWithValue("FechaIngreso", gEmpleado.FechaIngreso);
                    cmd.Parameters.AddWithValue("Departamento", gEmpleado.Departamento);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
        //Método para actualizar un empleado
        public bool Editar(ContactoModel edEmpleado)
        {
            bool respuesta;
            try
            {
                var cxn = new Conexion();//Instancia de clase Conexion para obtener la cadena de conexión

                using (var conexion = new SqlConnection(cxn.obtenerCadenaSQL()))//Establecer la cadena de conexión 
                {
                    conexion.Open();//Abrimos laconexión
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);//Ejecutar el procedimiento almacenado
                    cmd.Parameters.AddWithValue("ID", edEmpleado.ID);//Enviamos un parametro
                    cmd.Parameters.AddWithValue("Nombre", edEmpleado.Nombre);
                    cmd.Parameters.AddWithValue("PrimerApellido", edEmpleado.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", edEmpleado.SegundoApellido);
                    cmd.Parameters.AddWithValue("Edad", edEmpleado.Edad);
                    cmd.Parameters.AddWithValue("FechaNacimiento", edEmpleado.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Genero", edEmpleado.Genero);
                    cmd.Parameters.AddWithValue("Telefono", edEmpleado.Telefono);
                    cmd.Parameters.AddWithValue("Direccion", edEmpleado.Direccion);
                    cmd.Parameters.AddWithValue("CorreoElectronico", edEmpleado.CorreoElectronico);
                    cmd.Parameters.AddWithValue("FechaIngreso", edEmpleado.FechaIngreso);
                    cmd.Parameters.AddWithValue("Departamento", edEmpleado.Departamento);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
        //Método para eliminar un empleado
        public bool Eliminar(int ID)
        {
            bool respuesta;
            try
            {
                var cxn = new Conexion();//Instancia de clase Conexion para obtener la cadena de conexión

                using (var conexion = new SqlConnection(cxn.obtenerCadenaSQL()))//Establecer la cadena de conexión 
                {
                    conexion.Open();//Abrimos laconexión
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);//Ejecutar el procedimiento almacenado
                    cmd.Parameters.AddWithValue("ID", ID);//Enviamos un parametro
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
