using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace UPT.BOT.Distribucion.Bot.Acceso.Publicacion
{
    [XmlRoot("rss")]
    public class Rss
    {
        [XmlAttribute]
        public string version = "2.0";
        public Channel channel = new Channel();
    }

    [XmlRoot("channel")]
    public class Channel
    {
        public string title;
        public string link;
        public string description;

        [XmlElement]
        public List<object> item = new List<object>();
    }

    public class Elemento
    {
        public string Titulo { get; set; }
        public string Enlace { get; set; }
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Imagen { get; set; }
    }

    public class RssProxy
    {
        private readonly string ruta;

        public RssProxy(string ruta)
        {
            this.ruta = ruta;
        }

        public List<Elemento> Obtener()
        {
            try
            {
                Rss respuesta = new Rss();

                XmlSerializer ser = new XmlSerializer(typeof(Rss));

                using (XmlTextReader reader = new XmlTextReader(ruta))
                    respuesta = ser.Deserialize(reader) as Rss;

                List<Elemento> listaElemento = new List<Elemento>();

                foreach (XmlNode[] propiedades in respuesta.channel.item)
                {
                    string id = propiedades[4].InnerText;
                    string descripcion = propiedades[1].InnerText;
                    string enlace = propiedades[3].InnerText;
                    string titulo = propiedades[0].InnerText;
                    string fechastring = propiedades[2].InnerText;
                    DateTime fecha = DateTime.Parse(fechastring);
                    var imagenes = propiedades[6].Attributes;
                    string imagen = imagenes.Count > 0 ? imagenes[0].InnerText : string.Empty;

                    listaElemento.Add(new Elemento
                    {
                        Id = id,
                        Descripcion = descripcion,
                        Enlace = enlace,
                        Fecha = fecha,
                        Imagen = imagen,
                        Titulo = titulo
                    });
                }

                return listaElemento.Take(5).OrderByDescending(p => p.Fecha).ToList();
            }
            catch (Exception)
            {
                return default(List<Elemento>);
            }
        }
    }
}
