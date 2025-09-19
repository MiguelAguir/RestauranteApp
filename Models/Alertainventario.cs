using System;
using System.Collections.Generic;

namespace RestauranteApp.Models;

public partial class Alertainventario
{
    public string Nombre { get; set; } = null!;

    public decimal StockActual { get; set; }

    public decimal UmbralMinimo { get; set; }
}
