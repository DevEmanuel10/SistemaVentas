using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sesion.Clientes;

namespace sesion.Clientes
{
    public partial class Cliente : Form
    {
        int idCliente = 0; //Agregado para Gestionar Update Cliente

        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            loadDepartamento();
            loadCliente();
            loadtipodocumento();
            loadtipocliente();
        }

        public void loadCliente()
        {
            Controladores.ClienteControllers cliente = new Controladores.ClienteControllers();
            //dataGridView1.DataSource = cliente.GetCliente();
            dataGridView1.DataSource = cliente.GetAll();
            this.dataGridView1.Columns["id"].Visible = false;            
        }

        public void loadDepartamento()
        {
            Controladores.DepartamentoController departamento = new Controladores.DepartamentoController();
            cmbDepartamento.DataSource = departamento.getDepartamento();
            cmbDepartamento.DisplayMember = "nombre";
            cmbDepartamento.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbDepartamento.AutoCompleteSource = AutoCompleteSource.ListItems;
        }      

        

        public void loadLocalidades(int id_dep)
        {
            Controladores.Localidades.LocalidadesController localidades = new Controladores.Localidades.LocalidadesController();
            cmbLocalidad.DataSource = localidades.getLocalidades(id_dep);
            cmbLocalidad.DisplayMember = "Nombre";
            cmbLocalidad.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbLocalidad.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void loadtipodocumento()
        {
            Controladores.TipoDocumento.TipoDocumentoController tipo = new Controladores.TipoDocumento.TipoDocumentoController();

            cmbTipoDoc.DataSource = tipo.getTipoDocumento();
            cmbTipoDoc.DisplayMember = "nombre";
            cmbTipoDoc.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTipoDoc.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        /// <summary>
        /// Creo este metodo para que sea llamado para 3 diferentes funcion
        /// Add y update. los 2 van a hacer lo mismo, Evitamos duplicar codigo al pedo =)
        /// </summary>
        /// <param name="estado">Dependiendo desde lo llamemos, le pasamos el estado</param>
        /// <returns></returns>
        private Modelos.Cliente.ClienteViewModel CreateCliente(string estado)
        {
            Modelos.Cliente.ClienteViewModel clienteModel = new Modelos.Cliente.ClienteViewModel();            
            clienteModel.id = idCliente;
            clienteModel.nombre = txtNombre.Text;
            clienteModel.apellido = txtApellido.Text;
            clienteModel.id_tipoDoc = ((Modelos.TipoDocumento.TipoDocumentoViewModel)cmbTipoDoc.SelectedValue).id;
            clienteModel.nro_doc = int.Parse(txtNroDoc.Text);//Hay que asegurar que solo se ingrese numero, sino se rompe
            //Si completas un numero de cuil 20345678765, El programa rompe. 
            //Opciones cambiar el tipo a string, o poner mas grande el tamaño del numero
            clienteModel.id_tipoCliente = ((Modelos.TipoCliente.TipoClienteViewModel)cmbTipoCliente.SelectedValue).id;
            clienteModel.id_localidad = ((Modelos.Localidades.LocalidadesViewModel)cmbLocalidad.SelectedValue).ID;
            clienteModel.cp = int.Parse(txtCodigoPostal.Text);
            clienteModel.domicilio = txtDomicilio.Text;
            clienteModel.telefono = txtTelefono.Text;
            clienteModel.mail = txtMail.Text;

            Controladores.EstadosController estadoController = new Controladores.EstadosController();
            clienteModel.id_estado = estadoController.GetId(estado);//Lo hablado para obtenerlo bien
            return clienteModel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {                        
            //Modelos.Cliente.ClienteViewModel clienteModel = new Modelos.Cliente.ClienteViewModel();
            Controladores.ClienteControllers clientecontroller = new Controladores.ClienteControllers();
            //clienteModel.nombre = txtNombre.Text;
            //clienteModel.apellido = txtApellido.Text;
            //clienteModel.id_tipoDoc = ((Modelos.TipoDocumento.TipoDocumentoViewModel)cmbTipoDoc.SelectedValue).id;
            //clienteModel.nro_doc = int.Parse(txtNroDoc.Text);//Hay que asegurar que solo se ingrese numero, sino se rompe
            ////Si completas un numero de cuil 20345678765, El programa rompe. 
            ////Opciones cambiar el tipo a string, o poner mas grande el tamaño del numero
            //clienteModel.id_tipoCliente = ((Modelos.TipoCliente.TipoClienteViewModel)cmbTipoCliente.SelectedValue).id;
            //clienteModel.id_localidad = ((Modelos.Localidades.LocalidadesViewModel)cmbLocalidad.SelectedValue).ID;
            //clienteModel.cp = int.Parse(txtCodigoPostal.Text);
            //clienteModel.domicilio = txtDomicilio.Text;
            //clienteModel.telefono = txtTelefono.Text;
            //clienteModel.mail = txtMail.Text;
            //
            //Controladores.EstadosController estadoController = new Controladores.EstadosController();
            //clienteModel.id_estado = estadoController.GetId("ACTIVO");//Lo hablado para obtenerlo bien

            //clientecontroller.InsertarCliente(clienteModel.nombre,
            //                                  clienteModel.apellido,
            //                                  clienteModel.id_tipoDoc,
            //                                  clienteModel.nro_doc,
            //                                  clienteModel.id_tipoCliente,
            //                                  clienteModel.id_localidad,
            //                                  clienteModel.cp,
            //                                  clienteModel.domicilio,
            //                                  clienteModel.telefono,
            //                                  clienteModel.mail);

            clientecontroller.Add(CreateCliente("ACTIVO")); //Probalo asi que funca

            MessageBox.Show("El cliente se creo correcamente", "Cliente");

            loadCliente();

        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (idCliente > 0)
            {
                Controladores.ClienteControllers clientecontroller = new Controladores.ClienteControllers();
                clientecontroller.Update(CreateCliente("MODIFICADO")); //Probalo asi que funca
                MessageBox.Show("El cliente se Ha modificado", "Cliente");
                loadCliente();
            }
            else
            {
                MessageBox.Show("NO HA SELECCIONADO NINGUN CLIENTE");
            }
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (idCliente > 0)
            {
                Controladores.ClienteControllers clientecontroller = new Controladores.ClienteControllers();                
                clientecontroller.Delete(idCliente);
                MessageBox.Show("El cliente se ha eliminado", "Cliente");
                loadCliente();
            }
            else
            {
                MessageBox.Show("NO HA SELECCIONADO NINGUN CLIENTE");
            }
            
        }



        private void cmbDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id_dep = Convert.ToInt32(((Modelos.Departamentos.DepartamentoViewModel)cmbDepartamento.SelectedValue).ID);
            loadLocalidades(id_dep);
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_dep = Convert.ToInt32(((Modelos.Departamentos.DepartamentoViewModel)cmbDepartamento.SelectedValue).ID);
            loadLocalidades(id_dep);
        }

               
        #region sergio

        public void loadtipocliente()
        {
            Controladores.TipoCliente.TipoClienteController tipo = new Controladores.TipoCliente.TipoClienteController();

            cmbTipoCliente.DataSource = tipo.getTipoCliente();
            cmbTipoCliente.DisplayMember = "nombre";
            cmbTipoDoc.SelectedIndex = -1;
            cmbTipoCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTipoCliente.AutoCompleteSource = AutoCompleteSource.ListItems;

        }







        #endregion


        //Casi hecho, te dejo la magia de completar el combobox jaja
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idCliente= Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

            Modelos.Cliente.ClienteViewModel ClienteVM = new Modelos.Cliente.ClienteViewModel();
            Controladores.ClienteControllers ClienteC = new Controladores.ClienteControllers();

            ClienteVM = ClienteC.Get(idCliente);

            txtNombre.Text = ClienteVM.nombre;
            txtApellido.Text = ClienteVM.apellido;
            //...continuara jaja
        }

        
    }
}
