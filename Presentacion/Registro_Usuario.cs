using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace Presentacion
{
    public partial class Registro_Usuario : Form
    {
        public Registro_Usuario()
        {
            InitializeComponent();
        }

        private void btn_Registrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.usuario = txt_Usuario.Text;
            usuario.password = txt_Contraseña.Text;
            usuario.conpassword = txt_Confirmar_Contraseña.Text;
            usuario.nombre = txt_Nombre.Text;
            usuario.apellido = txt_Apellido.Text;
            usuario.Cedula = txt_Cedula.Text;
            try
            {
                Controladores control = new Controladores();
                string respuesta = control.control_Registro(usuario);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario registrado");
                    Login login = new Login();
                    login.Visible = true;
                    this.Visible = false;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }
    }
}
