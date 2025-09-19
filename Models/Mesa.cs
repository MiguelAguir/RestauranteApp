using System;
using System.Collections.Generic;

namespace RestauranteApp.Models;

public partial class Mesa
{
    public int MesaId { get; set; }

    public int Numero { get; set; }

    public int Capacidad { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
