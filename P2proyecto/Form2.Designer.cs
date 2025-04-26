namespace P2proyecto
{
    partial class frmjugadores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnregistrar = new Button();
            txtnombre = new TextBox();
            txtlvl = new TextBox();
            btneliminar = new Button();
            btnmodificar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtid = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnregistrar
            // 
            btnregistrar.Location = new Point(57, 294);
            btnregistrar.Name = "btnregistrar";
            btnregistrar.Size = new Size(75, 23);
            btnregistrar.TabIndex = 0;
            btnregistrar.Text = "Registrar";
            btnregistrar.UseVisualStyleBackColor = true;
            btnregistrar.Click += btnregistrar_Click;
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(175, 129);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(100, 23);
            txtnombre.TabIndex = 1;
            // 
            // txtlvl
            // 
            txtlvl.Location = new Point(175, 205);
            txtlvl.Name = "txtlvl";
            txtlvl.Size = new Size(100, 23);
            txtlvl.TabIndex = 2;
            // 
            // btneliminar
            // 
            btneliminar.Location = new Point(185, 294);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(75, 23);
            btneliminar.TabIndex = 3;
            btneliminar.Text = "Eliminar";
            btneliminar.UseVisualStyleBackColor = true;
            btneliminar.Click += btneliminar_Click;
            // 
            // btnmodificar
            // 
            btnmodificar.Location = new Point(311, 294);
            btnmodificar.Name = "btnmodificar";
            btnmodificar.Size = new Size(75, 23);
            btnmodificar.TabIndex = 4;
            btnmodificar.Text = "Modificar";
            btnmodificar.UseVisualStyleBackColor = true;
            btnmodificar.Click += btnmodificar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 129);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 5;
            label1.Text = "Nombre";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 205);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 6;
            label2.Text = "Nivel";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 48);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 7;
            label3.Text = "ID";
            // 
            // txtid
            // 
            txtid.Location = new Point(175, 48);
            txtid.Name = "txtid";
            txtid.Size = new Size(100, 23);
            txtid.TabIndex = 8;
            txtid.TextChanged += txtid_TextChanged_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(281, 51);
            label4.Name = "label4";
            label4.Size = new Size(185, 15);
            label4.TabIndex = 9;
            label4.Text = "para registrar no es necesario el id\r\n";
            // 
            // frmjugadores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(txtid);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnmodificar);
            Controls.Add(btneliminar);
            Controls.Add(txtlvl);
            Controls.Add(txtnombre);
            Controls.Add(btnregistrar);
            Name = "frmjugadores";
            Text = "Form2";
            Load += frmjugadores_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnregistrar;
        private TextBox txtnombre;
        private TextBox txtlvl;
        private Button btneliminar;
        private Button btnmodificar;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtid;
        private Label label4;
    }
}