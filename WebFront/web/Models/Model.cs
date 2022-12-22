namespace web.Models
{
    public class Model
    {
        public class user
        {
            public string usuario { get; set; }
            public string contrasena { get; set; }
        }

        public class validacionAut
        {
            public string mensaje { get; set; }
            public bool? login { get; set; }
        }

        public class parametricas
        {
            public decimal id { get; set; }
            public string descripcion { get; set; }
        }

        public class datasUser
        {
           public decimal? id { get; set; }
           public string primerNombre {get; set;}
           public string? segundoNombre {get; set;}
           public string primerApellido {get; set;}
           public string? segundoApellido {get; set;}
           public string login {get; set;}
           public string contraseña {get; set;}
           public string correo {get; set;}
           public string telefono {get; set;}
           public decimal idRol {get; set;}
        }

        public class routerAdmin
        {
            public string nombreRed { get; set; }
            public string contrasennaRed { get; set; }
        }

        public class Responses
        {
            public object Response { get; set; }
            public bool Error { get; set; }
        }
    }
}
