using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIpoParcial2.Datos;
using TIpoParcial2.Servicios.Implementacion;
using TIpoParcial2.Servicios.Interfaz;

namespace TIpoParcial2
{
    public partial class FrmConsulta : Form
    {
        IServicio servicio;
        public FrmConsulta()
        {
            InitializeComponent();
            servicio = new Servicio();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            CargarClientes();
        }

        private void CargarClientes()
        {
            cboClientes.ValueMember = "id_cliente";
            cboClientes.DisplayMember="nombre";
            cboClientes.DataSource = servicio.TraerClientes();
            cboClientes.SelectedIndex = -1;
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int error = cboClientes.SelectedIndex + 1;
           List<Parametro>lstParametros= new List<Parametro>();
            lstParametros.Add(new Parametro("@cliente",error));
            lstParametros.Add(new Parametro("@fecha_desde",dtpDesde.Value));
            lstParametros.Add(new Parametro("@fecha_hasta",dtpHasta.Value));
           
            DataTable dt = new DataTable();
            dt = HelperDao.getInstance().Consultar("SP_CONSULTAR_PEDIDOS",lstParametros);
            dgvPedidos.Rows.Clear();
            foreach (DataRow fila in dt.Rows)
            {
                dgvPedidos.Rows.Add(new object[] {fila[0].ToString(),
                                                  fila[6].ToString(),
                                                  fila[5].ToString(),
                                                  fila[4].ToString(),
                                                       });

               
            }
        }

        //private bool Validar()
        //{
        //    if(cboClientes.SelectedIndex == -1)
        //    {
        //        MessageBox.Show("Debe Ingresar un Cliente","Seleccionar",MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    if (true)
        //    {

        //    }
        //    return true;
        //}

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPedidos.CurrentCell.ColumnIndex == 4)
            {
                if (dgvPedidos.CurrentRow.Cells[0].Value.ToString() == "S")
                {
                    MessageBox.Show("Ya esta entregado");
                }
                else
                {
                    SqlParameter p = new SqlParameter();
                    p.ParameterName = "@codigo";
                    p.SqlDbType = SqlDbType.Int;
                    p.Direction = ParameterDirection.Input;
                    p.Value = dgvPedidos.CurrentRow.Cells[0].Value;
                    HelperDao.getInstance().Executer("SP_REGISTRAR_ENTREGA", p);
                    MessageBox.Show("Se entrego con exito");
                    dgvPedidos.Refresh();                
                }
               
               
                
            }
            if (dgvPedidos.CurrentCell.ColumnIndex == 5)
            {
                if(MessageBox.Show("Desea eliminar", "eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlParameter p = new SqlParameter();
                    p.ParameterName = "@codigo";
                    p.SqlDbType = SqlDbType.Int;
                    p.Direction = ParameterDirection.Input;
                    p.Value = dgvPedidos.CurrentRow.Cells[0].Value;
                    HelperDao.getInstance().Executer("SP_REGISTRAR_BAJA", p);
                    MessageBox.Show("Se elimino con exito");
                    dgvPedidos.Refresh();
                }
                
                
            }
        }
    }
}
