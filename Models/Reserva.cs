using System;
using System.Collections.Generic;

namespace RestauranteApp.Models;

public partial class Reserva
{
    public int ReservaId { get; set; }

    public int ClienteId { get; set; }

    public int MesaId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Horario { get; set; }

    public bool? Recurrente { get; set; }

    public string? Estado { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Mesa Mesa { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
