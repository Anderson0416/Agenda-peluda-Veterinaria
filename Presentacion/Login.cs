using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Iniciar_Click(object sender, EventArgs e)
        {
            Controladores controladores = new Controladores();
            string respuesta = controladores.control_Login(txt_Usuario.Text,txt_Contraseña.Text);
            if (respuesta.Length > 0)
            {
                MessageBox.Show(respuesta);
            }
            else
            {
                Menu_Recepcio menu_Recepcio = new Menu_Recepcio();
                menu_Recepcio.Visible = true;
                this.Visible = false;
            }
        }

        private void btn_Registrar_Click(object sender, EventArgs e)
        {
            Registro_Usuario registro_Usuario = new Registro_Usuario();
            registro_Usuario.Visible = true;
            this.Visible = false; 
        }
    }
}
