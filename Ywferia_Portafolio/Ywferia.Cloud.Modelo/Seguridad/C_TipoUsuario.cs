﻿
using System;

namespace Ywferia.Cloud.Modelo.Seguridad
{
    public class C_TipoUsuario
    {
        public C_TipoUsuario()
        {

        }
        public int Seg_TipoUsuarioId { get; set; }
        public string Tip_NombreTipo { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public DateTime? DateDelete { get; set; }
        public bool ActivoRows { get; set; }
    }
}
