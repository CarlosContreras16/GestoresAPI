using System;
using System.Collections.Generic;

namespace GestoresAPI.Models;

public partial class GestoresBd
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Lanzamiento { get; set; }

    public string Desarrollador { get; set; } = null!;
}
