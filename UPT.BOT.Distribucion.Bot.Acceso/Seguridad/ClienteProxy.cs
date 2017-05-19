using UPT.BOT.Aplicacion.DTOs.BOT;

namespace UPT.BOT.Distribucion.Bot.Acceso.Seguridad
{
    public class ClienteProxy : BaseProxy
    {
        public ClienteProxy(string rutaApi) : base(rutaApi)
        {

        }

        public bool Guardar(ClienteDto cliente)
        {
            return Ejecutar<bool>("cliente", Metodo.Post, cliente);
        }
    }
}
