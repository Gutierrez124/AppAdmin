using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppAdmin.Datos;
using AppAdmin.Models;
using AppAdmin.Vistas;
using Xamarin.Forms;

namespace AppAdmin.ViewModel
{
    public class VMLogin : BaseViewModel
    {
        #region VARIABLES
        public string dni;
        public List<MUsuarios> listaUsuarios = new List<MUsuarios>();
        #endregion
        #region OBJETOS
        public string txtDni
        {
            get { return dni; }
            set { SetValue(ref dni, value); }
        
        }

        public List<MUsuarios> listUsuarios
        {
            get { return listaUsuarios; }
            set { SetValue(ref listaUsuarios, value); }
        }

        #endregion
        #region PROCESOS
        private async Task ValidarUsuario()
        {
            var funcion = new DUsuarios();
            var campos = new MUsuarios();
            campos.Dni = txtDni;
            listUsuarios = await funcion.ValidarLogin(campos);
            if (listUsuarios.Count > 0)
            {
                await Navigation.PushAsync( new Inicio ());
            }
            else
            {
                await DisplayAlert("Error de Inicio", "Usuario no registrado", "ok");
                
            }
        }
        #endregion
        #region COMANDOS
        public Command ComandoIniciar { get; }
        #endregion
        #region CONSTRUCTOR0
        public VMLogin(INavigation navigation)
        {
            Navigation = navigation;
            ComandoIniciar = new Command(async () => await ValidarUsuario());
        }
        #endregion
    }
}
