﻿namespace Ywferia.Cloud.AccesoDatos.DAccesoDatosConf
{
    public static class AccesConfig
    {


     
        public static string Esquema_seguridad { get { return "SEGURITY"; } set { Esquema_seguridad = value; } }

        public static string Cadena_Connection { get { return "Data Source=.;Initial Catalog=TSQLDB000001;Persist Security Info=True;User ID=sa;Password=sax;"; } set { Cadena_Connection = value; } }

    }
}
