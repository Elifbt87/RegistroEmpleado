using System.ComponentModel.DataAnnotations;
namespace RegistroEmpleados.Models
{
    public class ContactoModel
    {
        //Declaración e inicialización de variables
        public int ID { get; set; }
        [Required(ErrorMessage ="Ingrese un Nombre por favor")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el Primer Apellido por favor")]
        public string? PrimerApellido { get; set; }
        [Required(ErrorMessage = "Ingrese el Segundo Apellido por favor")]
        public string? SegundoApellido { get; set; }
        [Required(ErrorMessage = "Ingrese la Edad por favor")]
        public int? Edad { get; set; }
        [Required(ErrorMessage = "Ingrese la Fecha de Nacimiento favor")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Ingrese un Genero por favor")]
        public string? Genero { get; set; }
        [Required(ErrorMessage = "Ingrese un Telefóno por favor")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "Ingrese una Dirección por favor")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "Ingrese un Correo Electríco por favor")]
        public string? CorreoElectronico { get; set; }
        [Required(ErrorMessage = "Ingrese una Fecha de Ingreso por favor")]
        public DateTime FechaIngreso { get; set; }
        [Required(ErrorMessage = "Ingrese un Departamento por favor")]
        public string? Departamento { get; set; }
    }
}
