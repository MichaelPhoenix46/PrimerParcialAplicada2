using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Deposito
    {
        [Key]
        public int DepositoId { get; set; }
        public int CuentaId { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        public Deposito()
        {
            DepositoId = 0;
            CuentaId = 0;
            Concepto = string.Empty;
            Monto = 0;
            Fecha = DateTime.Now;
        }
    }
}