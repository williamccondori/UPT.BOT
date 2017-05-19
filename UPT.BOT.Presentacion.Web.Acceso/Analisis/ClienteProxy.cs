namespace UPT.BOT.Presentacion.Web.Acceso.Analisis
{
    public class ClienteProxy : BaseProxy
    {
        public ClienteProxy(string asRuta, string asVersion, string asServicio)
            : base(asRuta, asVersion, asServicio)
        {

        }

        /**

        public RespuestaDto<List<ClienteDto>> Obtener()
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("canal", "facebook");

            return agenteApi.Ejecutar<List<ClienteDto>>("cliente", RestSharp.Method.GET, null, null, parametros);
        }


        public RespuestaDto<List<ClienteMensajeDto>> ObtenerMensajeXCanal()
        {
            return agenteApi.Ejecutar<List<ClienteMensajeDto>>(string.Format("cliente/mensaje/canal/{0}", "facebook"), RestSharp.Method.GET, null, null, null);
        }

    **/
    }
}
