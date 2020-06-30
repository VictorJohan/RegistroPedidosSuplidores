using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroPedidosSuplidor.Entidades
{
    public class Suplidores
    {
        [Key]
        public int SuplidoreId { get; set; }
        public string Nombres { get; set; }
    }
}
