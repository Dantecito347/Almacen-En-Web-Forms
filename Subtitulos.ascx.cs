using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial_Nº2___Almacen
{
    public partial class Subtitulos : System.Web.UI.UserControl
    {
        public string Texto
        {
            get { return lblSubtitulo.Text; }
            set { lblSubtitulo.Text = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}