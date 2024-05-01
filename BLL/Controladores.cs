using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BLL
{
    public class Controladores
    {
        Registrar_Datos registro = new Registrar_Datos();
        public string control_Registro (Usuario usuario) 
        {
            
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario.usuario) || string.IsNullOrEmpty(usuario.password) ||
                string.IsNullOrEmpty(usuario.conpassword) || string.IsNullOrEmpty(usuario.nombre))
            {
                respuesta = "DEBE LLENAR TODOS LOS DATOS";
            }
            else
            {
                if (usuario.password == usuario.conpassword)
                {
                    if (registro.existeciaUsuario(usuario.usuario))
                    {
                        respuesta = "EL USUARIO YA EXISTE";
                    }
                    else
                    {
                        usuario.password = generarSHA1(usuario.password);
                        registro.Registrar_datos(usuario);
                    }
                }
                else
                {
                    respuesta = "LAS CONTRASEÑAS NO COINCIDE";
                }
            }
            return respuesta;
        }

        public string control_Login (string usuario , string password)
        {
            Registrar_Datos registro_datos = new Registrar_Datos();
            string respuesta = "";
            Usuario Datousuario = null;

            if(string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                respuesta = "DEBE LLENAR TODOS LOS DATOS";
            }
            else
            {
                Datousuario = registro_datos.ConsultaUsuario(usuario);

                if(Datousuario == null)
                {
                    respuesta = "EL SUARIO NO EXISTE";
                }
                else
                {
                    if(Datousuario.password != generarSHA1(password))
                    {
                        respuesta = "EL USUARIO O LA CONTRASEÑA NO COINCIDEN";
                    }
                }
            }
            return respuesta;
        }
        private string generarSHA1 (string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding ();
            byte[] data = enc.GetBytes (cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider ();

            result = sha.ComputeHash (data);

            StringBuilder sb = new StringBuilder ();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append ('0');
                }
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString ();
        }
    


    }
}
