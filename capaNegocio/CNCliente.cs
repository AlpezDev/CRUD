using capaEntidad;
using capaDatos;
using System.Data;

namespace capaNegocio
{
    public class CNCliente{

        CDCliente cDCliente = new CDCliente();
        public bool ValidarDatos(CEclientes cliente){

            bool resultado = true;

            if (cliente.Nombres == string.Empty){
                resultado = false;
                MessageBox.Show("Ingrese al menos un nombre por favor.");
            }
            if (cliente.Apellidos == string.Empty){
                resultado = false;
                MessageBox.Show("Ingrese al menos un apellido por favor.");
            }
            if (cliente.Foto == null){
                resultado = false;
                MessageBox.Show("La foto es obligatoria.");
            }

            return resultado;
        }

        public void PruebaMySql(){

            cDCliente.PruebaConexion();
        }

        public void NuevoCliente(CEclientes cE){

            cDCliente.Nuevo(cE);
        }

        public DataSet ObtenerDatos(){

            return cDCliente.Mostrar();

        }
    }
}