namespace Presentacion
{
    partial class ResumenPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResumenPedido));
            lbl_SeleccioneTopping = new Label();
            lblTotal = new Label();
            lblDetalles = new Label();
            lblDineroIngresado = new Label();
            lblCambio = new Label();
            btnConfirmar = new Button();
            txtDineroIngresado = new TextBox();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            button1 = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button2 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lbl_SeleccioneTopping
            // 
            lbl_SeleccioneTopping.AutoSize = true;
            lbl_SeleccioneTopping.Font = new Font("Consolas", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_SeleccioneTopping.ForeColor = Color.LightSlateGray;
            lbl_SeleccioneTopping.Location = new Point(116, -74);
            lbl_SeleccioneTopping.Name = "lbl_SeleccioneTopping";
            lbl_SeleccioneTopping.Size = new Size(303, 36);
            lbl_SeleccioneTopping.TabIndex = 25;
            lbl_SeleccioneTopping.Text = "Resumen del Pedido";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold);
            lblTotal.ForeColor = SystemColors.ActiveCaptionText;
            lblTotal.Location = new Point(106, 21);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(86, 35);
            lblTotal.TabIndex = 26;
            lblTotal.Text = "Total:";
            // 
            // lblDetalles
            // 
            lblDetalles.AutoSize = true;
            lblDetalles.BackColor = Color.Transparent;
            lblDetalles.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold);
            lblDetalles.ForeColor = SystemColors.ActiveCaptionText;
            lblDetalles.Location = new Point(42, 68);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(248, 35);
            lblDetalles.TabIndex = 27;
            lblDetalles.Text = "Detalles de la dona:";
            // 
            // lblDineroIngresado
            // 
            lblDineroIngresado.AutoSize = true;
            lblDineroIngresado.BackColor = Color.Transparent;
            lblDineroIngresado.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold);
            lblDineroIngresado.ForeColor = SystemColors.ActiveCaptionText;
            lblDineroIngresado.Location = new Point(42, 175);
            lblDineroIngresado.Name = "lblDineroIngresado";
            lblDineroIngresado.Size = new Size(226, 35);
            lblDineroIngresado.TabIndex = 28;
            lblDineroIngresado.Text = "Ingresa el dinero:";
            // 
            // lblCambio
            // 
            lblCambio.AutoSize = true;
            lblCambio.BackColor = Color.Transparent;
            lblCambio.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold);
            lblCambio.ForeColor = SystemColors.ActiveCaptionText;
            lblCambio.Location = new Point(42, 276);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(106, 35);
            lblCambio.TabIndex = 29;
            lblCambio.Text = "Cambio:";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmar.ForeColor = SystemColors.ControlLightLight;
            btnConfirmar.Image = (Image)resources.GetObject("btnConfirmar.Image");
            btnConfirmar.Location = new Point(198, 230);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(168, 44);
            btnConfirmar.TabIndex = 30;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // txtDineroIngresado
            // 
            txtDineroIngresado.Location = new Point(326, 179);
            txtDineroIngresado.Name = "txtDineroIngresado";
            txtDineroIngresado.Size = new Size(206, 31);
            txtDineroIngresado.TabIndex = 31;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(txtDineroIngresado);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(lblCambio);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnConfirmar);
            panel1.Controls.Add(lblDineroIngresado);
            panel1.Controls.Add(lblDetalles);
            panel1.Controls.Add(lblTotal);
            panel1.Location = new Point(117, 141);
            panel1.Name = "panel1";
            panel1.Size = new Size(575, 340);
            panel1.TabIndex = 32;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(572, -58);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(49, 33);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 45;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(627, -58);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(39, 33);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 44;
            pictureBox4.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.LightCoral;
            button1.Font = new Font("Comic Sans MS", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(-117, -47);
            button1.Name = "button1";
            button1.Size = new Size(122, 43);
            button1.TabIndex = 43;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(191, 64);
            label1.Name = "label1";
            label1.Size = new Size(458, 55);
            label1.TabIndex = 42;
            label1.Text = "Resumen de tu compra";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(701, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(756, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(39, 33);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 44;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightCoral;
            button2.Font = new Font("Comic Sans MS", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(12, 5);
            button2.Name = "button2";
            button2.Size = new Size(122, 43);
            button2.TabIndex = 43;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // ResumenPedido
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(797, 515);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(button2);
            Controls.Add(panel1);
            Controls.Add(lbl_SeleccioneTopping);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ResumenPedido";
            Text = "ResumenPedido";
            Load += ResumenPedido_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbl_SeleccioneTopping;
        private Label lblTotal;
        private Label lblDetalles;
        private Label lblDineroIngresado; // Cambiado el nombre para evitar confusión
        private Label lblCambio;
        private Button btnConfirmar;
        private TextBox txtDineroIngresado; // Cambiado a TextBox
        private Panel panel1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Button button1;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button2;
    }
}
