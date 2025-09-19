using System;
using System.Collections.Generic;

namespace RestauranteApp.Models;

public partial class Pedido
{
    public int PedidoId { get; set; }

    public int? MesaId { get; set; }

    public int? ReservaId { get; set; }

    public int ClienteId { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Estado { get; set; }

    public decimal? Total { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Factura? Factura { get; set; }

    public virtual ICollection<Itempedido> Itempedidos { get; set; } = new List<Itempedido>();

    public virtual Mesa? Mesa { get; set; }

    public virtual Reserva? Reserva { get; set; }
}
