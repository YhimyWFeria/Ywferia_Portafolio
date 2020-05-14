namespace Ywferia.Cloud.AccesoDatos.DAccesoDatosConf
{
    public static class AccesConfig
    {

        public static string Esquema_seguridad { get { return "SEGURITY"; } set { Esquema_seguridad = value; } }

        //public static string Cadena_Connection { get { return @"Data Source=db.veronica.cloud\CRONOSDB;Initial Catalog=TSQLDB000001;Persist Security Info=True;User ID=ywferia;Password=ywferia.-*123;"; } set { Cadena_Connection = value; } }
        public static string Cadena_Connection { get { return @"Data Source=db.veronica.cloud\CRONOSDB;Initial Catalog=TSQLDB000001; User ID=ywferia; Password=ywferia.-*123;Application Name=Portafolio"; } set { Cadena_Connection = value; } }

    }
}
