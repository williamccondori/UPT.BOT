using System;
using System.Collections.Generic;
using UPT.BOT.Dominio.Entidades.BOT;

namespace UPT.BOT.Dominio.Repositorios.BOT
{
    public interface IMensajeRepository : IBaseInsercionRepository<MensajeEntity>
    {
        IList<MensajeEntity> Obtener(string cliente);
        long ObtenerNumero(string cliente);
        long ObtenerNumero(DateTime fechaInicio, DateTime fechaFinal);
        string[] ObtenerIntenciones();
        long ObtenerNumeroIntencion(string intencion);
    }
}
