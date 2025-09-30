using System;
using System.Windows.Forms;
using CapaVista_Seguridad;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        Sentencias objetoCN = new Sentencias();
        Sentencias objetoRegistros = new Sentencias();
        private string idEmpleado = null;
        private bool Editar = false;
        private bool MostrandoBitacora = false; // Cambié esta variable

        // NUEVAS VARIABLES PARA USUARIO
        private string tipoUsuario;
        private string usuarioActual;



        // MÉTODO PARA MOSTRAR EMPLEADOS
        private void MostrarEmpleados()
        {
            try
            {
                dataGridView1.DataSource = objetoCN.MostrarEmpleados();
                MostrandoBitacora = false;
                btnVerRegistros.Text = "Ver Bitácora"; // Cambié el texto
                this.Text = $"Sistema - Empleados - Usuario: {usuarioActual}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        // MÉTODO PARA MOSTRAR BITÁCORA (NUEVO)
        private void MostrarBitacora()
        {
            try
            {
                dataGridView1.DataSource = objetoCN.MostrarBitacora();
                MostrandoBitacora = true;
                btnVerRegistros.Text = "Ver Empleados"; // Cambié el texto
                this.Text = $"Sistema - Bitácora - Usuario: {usuarioActual}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar bitácora: " + ex.Message);
            }
        }

 

   
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //INSERTAR
            if (Editar == false)
            {
                try
                {
                    Sentencia.InsertarEmpleado(txtNombre.Text, txtDesc.Text, txtMarca.Text, usuarioActual);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarEmpleados();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarEmpleado(idEmpleado, txtNombre.Text, txtDesc.Text, txtMarca.Text, usuarioActual);
                    MessageBox.Show("Se editó correctamente");
                    MostrarEmpleados();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por: " + ex);
                }
            }
        }

        // BOTÓN EDITAR - SOLO FUNCIONA EN MODO EMPLEADOS
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (MostrandoBitacora)
            {
                MessageBox.Show("Cambie a la vista de Empleados para realizar esta acción");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["codigo_facultad"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["nombre_facultad"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["estatus_facultad"].Value.ToString();
               
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        // BOTÓN ELIMINAR - SOLO FUNCIONA EN MODO EMPLEADOS
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MostrandoBitacora)
            {
                MessageBox.Show("Cambie a la vista de Empleados para realizar esta acción");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                idEmpleado = dataGridView1.CurrentRow.Cells["codigo_faculltad"].Value.ToString();
                objetoCN.EliminarEmpleado(idEmpleado, usuarioActual);
                MessageBox.Show("Eliminado correctamente");
                MostrarEmpleados();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void limpiarForm()
        {
            txtDesc.Clear();
            txtMarca.Clear();
            txtNombre.Clear();
        }


    }
}




