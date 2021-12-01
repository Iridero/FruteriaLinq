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
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }
        public Inventario Inventario { get; set; }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Inventario.AgregarCategoria(txtNombreNuevo.Text);
                ActualizarListBox();
            }
            catch(Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        private void ActualizarListBox()
        {
            lstCategorias.DataSource = null;
            lstCategorias.DataSource = Inventario.Categorias;
            lstCategorias.DisplayMember = "Nombre";
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            ActualizarListBox();
        }

        private void FrmCategorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            Inventario.GuardarCategorias();
        }

        private void lstCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Categoria cat = (Categoria)lstCategorias.SelectedItem;
            if (cat!=null)
            {
                txtNombre.Text = cat.Nombre;
                chkEliminada.Checked = cat.Eliminada; 
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Inventario.ActualizarCategoría(
                       ((Categoria)lstCategorias.SelectedItem).Id,
                       txtNombre.Text.Trim(), chkEliminada.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
             
            }
        }
    }
}
