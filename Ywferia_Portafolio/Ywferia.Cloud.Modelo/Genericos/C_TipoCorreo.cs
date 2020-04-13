﻿using System;

namespace Ywferia.Cloud.Modelo.Genericos
{
    public class C_TipoCorreo
    {
        public int TipoCorreoId { get; set; }
        public string NombreTipo { get; set; }
        public DateTime? DateInsert { get; set; } 
        public DateTime? DateUpdate { get; set; } 
        public DateTime? DateDelete { get; set; }
        public bool ActivoRows { get; set; }
    }
}
