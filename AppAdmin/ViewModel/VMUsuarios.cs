using System;
using System.Collections.Generic;
using System.Text;
using AppAdmin.Datos;
using AppAdmin.Models;
using AppAdmin.Conexiones;
using AppAdmin.Vistas;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace AppAdmin.ViewModel
{
    public class VMUsuarios : BaseViewModel
    {
        #region VARIABLES
        public string apellidos;
        public string nombres;
        public string dni;
        public string direccion;
        public string telefono;
        #endregion

        #region OBJETOS
        public string txtApellidos
        {
            get { return apellidos; }
            set { SetValue( ref apellidos, value); }
        }
        public string txtNombres
        {
            get { return nombres; }
            set { SetValue(ref nombres, value); }
        }
        public string txtDni
        {
            get { return dni; }
            set { SetValue(ref dni, value); }
        }
        public string txtDireccion
        {
            get { return direccion; }
            set { SetValue(ref direccion, value); }
        }
        public string txtTelefono
        { 
            get { return telefono; }
            set { SetValue(ref telefono, value); }
        }
        #endregion

        #region PROCESOS
        private async  Task InsertarUsuarios()
        {
            var funcion = new DUsuarios();
            var campos = new MUsuarios();
            campos.Apellidos = txtApellidos;
            campos.Nombres = txtNombres;
            campos.Dni = txtDni;
            campos.Direccion = txtDireccion;
            campos.Telefono = txtTelefono;
            var estadofuncion = await funcion.InsertUsuario(campos);
            if(estadofuncion==true)
            {
                await DisplayAlert("Registro", "Se registro correctamente el usuario Admin", "OK");
            }
        }
        #endregion

        #region COMANDOS
        public Command InsertComando { get; }
        #endregion

        #region CONSTRUCTOR
        public VMUsuarios(INavigation navigation)
        {
            Navigation = navigation;
            InsertComando = new Command(async ()=> await InsertarUsuarios());
        }
        #endregion
    }
}
