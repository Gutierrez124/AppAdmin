using System;
using System.Collections.Generic;
using System.Text;
using AppAdmin.Models;
using AppAdmin.Conexiones;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace AppAdmin.Datos
{
    public class DUsuarios
    {
        public async Task<bool> InsertUsuario(MUsuarios musuarios)
        {
            await Conexion.clienteFirebase
                .Child("Usuarios").PostAsync(new MUsuarios()
                {
                    Apellidos = musuarios.Apellidos,
                    Nombres = musuarios.Nombres,
                    Dni = musuarios.Dni,
                    Direccion = musuarios.Direccion,
                    Telefono = musuarios.Telefono,
                });
            return true;
        }
    }
}
