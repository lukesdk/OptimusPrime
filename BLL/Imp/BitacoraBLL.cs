namespace BLL
{
    using BE.Entidades;
    using DAL.Dao;
    using EasyEncryption;
    using log4net;
    using System;
    using System.Collections.Generic;

    //Llave que voy a utilizar para la encriptacion 
    public class BitacoraBLL : IBitacoraBLL
    {
        private const string Key = "bZr2URKx";
        private const string Iv = "HNtgQw0w";
        private readonly IBitacoraDAL bitacoraDAL;
        private readonly IDigitoVerificador digitoVerificador;

        public BitacoraBLL(IBitacoraDAL bitacoraDAL, IDigitoVerificador digitoVerificador)
        {
            this.bitacoraDAL = bitacoraDAL;
            this.digitoVerificador = digitoVerificador;
        }

        public void CargarDVHBitacora()
        {
            bitacoraDAL.CargarDVHBitacora();
        }

        public List<string> CargarUsuarios()
        {
            return bitacoraDAL.CargarUsuarios();
        }

        public Bitacora FiltrarBitacora(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<string> usuarios, List<string> criticidades, string desde, string hasta)
        {
            return bitacoraDAL.LeerBitacoraPorUsuarioCriticidadYFecha(usuarios, criticidades, desde, hasta);
        }

        public void RegistrarEnBitacora(Usuario usu)
        {
            if (usu.Email != null)
            {
                MDC.Set("usuario", DES.Decrypt(usu.Email, Key, Iv));
            }
            else
            {
                MDC.Set("usuario", "Sistema");
            }

            var digitoVH = bitacoraDAL.GenerarDVH();

            GlobalContext.Properties["dvh"] = digitoVH;

            digitoVerificador.ActualizarDVVertical("Bitacora");
        }
    }
}
