using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroPedidosSuplidor.Entidades
{
    public class OrdenesDetalle
    {
        [Key]
        public int OrdenId { get; set; }
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public double Costo { get; set; }

        public OrdenesDetalle(int ordenId, int id, int cantidad, double costo)
        {
            OrdenId = ordenId;
            Id = id;
            Cantidad = cantidad;
            Costo = costo;
        }
    }
}
