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
    public partial class Form4 : Form
    {
        private readonly BloqueService _bloqueService;
        public Form4()
        {
            InitializeComponent();

            // Create an instance of DatabaseManager and pass it to BloqueService  
            var dbManager = new DatabaseManager();
            _bloqueService = new BloqueService(dbManager);
        }
        private void MostrarImagenBloque(Bloque bloque)
        {
            try
            {
                string nombreImagen = $"{bloque.Nombre.ToLower()}.png"; // Ej: "stone.png"
                string rutaImagen = Path.Combine(Application.StartupPath, "Resources", nombreImagen);

                if (File.Exists(rutaImagen))
                {
                    picBloque.Image = Image.FromFile(rutaImagen);
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var bloque = dataGridView1.SelectedRows[0].DataBoundItem as Bloque;
                if (bloque != null)
                {
                    MostrarImagenBloque(bloque);
                }
            }
        }
        private void CargarImagen(string rareza)
        {
            try
            {
                string nombreArchivo = $"{rareza.ToLower().Replace(" ", "_")}.png";
                string ruta = Path.Combine(Application.StartupPath, "Resources", nombreArchivo);

                if (File.Exists(ruta))
                {
                    picBloque.Image = Image.FromFile(ruta);
                }
                else
                {
                    picBloque.Image = null; // O podés cargar una imagen "not found"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarBloques();
            CargarImagen(comboBox1.SelectedItem?.ToString() ?? "Todas");
            CargarImagen(comboBox1.SelectedItem?.ToString() ?? "Raro");

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            ConfigurarComboBoxRareza();

            // Seleccionamos "Todas" *después* de llenar el combo para evitar errores
            comboBox1.SelectedIndex = 0;

            // Cargar bloques e imagen
            CargarBloques();
            CargarImagen("Todas"); // NUEVO: mostrar imagen por defecto
        }
        private void ConfigurarDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "Id"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "Nombre"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Tipo",
                HeaderText = "Tipo",
                Name = "Tipo"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Rareza",
                HeaderText = "Rareza",
                Name = "Rareza"
            });

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ConfigurarComboBoxRareza()
        {
            // Usamos ObtenerTodosBloques para extraer las rarezas únicas
            var todosBloques = _bloqueService.ObtenerTodos();
            var rarezas = todosBloques
                .Select(b => b.Rareza)
                .Distinct()
                .OrderBy(r => r)
                .ToArray();

            comboBox1.Items.Add("Todas");
            comboBox1.Items.AddRange(rarezas);
            comboBox1.SelectedIndex = 0;
        }

        private void CargarBloques()
        {
            string? rareza = comboBox1.SelectedItem?.ToString() == "Todas" ? null : comboBox1.SelectedItem?.ToString();
            List<Bloque> bloques = rareza == null ? _bloqueService.ObtenerTodos() : _bloqueService.BuscarPorRareza(rareza);

            dataGridView1.DataSource = bloques;
            label1.Text = $"Total de bloques encontrados: {bloques.Count}";

            if (bloques.Count == 0)
            {
                MostrarImagenBloque(bloques[0]);
                
            }
            else
            {
                {
                    picBloque.Image = null;
                   
                }
            }
        }

        private void picBloque_Click(object sender, EventArgs e)
        {

        }
    }
}
