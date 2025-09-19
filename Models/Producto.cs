using System;
using System.Collections.Generic;

namespace RestauranteApp.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Ingredienteproducto> Ingredienteproductos { get; set; } = new List<Ingredienteproducto>();

    public virtual ICollection<Itempedido> Itempedidos { get; set; } = new List<Itempedido>();
}
