using System;
using System.Collections.Generic;

namespace RestauranteApp.Models;

public partial class Factura
{
    public int FacturaId { get; set; }

    public int PedidoId { get; set; }

    public decimal Total { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Estado { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;
}
