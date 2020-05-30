using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPersonas.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Es obligatorio seleccionar la persona")]
        public int PersonaId { get; set; }
        public string Concepto { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el monto")]
        public float Monto { get; set; }
        public float Balance { get; set; }

        public Prestamos(int prestamoId, DateTime fecha, int personaId, string concepto, float monto, float balance)
        {
            PrestamoId = prestamoId;
            Fecha = fecha;
            PersonaId = personaId;
            Concepto = concepto;
            Monto = monto;
            Balance = balance;
        }

        public Prestamos()
        {
        }
    }
}
