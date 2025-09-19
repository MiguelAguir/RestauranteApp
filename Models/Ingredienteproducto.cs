using System;
using System.Collections.Generic;

namespace RestauranteApp.Models;

public partial class Ingredienteproducto
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public int IngredienteId { get; set; }

    public decimal CantidadReq { get; set; }

    public virtual Ingrediente Ingrediente { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
