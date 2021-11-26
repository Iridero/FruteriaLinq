using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruteriaLinq
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }
        public Inventario inv { get; set; }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (inv.Productos.Any(p=>p.Nombre.ToUpper()==txtNombre.Text.ToUpper().Trim()))
            {
                throw new ArgumentException("Nombre duplicado");
            }
            
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            cmbCategoria.DataSource = inv.Categorias;
            cmbUnidadMedida.DataSource = inv.UnidadesMedida();
        }
    }
}
