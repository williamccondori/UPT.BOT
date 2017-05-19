using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Dominio.Entidades.Shared;
using UPT.BOT.Dominio.Repositorios.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Contextos;
using UPT.BOT.Infraestructura.Datos.BOT.Repositorios;
using UPT.BOT.Utilidades.Utilidades.Constantes;

namespace UPT.BOT.Infraestructura.Datos.Pruebas.Repositorios
{
    [TestClass]
    public class PublicacionTest
    {
        IPublicacionRepository goPublicacionRepository;

        public PublicacionTest()
        {
            goPublicacionRepository = new PublicacionRepository(new BotContext());
        }

        [TestMethod]
        public void AgregarPublicacion()
        {
            PublicacionEntity loPublicacion = new PublicacionEntity
            {
                CodigoTipoPublicacion = "N",
                DescripcionResena = "Contenido de la noticia",
                DescripcionImagen = "Imagen.jpg",
                DescripcionResumen = "Resumen",
                DescripcionTitulo = "Este es el titulo",
                DescripcionUrl = "Url",
                EstadoObjeto = EstadoObjeto.Nuevo,
                FechaRegistro = DateTime.Now,
                IndicadorEstado = EstadoEntidad.Activo,
                UsuarioRegistro = "WCONDORI"
            };

            goPublicacionRepository.Crear(loPublicacion);

            Assert.IsNotNull(loPublicacion);
        }

        [TestMethod]
        public void ConsultarPublicacion()
        {
            List<PublicacionEntity> listaPublicacion = goPublicacionRepository.Leer().ToList();

            Assert.IsNotNull(listaPublicacion);
        }
    }
}
