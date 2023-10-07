using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TIpoParcial2.Datos
{
    public class HelperDao
    {
        private SqlConnection _conn;
        private static HelperDao instance;
       
        private HelperDao()
        {
            _conn = new SqlConnection(Properties.Resources.SqlString);
           
        }
        public static HelperDao getInstance() 
        {
            if (instance==null)
            {
                instance = new HelperDao();
            }
            return instance;
        }

        public SqlConnection GetSqlConnection()
        {
            return this._conn;
        }


        public DataTable ConsultarSp(string nombreSp) 
        {
            _conn.Open();
            SqlCommand cmd = new SqlCommand(nombreSp,_conn);
            cmd.CommandType = CommandType.StoredProcedure;
         
            DataTable dataTable = new DataTable();
            dataTable.Load(cmd.ExecuteReader());

            _conn.Close();
            return dataTable;
        }

        public DataTable Consultar(string nombreSP, List<Parametro> lstParametros)
        {
            
            _conn.Open();
            SqlCommand comando = new SqlCommand(nombreSP,_conn);  
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            foreach (Parametro p in lstParametros)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            _conn.Close();
            return tabla;
        }

        public void Executer(string nombreSp,SqlParameter p)
        {
            _conn.Open();
            SqlCommand comando = new SqlCommand(nombreSp,_conn);
            comando.CommandType= CommandType.StoredProcedure;
           
            comando.Parameters.Add(p);
            comando.ExecuteNonQuery();
            _conn.Close();


        }


    }
}
