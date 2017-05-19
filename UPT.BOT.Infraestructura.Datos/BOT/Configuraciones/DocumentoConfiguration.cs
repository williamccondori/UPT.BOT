using UPT.BOT.Dominio.Entidades.BOT;
using UPT.BOT.Infraestructura.Datos.BOT.Shared;

namespace UPT.BOT.Infraestructura.Datos.BOT.Configuraciones
{
    public class DocumentoConfiguration : BaseConfiguration<DocumentoEntity>
    {
        public DocumentoConfiguration()
        {
            ToTable("BOT_DOCUMENTO");
            HasKey(m => new { m.CodigoDocumento });
            Property(m => m.CodigoDocumento).HasColumnName("COD_DOCUMENTO");
            Property(m => m.CodigoTipoDocumento).HasColumnName("COD_TIPO_DOCUMENTO");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO");
            Property(m => m.DescripcionResena).HasColumnName("DES_RESENA");
            Property(m => m.DescripcionFormato).HasColumnName("DES_FORMATO");
            Property(m => m.DescripcionUrl).HasColumnName("DES_URL");
            Property(m => m.DescripcionContenido).HasColumnName("DES_CONTENIDO");
        }
    }
}
