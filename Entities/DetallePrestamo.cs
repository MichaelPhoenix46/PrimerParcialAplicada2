using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class DetallePrestamo
    {
        [Key]
        public int DetalleId { get; set; }
        public DateTime Fecha { get; set; }
        public int PrestamoId { get; set; }
        public int Cuota { get; set; }
        public int CuentaId { get; set; }
        public decimal InteresMensual { get; set; }
        public decimal CapitalMensual { get; set; }
        public decimal Balance { get; set; }
        [ForeignKey("CuentaId")]
        public virtual Cuenta Cuenta { get; set; }


        public DetallePrestamo()
        {
            DetalleId = 0;
            Fecha = DateTime.Now;
            PrestamoId = 0;
            Cuota = 0;
            CuentaId = 0;
            InteresMensual = 0;
            CapitalMensual = 0;
            Balance = 0;
        }

        public DetallePrestamo(int id, DateTime fecha, int prestamoId, int cuota, int cuentaId, decimal interesMensual, decimal capitalMensual, decimal balance)
        {
            DetalleId = id;
            Fecha = fecha;
            PrestamoId = prestamoId;
            Cuota = cuota;
            CuentaId = cuentaId;
            InteresMensual = interesMensual;
            CapitalMensual = capitalMensual;
            Balance = balance;
        }
    }
}
