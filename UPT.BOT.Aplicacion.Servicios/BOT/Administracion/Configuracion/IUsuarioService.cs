using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT.Administracion.Configuracion;

namespace UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Configuracion
{
    public interface IUsuarioService
    {
        List<UsuarioConsultaDto> Obtener();
        bool Eliminar(long Id);
        bool Guardar(UsuarioRegistroDto Usuario);
        bool Verificar(string Usuario, string Password);
    }
}
