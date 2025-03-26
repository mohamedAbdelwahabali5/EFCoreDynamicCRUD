namespace EFProject
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
            tables = new ComboBox();
            crudOP = new ComboBox();
            go = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tables
            // 
            tables.BackColor = SystemColors.InactiveCaption;
            tables.FormattingEnabled = true;
            tables.Location = new Point(139, 88);
            tables.Name = "tables";
            tables.Size = new Size(121, 23);
            tables.TabIndex = 0;
            // 
            // crudOP
            // 
            crudOP.BackColor = SystemColors.MenuHighlight;
            crudOP.FormattingEnabled = true;
            crudOP.Location = new Point(266, 88);
            crudOP.Name = "crudOP";
            crudOP.Size = new Size(121, 23);
            crudOP.TabIndex = 1;
            // 
            // go
            // 
            go.BackColor = Color.Teal;
            go.ForeColor = SystemColors.ControlLightLight;
            go.Location = new Point(197, 161);
            go.Name = "go";
            go.Size = new Size(109, 46);
            go.TabIndex = 2;
            go.Text = "GO";
            go.UseVisualStyleBackColor = false;
            go.Click += go_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(tables);
            panel1.Controls.Add(go);
            panel1.Controls.Add(crudOP);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(535, 274);
            panel1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 274);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox tables;
        private ComboBox crudOP;
        private Button go;
        private Panel panel1;
    }
}
