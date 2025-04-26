namespace P2proyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnbloques_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 bloques = new Form4();
            bloques.Show();
        }

        private void btnjugador_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmjugadores jugadores = new frmjugadores();
            jugadores.Show();
        }

        private void btninventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 inventario = new Form3();
            inventario.Show();
        }
    }
}
