using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class DonaTopping
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal PrecioAdicional { get; set; }

    public virtual ICollection<Transaccione> Transaccions { get; set; } = new List<Transaccione>();
}
