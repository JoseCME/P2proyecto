using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinecraftManager.Models;
using MinecraftManager.Services;
using MinecraftManager.Utils;

namespace P2proyecto
{
    public partial class frmjugadores : Form
    {
        JugadorService _jugadorService = new JugadorService(new DatabaseManager());
        public frmjugadores()
        {
            InitializeComponent();
            txtid.TextChanged += txtid_TextChanged;
        }
        private void txtid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Limpiar los labels por defecto
                txtnombre.Text = string.Empty;
                txtlvl.Text = string.Empty;

                // Validar si el texto es un Id válido
                if (!int.TryParse(txtid.Text, out int id) || id <= 0)
                {
                    return; // Si no es un número válido o es menor o igual a 0, no hacemos nada
                }

                // Buscar el jugador por Id
                var jugador = _jugadorService.ObtenerPorId(id);
                if (jugador != null)
                {
                    // Actualizar los labels con los datos del jugador
                    txtnombre.Text = jugador.Nombre;
                    txtlvl.Text = jugador.Nivel.ToString();
                }
                else
                {
                    // Si no se encuentra el jugador, limpiar los labels (o mostrar un mensaje opcional)
                    txtnombre.Text = string.Empty;
                    txtlvl.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el jugador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnombre.Text = string.Empty;
                txtlvl.Text = string.Empty;
            }
        }
        private void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtnombre.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtlvl.Text, out int nivel) || nivel < 0)
                {
                    MessageBox.Show("Por favor, ingrese un nivel válido (número positivo).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                var jugador = new Jugador
                {
                    Nombre = txtnombre.Text,
                    Nivel = nivel
                };


                _jugadorService.Crear(jugador);


                MessageBox.Show($"¡Jugador {jugador.Nombre} registrado con ID: {jugador.Id}!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txtnombre.Text = string.Empty;
                txtlvl.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el jugador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar el campo Id  
                if (!int.TryParse(txtid.Text, out int id) || id <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un ID válido (número positivo).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Llamar al servicio para eliminar  
                _jugadorService.Eliminar(id);

                // Mostrar el resultado al usuario  
                MessageBox.Show($"Jugador con ID {id} eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtid.Text = string.Empty; // Limpiar el campo  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtid.Text))
                {
                    MessageBox.Show("Por favor, ingrese una ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtlvl.Text, out int nivel) || nivel < 0)
                {
                    MessageBox.Show("Por favor, ingrese un nivel válido (número positivo).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtnombre.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var jugador = new Jugador
                {
                    Id = int.Parse(txtid.Text),
                    Nombre = txtnombre.Text,
                    Nivel = int.Parse(txtlvl.Text)

                };


                _jugadorService.Actualizar(jugador);


                MessageBox.Show($"¡Jugador {jugador.Nombre} modificado con ID: {jugador.Id}!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txtnombre.Text = string.Empty;
                txtlvl.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el jugador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void frmjugadores_Load(object sender, EventArgs e)
        {

        }
    }
}
