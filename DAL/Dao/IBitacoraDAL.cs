namespace DAL.Dao
{
    using BE;
    using BE.Entidades;
    using System;
    using System.Collections.Generic;


    //Declarar los metodos de la interfaz
    public interface IBitacoraDAL
    {
        void FiltrarBitacora(FiltrosBitacora filtros);

        Bitacora LeerBitacoraConId(int bitacoraId);

        int GenerarDVH(Usuario usu);

        int ObtenerUltimoIdBitacora();

        List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<string> usuarios, List<string> criticidades, string desde, string hasta);

        List<string> CargarUsuarios();
    }
}
