using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Prestamo
    {
        [Key]
        public int PrestamoId { get; set; }
        public int CuentaId { get; set; }
        public int Capital { get; set; }
        public int Meses { get; set; }
        public int InteresAnual { get; set; }
        public decimal Total { get; set; }
        public virtual List<DetallePrestamo> Detalle { get; set; }
        public DateTime Fecha { get; set; }

        public Prestamo()
        {
            Detalle = new List<DetallePrestamo>();
        }

        public void AgregarDetalle(int Id, DateTime Fecha, int PrestamoId, int Cuota, decimal InteresMensual, int CapitalMensual, decimal Balance)
        {
            Detalle.Add(new DetallePrestamo(Id, Fecha, PrestamoId, Cuota, InteresMensual, CapitalMensual, Balance));
        }
    }
}