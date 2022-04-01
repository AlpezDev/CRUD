using MySql.Data.MySqlClient;
using capaEntidad;
using System.Data;

namespace capaDatos{
    public class CDCliente{
        string cadenaConexion = "Server=127.0.0.1;User=root;Password=;Port=3306;database=crud";

        public void PruebaConexion(){

            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            try{
                mySqlConnection.Open();
            }
            catch (Exception ex){

                MessageBox.Show("Error al conectarse: " + ex.Message);
                return;
            }

            mySqlConnection.Close();
            MessageBox.Show("Conectado con Exito!");
        }

        public void Nuevo(CEclientes cE){

            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string Query = "INSERT INTO `clientes`(`id`, `nombres`, `apellidos`, `foto`) VALUES ('"+cE.id+"','"+cE.Nombres+"','"+cE.Apellidos+"','"+MySql.Data.MySqlClient.MySqlServer.EscapeString(cE.Foto)+ "')";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);//MySql.Data.MySqlClient.MySqlServer.EscapeString(cE.Foto)
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Funcionario creado con Exito.");
        }
        public void Editar(CEclientes cE)
        {

            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            
            string Query = "UPDATE `clientes` SET `id`= '" + cE.id + "',`nombres`= '" + cE.Nombres + "',`apellidos`= '" + cE.Apellidos + "',`foto`= '" + cE.Foto + "' WHERE `id`="+cE.id+";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);//MySql.Data.MySqlClient.MySqlServer.EscapeString(cE.Foto)
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Funcionario actualizado con exito.");
        }

        public DataSet Mostrar(){

            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT `id`, `nombres`, `apellidos`, `foto` FROM `clientes` LIMIT 1000;";
            MySqlDataAdapter adaptador;
            DataSet dataSet = new DataSet();

            adaptador = new MySqlDataAdapter(Query, mySqlConnection);
            adaptador.Fill(dataSet, "tabla");

            return dataSet;
        }
    }
}