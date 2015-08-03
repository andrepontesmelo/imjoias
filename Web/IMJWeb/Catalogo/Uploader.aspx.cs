using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMJWeb.DAO.EF;
using System.IO;
using IMJWeb.Servico.Catalogo;
using IMJWeb.Dominio.Util;

namespace IMJWeb.Catalogo
{
    public partial class Uploader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AoClicar(object sender, EventArgs e)
        {
           System.Drawing.Image imagem = System.Drawing.Image.FromStream(Fileupload1.FileContent);

           Mercadorias mercadorias = InjecaoDependencia.Resolver<Mercadorias>();

           mercadorias.CadastrarFoto(IDMercadoria.Text, imagem);
        }
    }
}