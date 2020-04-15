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
            
        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = cliente.GetCliente();
            cmbProvincia.DataSource = provincia.GetProvincias();
            cmbProvincia.DisplayMember = "nombre";
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            //lblApellido Cliente = new lblApellido();

            //Cliente.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            int TipoDoc = int.Parse(cmbTipoDoc.Text);
            int NroDoc = int.Parse(txtNroDoc.Text);
            int Provincia = ((Modelos.ProvinciaViewModel)cmbProvincia.SelectedValue).id;
            int Localidad = int.Parse(cmbLocalidad.Text);
            int CodPostal = int.Parse(txtCodigoPostal.Text);
            string Domicilio = txtDomicilio.Text;
            string Telefono = txtTelefono.Text;
            string Mail = txtMail.Text;
            int Tipocliente = int.Parse(cmbTipoCliente.Text);

            cliente.InsertarCliente(Nombre, Apellido,TipoDoc, NroDoc, Provincia,Localidad,CodPostal,Domicilio,Telefono,Mail,Tipocliente);

        }
        
    }
}
