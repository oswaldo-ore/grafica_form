
namespace grafica
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControl1 = new OpenTK.GLControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuObjeto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPartes = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate = new System.Windows.Forms.RadioButton();
            this.traslate = new System.Windows.Forms.RadioButton();
            this.scale = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(12, 129);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1184, 555);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glControl1_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuObjeto,
            this.menuPartes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1208, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuObjeto
            // 
            this.menuObjeto.Name = "menuObjeto";
            this.menuObjeto.Size = new System.Drawing.Size(60, 20);
            this.menuObjeto.Text = "Objetos";
            // 
            // menuPartes
            // 
            this.menuPartes.Name = "menuPartes";
            this.menuPartes.Size = new System.Drawing.Size(51, 20);
            this.menuPartes.Text = "Partes";
            // 
            // rotate
            // 
            this.rotate.AutoSize = true;
            this.rotate.Location = new System.Drawing.Point(31, 27);
            this.rotate.Name = "rotate";
            this.rotate.Size = new System.Drawing.Size(68, 17);
            this.rotate.TabIndex = 6;
            this.rotate.TabStop = true;
            this.rotate.Text = "Rotacion";
            this.rotate.UseVisualStyleBackColor = true;
            // 
            // traslate
            // 
            this.traslate.AutoSize = true;
            this.traslate.Location = new System.Drawing.Point(135, 27);
            this.traslate.Name = "traslate";
            this.traslate.Size = new System.Drawing.Size(74, 17);
            this.traslate.TabIndex = 7;
            this.traslate.TabStop = true;
            this.traslate.Text = "Traslacion";
            this.traslate.UseVisualStyleBackColor = true;
            // 
            // scale
            // 
            this.scale.AutoSize = true;
            this.scale.Location = new System.Drawing.Point(242, 27);
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(59, 17);
            this.scale.TabIndex = 8;
            this.scale.TabStop = true;
            this.scale.Text = "escalar";
            this.scale.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(116, 49);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "para Trasladar o Rotar utilizar los botones A,W,D,S,Z,X";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(242, 50);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 34);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "para Escalar utiliza los botones E,Q";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 696);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.scale);
            this.Controls.Add(this.traslate);
            this.Controls.Add(this.rotate);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuObjeto;
        private System.Windows.Forms.ToolStripMenuItem menuPartes;
        private System.Windows.Forms.RadioButton rotate;
        private System.Windows.Forms.RadioButton traslate;
        private System.Windows.Forms.RadioButton scale;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

