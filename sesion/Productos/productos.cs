using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sesion.Productos
{
    public partial class productos : Form
    {
        public productos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                Modelos.Productos.ProductosViewModel ProductoVM = new Modelos.Productos.ProductosViewModel();

                ProductoVM.nombre = txtNombre.Text;
                ProductoVM.categoria = txtCategoria.Text;
                ProductoVM.descripcion = txtDescripcion.Text;
                ProductoVM.codigo = txtCodigo.Text;
                ProductoVM.id_unidad = ((Modelos.Unidad.UnidadViewModel)cmbUnidad.SelectedValue).id;

                Controladores.EstadosController estado = new Controladores.EstadosController();
                ProductoVM.id_estado = estado.GetId("ACTIVO");

                Controladores.Productos.ProductoController productoC = new Controladores.Productos.ProductoController();

                productoC.Add(ProductoVM);

                MessageBox.Show("Producto agregado");
              
            }
            catch (FormatException)
            {
                MessageBox.Show("le pifiaste ameo");
            }

        }
        public void LoadUnidad()
        {
            //Controladores.TipoDocumento.TipoDocumentoController tipo = new Controladores.TipoDocumento.TipoDocumentoController();

            Controladores.Unidad.UnidadController unidadC = new Controladores.Unidad.UnidadController();

            //cmbTipoDoc.DataSource = tipo.getTipoDocumento();
            //cmbTipoDoc.DisplayMember = "nombre";
            //cmbTipoDoc.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cmbTipoDoc.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbUnidad.DataSource = unidadC.GetAll();
            cmbUnidad.DisplayMember = "nombre";
            cmbUnidad.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbUnidad.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void productos_Load(object sender, EventArgs e)
        {
            LoadUnidad();
        }
    }
}
