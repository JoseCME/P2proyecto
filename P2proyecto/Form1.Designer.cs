namespace P2proyecto
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnjugador = new Button();
            btnbloques = new Button();
            btninventario = new Button();
            SuspendLayout();
            // 
            // btnjugador
            // 
            btnjugador.Location = new Point(76, 257);
            btnjugador.Name = "btnjugador";
            btnjugador.Size = new Size(121, 59);
            btnjugador.TabIndex = 0;
            btnjugador.Text = "Jugadores";
            btnjugador.UseVisualStyleBackColor = true;
            btnjugador.Click += btnjugador_Click;
            // 
            // btnbloques
            // 
            btnbloques.Location = new Point(324, 257);
            btnbloques.Name = "btnbloques";
            btnbloques.Size = new Size(121, 59);
            btnbloques.TabIndex = 1;
            btnbloques.Text = "Bloques";
            btnbloques.UseVisualStyleBackColor = true;
            btnbloques.Click += btnbloques_Click;
            // 
            // btninventario
            // 
            btninventario.Location = new Point(554, 257);
            btninventario.Name = "btninventario";
            btninventario.Size = new Size(121, 59);
            btninventario.TabIndex = 2;
            btninventario.Text = "Inventario";
            btninventario.UseVisualStyleBackColor = true;
            btninventario.Click += btninventario_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btninventario);
            Controls.Add(btnbloques);
            Controls.Add(btnjugador);
            Name = "Form1";
            Text = "Sistema de gestion de Minecraft";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnjugador;
        private Button btnbloques;
        private Button btninventario;
    }
}
