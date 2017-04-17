namespace UPT.BOT.Aplicacion.DTOs.Shared
{
    public class RespuestaApi<TDatos>
    {
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public string Traza { get; set; }
        public TDatos Datos { get; set; }

        public RespuestaApi()
        {

        }

        public RespuestaApi(TDatos aoDatos)
        {
            this.Estado = true;
            this.Mensaje = string.Empty;
            this.Traza = string.Empty;
            this.Datos = aoDatos;
        }

        public RespuestaApi(string asMensaje, string asTraza)
        {
            this.Estado = false;
            this.Mensaje = asMensaje;
            this.Traza = asTraza;
            this.Datos = default(TDatos);
        }
    }

}
