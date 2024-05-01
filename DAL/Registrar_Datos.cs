using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Registrar_Datos
    {
        Conexion conexion = new Conexion();
        public int Registrar_datos(Usuario usuario)
        {
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "INSERT INTO usuarios (Usuarios, Password, Nombre, id_tipo, Cedula, Apellido)" +
                         "VALUES (@Usuarios, @Password, @Nombre, @id_tipo, @Cedula, @Apellido)";
            MySqlCommand comando = new MySqlCommand(sql, conectar); ;
            comando.Parameters.AddWithValue("@Usuarios", usuario.usuario);
            comando.Parameters.AddWithValue("@Password", usuario.password);
            comando.Parameters.AddWithValue("@Nombre", usuario.nombre);
            comando.Parameters.AddWithValue("@id_tipo", 1);
            comando.Parameters.AddWithValue("@Cedula", usuario.Cedula);
            comando.Parameters.AddWithValue("@Apellido", usuario.apellido);

            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }

        public bool existeciaUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "SELECT ID FROM usuarios where usuarios like @usuarios";

            MySqlCommand comando = new MySqlCommand(sql, conectar); ;
            comando.Parameters.AddWithValue("@Usuarios", usuario);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Usuario ConsultaUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conectar = conexion.crearConexion();
            conectar.Open();

            string sql = "SELECT ID, Password, Nombre, id_tipo FROM usuarios where usuarios like @usuarios";

            MySqlCommand comando = new MySqlCommand(sql, conectar); ;
            comando.Parameters.AddWithValue("@Usuarios", usuario);
            reader = comando.ExecuteReader();

            Usuario usuarios = null;
            while (reader.Read())
            {
                usuarios = new Usuario();
                usuarios.id = int.Parse(reader["id"].ToString());
                usuarios.password = reader["Password"].ToString();
                usuarios.nombre = reader["Nombre"].ToString();
                usuarios.id_tipo = int.Parse(reader["id_tipo"].ToString());
            }
            return usuarios;
        }
    }
}
