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
        Controladores.ClienteControllers cliente = new Controladores.ClienteControllers();
        Controladores.ProvinciaController provincia = new Controladores.ProvinciaController();
        Controladores.DepartamentoController departamento = new Controladores.DepartamentoController();
        Controladores.Localidades.LocalidadesController localidades = new Controladores.Localidades.LocalidadesController();
        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {

            loadDepartamento();
            loadCliente();
            loadtipodocumento();
        }

        public void loadCliente()
        {
            dataGridView1.DataSource = cliente.GetCliente();
        }

        public void loadDepartamento()
        {
            cmbDepartamento.DataSource = departamento.getDepartamento();
            cmbDepartamento.DisplayMember = "nombre";
            cmbDepartamento.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbDepartamento.AutoCompleteSource = AutoCompleteSource.ListItems;

            //if (cmbDepartamento.Items.Count != 0)
            //{
            //    int id_dep = Convert.ToInt32(((Modelos.Departamentos.DepartamentoViewModel)cmbDepartamento.SelectedValue).idProvincia);
            //    loadLocalidades(id_dep);
            //}
            //else
            //{
            //    cmbLocalidad.DataSource = null;                
            //}

        }      

        

        public void loadLocalidades(int id_dep)
        {
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
            Modelos.ClienteViewModel clienteModel = new Modelos.ClienteViewModel();

            Controladores.ClienteControllers clientecontroller = new Controladores.ClienteControllers();

            clienteModel.nombre = txtNombre.Text;

            clientecontroller.inserttest(clienteModel.nombre);


            


            //string Nombre = txtNombre.Text;
            //string Apellido = txtApellido.Text;
            //int TipoDoc = int.Parse(cmbTipoDoc.Text);
            //int NroDoc = int.Parse(txtNroDoc.Text);            
            //int Localidad = int.Parse(cmbLocalidad.Text);
            //int CodPostal = int.Parse(txtCodigoPostal.Text);
            //string Domicilio = txtDomicilio.Text;
            //string Telefono = txtTelefono.Text;
            //string Mail = txtMail.Text;
            //int Tipocliente = int.Parse(cmbTipoCliente.Text);

            //cliente.InsertarCliente(Nombre, Apellido,TipoDoc, NroDoc,Localidad,CodPostal,Domicilio,Telefono,Mail,Tipocliente);

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
    }
}
