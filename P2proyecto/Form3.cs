using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinecraftManager.Services;
using MinecraftManager.Utils;

namespace P2proyecto
{
    public partial class Form3 : Form
    {
        private InventarioService inventarioService; // Declare the field  

        public Form3()
        {
            InitializeComponent();
            inventarioService = new InventarioService(new DatabaseManager(), new JugadorService(new DatabaseManager()), new BloqueService(new DatabaseManager()));
            CargarInventario();
        }

        private void CargarInventario()
        {
            try
            {
                // Obtener los datos del inventario  
                var inventario = inventarioService.ObtenerTodos();

                // Asignar los datos al DataGridView  
                dataGridView1.DataSource = inventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo CSV (*.csv)|*.csv",
                Title = "Guardar como CSV",
                FileName = "Inventario.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sb = new StringBuilder();

                    // Escribir cabeceras
                    var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
                    sb.AppendLine(string.Join(",", headers.Select(c => c.HeaderText)));

                    // Escribir filas
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value?.ToString()?.Replace(",", " ") ?? "");
                        sb.AppendLine(string.Join(",", cells));
                    }

                    System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                    MessageBox.Show("Exportación completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
