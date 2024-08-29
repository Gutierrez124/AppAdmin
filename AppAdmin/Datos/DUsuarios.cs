using System;
using System.Collections.Generic;
using System.Text;
using AppAdmin.Models;
using AppAdmin.Conexiones;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Linq;

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
        public async Task<List<MUsuarios>> ValidarLogin(MUsuarios mUsuarios)
        {
            return (await Conexion.clienteFirebase.
                Child("Usuarios").OnceAsync<MUsuarios>())
                .Where(a => a.Object.Dni == mUsuarios.Dni)
                .Select(item => new MUsuarios
                {
                    Dni = item.Object.Dni,
                    Apellidos = item.Object.Apellidos,
                    Nombres = item.Object.Nombres,
                    Direccion = item.Object.Direccion,
                    Telefono = item.Object.Telefono
                }
                ).ToList();
        }
    }
}
