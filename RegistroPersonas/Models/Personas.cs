using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace RegistroPersonas.Models
{
    public class Personas
    {
        [Key]
        public int PersonasId { get; set; }
        [Required(ErrorMessage ="Es obligatorio introducir el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el telefono")]
        [Phone(ErrorMessage ="Formato invalido")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la cedula")]
        [StringLength(13,ErrorMessage ="No se permiten mas de 13 caracteres")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la direccion")]
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public float Balance { get; set; }
        public Personas(int personasId, string nombre, string telefono, string cedula, string direccion, DateTime fechaNacimiento, float balance)
        {
            PersonasId = personasId;
            Nombre = nombre;
            Telefono = telefono;
            Cedula = cedula;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
            Balance = balance;
        }
        public Personas()
        {
        }
    }
}
