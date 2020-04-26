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

            if (string.IsNullOrEmpty(txtCategoria.Text)|| string.IsNullOrEmpty(txtNombre.Text)||string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Completa los campos pancho.");
            }

            else
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

        public void loadProducto()
        {
            //Controladores.ClienteControllers cliente = new Controladores.ClienteControllers();
            Controladores.Productos.ProductoController producto = new Controladores.Productos.ProductoController();
            //dataGridView1.DataSource = cliente.GetCliente();
            dataGridView1.DataSource = producto.GetAll();
            this.dataGridView1.Columns["id"].Visible = false;
        }

        int idProducto = 0; //Agregado para Gestionar baja o modificacion de producto

        //private void dataGridView1_CellMouseClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

        //    //Modelos.Cliente.ClienteViewModel ClienteVM = new Modelos.Cliente.ClienteViewModel();
        //    //Controladores.ClienteControllers ClienteC = new Controladores.ClienteControllers();

        //    Modelos.Productos.ProductosViewModel ProductoVM = new Modelos.Productos.ProductosViewModel();
        //    Controladores.Productos.ProductoController ProductoC = new Controladores.Productos.ProductoController();

        //    //ClienteVM = ClienteC.Get(idCliente);
        //    ProductoVM = ProductoC.Get(idProducto);

        

        //    txtNombre.Text = ProductoVM.nombre;

        //    //txtNombre.Text = ClienteVM.nombre;
        //    //txtApellido.Text = ClienteVM.apellido;
        //    //...continuara jaja
        //}

       
        

        private void productos_Load(object sender, EventArgs e)
        {
            LoadUnidad();
            loadProducto();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            Modelos.Productos.ProductosViewModel ProductoVM = new Modelos.Productos.ProductosViewModel();
            Controladores.Productos.ProductoController ProductoC = new Controladores.Productos.ProductoController();

            ProductoVM = ProductoC.Get(idProducto);
                        
            txtNombre.Text = ProductoVM.nombre;
            txtCategoria.Text = ProductoVM.categoria;
            txtCodigo.Text = ProductoVM.codigo;
            txtDescripcion.Text = ProductoVM.descripcion;

            Controladores.Unidad.UnidadController unidadVM = new Controladores.Unidad.UnidadController();


            var pepe = unidadVM.Get(ProductoVM.id_unidad);



            cmbUnidad.Text = pepe.nombre;

           

            //ProductoVM.id_unidad = ((Modelos.Unidad.UnidadViewModel)cmbUnidad.SelectedValue).id;



        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (idProducto > 0)
            {
                Controladores.Productos.ProductoController productocontroller = new Controladores.Productos.ProductoController();
                productocontroller.Delete(idProducto);
                MessageBox.Show("El producto se ha eliminado", "Producto");
                //loadProducto();
            }
            else
            {
                MessageBox.Show("Elegí un producto salchica!!");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
