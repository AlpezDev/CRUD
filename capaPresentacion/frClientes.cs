using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class Form1 : Form
    {
        CNCliente cNCliente = new CNCliente();
        public Form1(){
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){
            CargarDatos();
        }

        public void CargarDatos(){

            gridDatos.DataSource = cNCliente.ObtenerDatos().Tables["tabla"];
        }

        private void btnNuevo_Click(object sender, EventArgs e){
            txtCedula.Value = 0;
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            picFoto.Image = null;

        }

        private void lnkFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e){
            
            ofdFoto.FileName = string.Empty;

            if (ofdFoto.ShowDialog() == DialogResult.OK){
                picFoto.Load(ofdFoto.FileName);
            }

            ofdFoto.FileName = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e){

            bool resultado;
            CEclientes ceClientes = new CEclientes();
            ceClientes.id = (int) txtCedula.Value;
            ceClientes.Nombres = txtNombres.Text;
            ceClientes.Apellidos = txtApellidos.Text;
            ceClientes.Foto = picFoto.ImageLocation;

            resultado = cNCliente.ValidarDatos(ceClientes);

            if (resultado == false){
                return;
            }

            cNCliente.NuevoCliente(ceClientes);
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e){

            cNCliente.PruebaMySql();
        }

        private void gridDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e){

            txtCedula.Value = (int) gridDatos.CurrentRow.Cells["id"].Value;
            txtNombres.Text = gridDatos.CurrentRow.Cells["nombres"].ToString();
            txtApellidos.Text = gridDatos.CurrentRow.Cells["apellidos"].ToString();
            picFoto.Load(gridDatos.CurrentRow.Cells["foto"].ToString());

        }
    }
}