using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
namespace AppAdmin.Conexiones
{
    public class Conexion
    {
        public static FirebaseClient clienteFirebase = new FirebaseClient("https://appadmin-971ce-default-rtdb.firebaseio.com/");
    }
}
