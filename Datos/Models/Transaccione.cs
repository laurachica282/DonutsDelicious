using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Transaccione
{
    public int Id { get; set; }

    public int? TipoDonaId { get; set; }

    public int? TamanoId { get; set; }

    public int? RellenoId { get; set; }

    public int? CoberturaId { get; set; }

    public decimal Total { get; set; }

    public decimal DineroIngresado { get; set; }

    public decimal Cambio { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual DonaCobertura? Cobertura { get; set; }

    public virtual DonaRelleno? Relleno { get; set; }

    public virtual DonaTamaño? Tamano { get; set; }

    public virtual DonaTipo? TipoDona { get; set; }

    public virtual ICollection<DonaTopping> Toppings { get; set; } = new List<DonaTopping>();
}
