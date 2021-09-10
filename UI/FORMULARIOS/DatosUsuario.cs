﻿// <auto-generated/>
namespace UI
{
    using BE.Entidades;
    using BLL;
    using DAL;
    using DAL.Dao;
    using EasyEncryption;
    using log4net;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class DatosUsuario : Form, IDatosUsuario
    {
        private readonly IFormControl formControl;
        private readonly IUsuarioBLL usuarioBLL;
        private readonly IDigitoVerificador digitoVerificador;
        private readonly IUsuarioDAL usuarioDAL;
        public const string key = "bZr2URKx";
        public const string iv = "HNtgQw0w";
        private const string entidad = "Usuario";

        public Usuario UsuarioActivo { get; set; }
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DatosUsuario(IFormControl formControl, IUsuarioBLL usuarioBLL, IDigitoVerificador digitoVerificador, IUsuarioDAL usuarioDAL)
        {
            this.usuarioBLL = usuarioBLL;
            this.formControl = formControl;
            this.digitoVerificador = digitoVerificador;
            this.usuarioDAL = usuarioDAL;
            InitializeComponent();
        }

        private void DatosUsuario_Load(object sender, System.EventArgs e)
        {
            UsuarioActivo = formControl.ObtenerInfoUsuario();

            lblNombre.Text = lblNombre.Text + UsuarioActivo.Nombre;
            lblApellido.Text = lblApellido.Text + UsuarioActivo.Apellido;
            lblDireccion.Text = lblDireccion.Text + UsuarioActivo.Domicilio;
            lblEmail.Text = lblEmail.Text + DES.Decrypt(UsuarioActivo.Email, key, iv);
            lblTelefono.Text = lblTelefono.Text + UsuarioActivo.Telefono;
            chkCont.Enabled = false;
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            if (VerificarDatos())
            {
                if (chkCont.Checked)
                {
                    var nuevaContraseña = "";

                    var items = InputBox.fillItems("Contraseña", nuevaContraseña);

                    InputBox input = InputBox.Show("Ingrese nueva contraseña", items, InputBoxButtons.OK);

                    if (input.Result == InputBoxResult.OK)
                    {
                        nuevaContraseña = input.Items["Contraseña"];
                        var cambioExitoso = usuarioDAL.CambiarContraseña(UsuarioActivo, nuevaContraseña, true);
                        if (cambioExitoso)
                        {
                            //Log.Info("Password Actualizado");
                            MessageBox.Show("Su contraseña fue actualizada");
                        }
                        else
                        {
                            //Log.Info("Fallo la actualizacion del password");
                            MessageBox.Show("Error contraseña no actualizada");
                        }
                    }

                    usuarioBLL.Actualizar(new Usuario() { Nombre = txtNombre.Text, Telefono = int.Parse(txtTel.Text), Apellido = txtApellido.Text, Domicilio = txtDireccion.Text, Email = DES.Decrypt(UsuarioActivo.Email, key, iv) });
                }
                else
                {
                    usuarioBLL.Actualizar(new Usuario() { Nombre = txtNombre.Text, Telefono = int.Parse(txtTel.Text), Apellido = txtApellido.Text, Domicilio = txtDireccion.Text, Email = DES.Decrypt(UsuarioActivo.Email, key, iv) });
                }

                digitoVerificador.ActualizarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));

                MessageBox.Show("Usuario actualizado");
                lblNombre.Text = lblNombre.Text + UsuarioActivo.Nombre;
                lblApellido.Text = lblApellido.Text + UsuarioActivo.Apellido;
                lblDireccion.Text = lblDireccion.Text + UsuarioActivo.Domicilio;               
                lblTelefono.Text = lblTelefono.Text + UsuarioActivo.Telefono;

                txtNombre.Visible = false;
                txtApellido.Visible = false;
                txtDireccion.Visible = false;
                txtTel.Visible = false;

                this.Close();
            }
        }

        private bool VerificarDatos()
        {
            var returnValue = true;

            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(tb.Text.Trim()))
                {
                    MessageBox.Show("Todos los datos deben estar completos");
                    Log4netExtensions.Baja(log, "Todos los datos deben estar completos");
                    returnValue = false;
                    break;
                }

                if (tb.Name == "txtNombre")
                {
                    if (!Regex.IsMatch(tb.Text, @"[a-zA-Z]"))
                    {
                        MessageBox.Show("El campo nombre no acepta numeros");
                        returnValue = false;
                    }
                }

                if (tb.Name == "txtApellido")
                {
                    if (!Regex.IsMatch(tb.Text, @"[a-zA-Z]"))
                    {
                        MessageBox.Show("El campo apellido no acepta numeros");
                        returnValue = false;
                    }
                }

                if (tb.Name == "txtTel")
                {
                    if (Regex.IsMatch(tb.Text, @"[a-zA-Z]"))
                    {
                        MessageBox.Show("no puede ingresar letras");
                        returnValue = false;
                    }
                }
            }

            return returnValue;
        }

        private void DatosUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnCambiarDatos_Click(object sender, System.EventArgs e)
        {

            lblNombre.Text = "Nombre: ";
            lblApellido.Text = "Apellido: ";
            lblDireccion.Text = "Direccion: ";
            lblTelefono.Text = "Telefono: ";
            
            txtNombre.Visible = true;
            txtApellido.Visible = true;
            txtDireccion.Visible = true;
            txtTel.Visible = true;


            txtNombre.Text = UsuarioActivo.Nombre;
            txtApellido.Text = UsuarioActivo.Apellido;
            txtDireccion.Text = UsuarioActivo.Domicilio;
            txtTel.Text = UsuarioActivo.Telefono.ToString();

            chkCont.Enabled = true;
        }

        private void btnVolver_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void lblNombre_Click(object sender, System.EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
