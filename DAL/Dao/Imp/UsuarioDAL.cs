namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using EasyEncryption;
    using System;
    using System.Collections.Generic;

    public class UsuarioDAL : BaseDao, ICRUD<Usuario>, IUsuarioDAL
    {
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";

        private readonly IDigitoVerificador digitoVerificador;
        private readonly IFamiliaDAL familiaDAL;
        private readonly IPatenteDAL patenteDAL;

        public UsuarioDAL(IDigitoVerificador digitoVerificador, IFamiliaDAL familiaDAL, IPatenteDAL patenteDAL)
        {
            this.digitoVerificador = digitoVerificador;
            this.familiaDAL = familiaDAL;
            this.patenteDAL = patenteDAL;
        }

        public bool Crear(Usuario objAlta)
        {
            var contEncript = MD5.ComputeMD5Hash(new Random().Next().ToString());
            var emailEncript = DES.Encrypt(objAlta.Email, Key, Iv);

            objAlta.UsuarioId = ObtenerUltimoIdUsuario() + 1;
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { objAlta.Nombre, emailEncript, contEncript }, new List<int> { objAlta.UsuarioId });

            var queryString = "INSERT INTO Usuario(Nombre, Apellido, Contraseña, Email, Telefono, Domicilio, ContadorIngresosIncorrectos, " +
                "IdCanalVenta, IdIdioma, PrimerLogin, DVH, Activo) " +
                "VALUES (@nombre, @apellido, @contraseña, @email, @telefono, @domicilio, @contadorIngresos, @idCanalVenta, @idIdioma, " +
                "@primerLogin, @dvh, @activo)";

            return CatchException(() =>
              {
                  return Exec(
                      queryString,
                      new
                      {
                          @nombre = objAlta.Nombre,
                          @apellido = objAlta.Apellido,
                          @contraseña = contEncript,
                          @email = emailEncript,
                          @telefono = objAlta.Telefono,
                          @domicilio = objAlta.Domicilio,
                          @contadorIngresos = objAlta.ContadorIngresosIncorrectos = 0,
                          @idCanalVenta = objAlta.IdCanalVenta,
                          @idIdioma = objAlta.IdIdioma,
                          @primerLogin = Convert.ToByte(objAlta.PrimerLogin = true),
                          @dvh = digitoVH,
                          @activo = 1
                      });
              });
        }

        public List<Usuario> Cargar()
        {
            var queryString = "SELECT * FROM Usuario WHERE Activo = 1;";

            return CatchException(() =>
            {
                return Exec<Usuario>(queryString);
            });
        }

        public List<Usuario> CargarInactivos()
        {
            var queryString = "SELECT Email FROM Usuario WHERE Activo = 0;";
            var usuarios = new List<Usuario>();

            CatchException(() =>
            {
                usuarios = Exec<Usuario>(queryString);
            });

            usuarios.ForEach(x => DES.Decrypt(x.Email, Key, Iv));

            return usuarios;
        }

        public bool Borrar(Usuario objDel)
        {
            var usu = ObtenerUsuarioConEmail(objDel.Email);

            var queryString = string.Format("UPDATE Usuario SET Activo = 0 WHERE UsuarioId = {0}", usu.UsuarioId);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool Actualizar(Usuario objUpd)
        {
            var usu = ObtenerUsuarioConEmail(objUpd.Email);
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { objUpd.Nombre, usu.Email }, new List<int> { usu.UsuarioId });

            var queryString = $"UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido, Email = @email, Telefono = @telefono, Domicilio = @domicilio, DVH = @dvh, PrimerLogin=@PrimerLogin WHERE UsuarioId = @usuarioId";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @usuarioId = usu.UsuarioId,
                        @nombre = objUpd.Nombre,
                        @apellido = objUpd.Apellido,
                        @email = usu.Email,
                        @telefono = objUpd.Telefono,
                        @domicilio = objUpd.Domicilio,
                        @dvh = digitoVH,
                        @PrimerLogin=objUpd.PrimerLogin,
                    });
            });
        }

        public bool LogIn(string email, string contraseña)
        {
            var ingresa = false;

            var usu = ObtenerUsuarioConEmail(email);

            if (usu.Email != null)
            {
                if (usu.Activo)
                {
                    if (!usu.PrimerLogin)
                    {
                        var cingresoInc = usu.ContadorIngresosIncorrectos;

                        if (cingresoInc < 3)
                        {
                            var contEncriptada = MD5.ComputeMD5Hash(contraseña);

                            ingresa = ValidarContraseña(usu.Contraseña, contEncriptada);

                            if (!ingresa)
                            {
                                AumentarIngresos(usu, usu.ContadorIngresosIncorrectos);
                                return false;
                            }

                            return true;
                        }

                        return false;
                    }

                    return true;
                }
            }

            return false;
        }

        public bool CambiarContraseña(Usuario usuario, string nuevaContraseña, bool primerLogin = false)
        {
            var contEncript = MD5.ComputeMD5Hash(nuevaContraseña);
            var queryString = string.Empty;
            if (primerLogin == true)
            {
                queryString = "UPDATE Usuario SET Contraseña = @contraseña, PrimerLogin = 0 WHERE UsuarioId = @usuarioId";
            }
            else
            {
                queryString = "UPDATE Usuario SET Contraseña = @contraseña WHERE UsuarioId = @usuarioId";
            }

            return CatchException(() =>
            {
                return Exec(queryString, new { @usuarioId = usuario.UsuarioId, @contraseña = contEncript });
            });
        }

        public Usuario ObtenerUsuarioConEmail(string email)
        {
            var usuario = new List<Usuario>();
            var queryString = "SELECT * FROM dbo.Usuario WHERE Email = @email";

            CatchException(() =>
            {
                usuario = Exec<Usuario>(queryString, new { @email = DES.Encrypt(email, Key, Iv) });
            });

            if (usuario.Count > 0)
            {
                return usuario[0];
            }
            else
            {
                return new Usuario();
            }
        }

        public Usuario ObtenerUsuarioConId(int usuarioId)
        {
            var usuario = new List<Usuario>();
            var queryString = "SELECT * FROM dbo.Usuario WHERE UsuarioId = @UsuarioId";

            CatchException(() =>
            {
                usuario = Exec<Usuario>(queryString, new { UsuarioId = usuarioId });
            });

            if (usuario.Count > 0)
            {
                return usuario[0];
            }
            else
            {
                return new Usuario();
            }
        }

        public List<Patente> ObtenerPatentesDeUsuario(int usuarioId)
        {
            var queryString = $"SELECT UsuarioPatente.IdPatente, Patente.Descripcion, UsuarioPatente.Negada FROM UsuarioPatente INNER JOIN Patente ON UsuarioPatente.IdPatente = Patente.IdPatente WHERE UsuarioId = {usuarioId}";

            return CatchException(() =>
            {
                return Exec<Patente>(queryString);
            });
        }

        public bool ActivarUsuario(string email)
        {
            var usu = ObtenerUsuarioConEmail(email);

            var queryString = string.Format("UPDATE Usuario SET Activo = 1 WHERE UsuarioId = {0}", usu.UsuarioId);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool DesactivarUsuario(string email)
        {
            return Borrar(new Usuario() { Email = email });
        }

        public Usuario CargarPatentesYFamiliaUsuario(Usuario usuario)
        {
            usuario.Familia = new List<Familia>();
            usuario.Patentes = new List<Patente>();

            usuario.Familia = familiaDAL.ObtenerFamiliasUsuario(usuario.UsuarioId);
            usuario.Patentes = patenteDAL.ObtenerPatentesUsuario(usuario.UsuarioId);

            return usuario;
        }

        public List<Usuario> TraerUsuariosConPatentesYFamilias()
        {
            var usuarios = Cargar();

            foreach (var usuario in usuarios)
            {
                usuario.Familia = new List<Familia>();
                usuario.Patentes = new List<Patente>();

                usuario.Familia = familiaDAL.ObtenerFamiliasUsuario(usuario.UsuarioId);
                usuario.Patentes = patenteDAL.ObtenerPatentesUsuario(usuario.UsuarioId);
            }

            return usuarios;
        }

        private bool ValidarContraseña(string contraseña, string contEncriptada)
        {
            if (contraseña == contEncriptada)
            {
                return true;
            }

            return false;
        }

        private void AumentarIngresos(Usuario usuario, int ingresos)
        {
            var ingresosSel = ingresos;
            var querySelect = string.Format("SELECT ContadorIngresosIncorrectos FROM Usuario WHERE UsuarioId = {0}", usuario.UsuarioId);

            CatchException(() =>
            {
                ingresosSel = 1 + Exec<int>(querySelect)[0];
            });

            var queryString = string.Format("UPDATE Usuario SET ContadorIngresosIncorrectos = {1} WHERE UsuarioId = {0}", usuario.UsuarioId, ingresosSel);

            CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        private int ObtenerUltimoIdUsuario()
        {
            var queryString = "SELECT IDENT_CURRENT ('[dbo].[Usuario]') AS Current_Identity;";

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }
    }
}
