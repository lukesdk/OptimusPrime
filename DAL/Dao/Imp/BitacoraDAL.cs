namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Dao;
    using DAL.Utils;
    using EasyEncryption;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class BitacoraDAL : BaseDao, IBitacoraDAL
    {
        public const string Key = "bZr2URKx";
        public const string Code = "HNtgQw0w";

        private readonly IDigitoVerificador digitoVerificador;

        public BitacoraDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public void FiltrarBitacora(FiltrosBitacora filtros)
        {
            var queryString = new StringBuilder();

            var baseQuery = string.Format("SELECT * FROM Bitacora WHERE Fecha >= {0} AND Fecha <= {1} ", filtros.FechaDesde, filtros.FechaHasta);

            queryString.Append(baseQuery);

            if (filtros.IdsUsuarios.Count > 0)
            {
                queryString.Append(string.Format("AND UsuarioId IN ({0})", filtros.IdsUsuarios));
            }

            if (filtros.Criticidades.Count > 0)
            {
                queryString.Append(string.Format("AND Criticidad IN ({0})", filtros.Criticidades));
            }

            CatchException(() =>
            {
                return Exec(queryString.ToString());
            });
        }

        public Bitacora LeerBitacoraConId(int bitacoraId)
        {
            var queryString = $"SELECT * FROM Bitacora WHERE IdLog = {bitacoraId}";

            return CatchException(() =>
             {
                 return Exec<Bitacora>(queryString)[0];
             });
        }

        public int ObtenerUltimoIdBitacora()
        {
            var queryString = "SELECT IDENT_CURRENT ('[dbo].[Bitacora]') AS Current_Identity;";

            return CatchException(() =>
            {
                return Exec<int>(queryString).FirstOrDefault();
            });
        }

        public List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<string> usuarios, List<string> criticidades, DateTime desde, DateTime hasta)
        {
            var queryImpl = "SELECT * from Bitacora WHERE ";
            var idsUsuParameters = string.Empty;
            var criticidadesParameters = string.Empty;
            var coma = string.Empty;
            var query = string.Empty;
            var bitacoras = new List<Bitacora>();

            if (usuarios.Count != 0)
            {
                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (i != 0)
                    {
                        coma = ",";
                    }

                    idsUsuParameters += coma + "'" + usuarios[i] + "'";
                }

                queryImpl += string.Format("Usuario IN ({0}) AND  ", idsUsuParameters);
            }

            coma = string.Empty;
            if (criticidades.Count != 0)
            {
                for (int i = 0; i < criticidades.Count; i++)
                {
                    if (i != 0)
                    {
                        coma = ",";
                    }

                    criticidadesParameters += coma + "'" + criticidades[i] + "'";
                }

                queryImpl += string.Format("Criticidad IN ({0}) AND  ", criticidadesParameters);
            }

            query = string.Format(queryImpl + " Fecha BETWEEN '{0}' AND '{1}'", desde.ToString("yyyy-MM-dd",CultureInfo.InvariantCulture), hasta.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));

            CatchException(() =>
            {
                bitacoras = Exec<Bitacora>(query);
            });

            bitacoras.ForEach(x => x.InformacionAsociada = DES.Decrypt(x.InformacionAsociada, Key, Code));

            return bitacoras;
        }

        public int GenerarDVH(Usuario usu)
        {
            var bitacora = new Bitacora();
            var bitacoraId = ObtenerUltimoIdBitacora();

            if (bitacoraId == 1)
            {
                bitacora.InformacionAsociada = "primer login";
                bitacora.Actividad = "Login";
                bitacora.Criticidad = "primer Login";
            }

            bitacora = LeerBitacoraConId(bitacoraId);
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { bitacora.InformacionAsociada, bitacora.Actividad, bitacora.Criticidad }, new List<int> { usu.UsuarioId, bitacoraId });
            return digitoVH;
        }

        public List<string> CargarUsuarios()
        {
            var queryString = "SELECT Usuario FROM Bitacora GROUP BY Usuario";

            return CatchException(() =>
            {
                return Exec<string>(queryString);
            });
        }
    }
}
