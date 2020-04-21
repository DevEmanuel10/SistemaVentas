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
            dataGridView1.DataSource = cliente.GetCliente();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Modelos.Cliente.ClienteViewModel clienteModel = new Modelos.Cliente.ClienteViewModel();

            Controladores.ClienteControllers clientecontroller = new Controladores.ClienteControllers();

            clienteModel.nombre = txtNombre.Text;
            clienteModel.apellido = txtApellido.Text;
            clienteModel.id_tipoDoc = ((Modelos.TipoDocumento.TipoDocumentoViewModel)cmbTipoDoc.SelectedValue).id;
            clienteModel.nro_doc = int.Parse(txtNroDoc.Text);
            clienteModel.id_tipoCliente = ((Modelos.TipoCliente.TipoClienteViewModel)cmbTipoCliente.SelectedValue).id;
            clienteModel.id_localidad = ((Modelos.Localidades.LocalidadesViewModel)cmbLocalidad.SelectedValue).ID;
            clienteModel.cp = int.Parse(txtCodigoPostal.Text);
            clienteModel.domicilio = txtDomicilio.Text;
            clienteModel.telefono = txtTelefono.Text;
            clienteModel.mail = txtMail.Text;

            clientecontroller.InsertarCliente(clienteModel.nombre,
                                              clienteModel.apellido,
                                              clienteModel.id_tipoDoc,
                                              clienteModel.nro_doc,
                                              clienteModel.id_tipoCliente,
                                              clienteModel.id_localidad,
                                              clienteModel.cp,
                                              clienteModel.domicilio,
                                              clienteModel.telefono,
                                              clienteModel.mail);

            MessageBox.Show("El cliente se creo correcamente", "Cliente");

            loadCliente();

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





    }
}
