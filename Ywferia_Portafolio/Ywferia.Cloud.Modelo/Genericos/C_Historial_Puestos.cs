﻿using System;

namespace Ywferia.Cloud.Modelo.Genericos
{
    public class C_Historial_Puestos
    {
        public int Historial_PuestosId { get; set; }
        public string Nombre_HistoriaPuesto { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public DateTime? DateDelete { get; set; }
        public bool ActivoRows { get; set; }
    }
}
