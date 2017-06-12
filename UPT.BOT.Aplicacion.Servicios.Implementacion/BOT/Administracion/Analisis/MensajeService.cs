using System;
using System.Collections.Generic;
using UPT.BOT.Aplicacion.DTOs.BOT;
using UPT.BOT.Aplicacion.Servicios.BOT.Administracion.Analisis;
using UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Shared;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Aplicacion.Servicios.Implementacion.BOT.Administracion.Analisis
{
    public class MensajeService : BaseService, IMensajeService
    {
        private readonly IMensajeRepository repositorioMensaje;

        public MensajeService()
        {
            repositorioMensaje = new MensajeRepository(contexto);
        }

        public IList<GraficoDto> ObtenerNumeroTotalMes()
        {
            DateTime fechaActual = DateTime.Now;
            int mesActual = fechaActual.Month;

            DateTime fechaPrimerMes = fechaActual.AddDays(-fechaActual.Day);

            DateTime fechaFinal = fechaActual;
            DateTime fechaInicio = fechaPrimerMes;

            List<GraficoDto> resumen = new List<GraficoDto>();

            for (int i = 0; i < 6; i++)
            {
                long numeroMensajes = repositorioMensaje.ObtenerNumero(fechaInicio, fechaFinal);
                fechaFinal = fechaInicio;
                fechaInicio = fechaFinal.AddMonths(-1);

                resumen.Add(new GraficoDto
                {
                    Etiqueta = ObtenerNombreMes(fechaFinal.Month),
                    Valor = numeroMensajes
                });
            }
            resumen.Reverse();

            var sdds = ObtenerIntenciones();

            return resumen;
        }

        private string ObtenerNombreMes(int numeroMes)
        {
            switch (numeroMes)
            {
                case 1: return "Enero";
                case 2: return "Febrero";
                case 3: return "Marzo";
                case 4: return "Abril";
                case 5: return "Mayo";
                case 6: return "Junio";
                case 7: return "Julio";
                case 8: return "Agosto";
                case 9: return "Setiembre";
                case 10: return "Octubre";
                case 11: return "Noviembre";
                case 12: return "Diciembre";
                default: return "Mes incorrecto";
            }
        }

        public IList<GraficoDto> ObtenerIntenciones()
        {
            List<GraficoDto> resumen = new List<GraficoDto>();

            string[] intenciones = repositorioMensaje.ObtenerIntenciones();

            foreach (var intencion in intenciones)
            {
                resumen.Add(new GraficoDto
                {
                    Etiqueta = intencion,
                    Valor = repositorioMensaje.ObtenerNumeroIntencion(intencion)
                });
            }

            return resumen;
        }
    }
}
