using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class DonaCobertura
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal PrecioAdicional { get; set; }

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
