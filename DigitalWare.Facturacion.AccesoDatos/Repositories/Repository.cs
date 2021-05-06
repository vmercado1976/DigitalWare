using DigitalWare.Facturacion.AccesoDatos.DbContext;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.AccesoDatos.Repositories
{
    public abstract class Repository
    {
        private readonly string strconnection;
        public Repository()
        {
            AppConfiguration oConfig = new AppConfiguration();
            strconnection = oConfig.strConnectionString;
        }
        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(strconnection);
        }
    }
}
