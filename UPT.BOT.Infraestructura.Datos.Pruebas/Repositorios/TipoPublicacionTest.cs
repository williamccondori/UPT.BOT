using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;

namespace UPT.BOT.Infraestructura.Datos.Pruebas.Repositorios
{
    [TestClass]
    public class TipoPublicacionTest
    {
        ITipoPublicacionRepository goTipoPublicacionRepository;

        public TipoPublicacionTest()
        {
            goTipoPublicacionRepository = new TipoPublicacionRepository(new BotContext());
        }

        [TestMethod]
        public void AgregarTipoPublicacion()
        {
            TipoPublicacionEntity loPublicacion = new TipoPublicacionEntity
            {
                CodigoTipoPublicacion = 1,
                DescripcionTipoPublicacion = "NOTICIA",
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                UsuarioRegistro = "WCONDORI"
            };

            goTipoPublicacionRepository.Agregar(loPublicacion);

            Assert.IsNotNull(loPublicacion);
        }

        [TestMethod]
        public void ConsultarTipoPublicacion()
        {
            List<TipoPublicacionEntity> listaTipoPublicacion = goTipoPublicacionRepository.Consultar().ToList();

            Assert.IsNotNull(listaTipoPublicacion);
        }
    }
}
