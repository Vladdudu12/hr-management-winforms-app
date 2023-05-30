
namespace hr_management_app.UserControls
{
    partial class Grafic
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonImprimare = new System.Windows.Forms.Button();
            this.buttonGrafic = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonImprimare
            // 
            this.buttonImprimare.Location = new System.Drawing.Point(263, 244);
            this.buttonImprimare.Name = "buttonImprimare";
            this.buttonImprimare.Size = new System.Drawing.Size(131, 45);
            this.buttonImprimare.TabIndex = 5;
            this.buttonImprimare.Text = "Imprimare";
            this.buttonImprimare.UseVisualStyleBackColor = true;
            this.buttonImprimare.Click += new System.EventHandler(this.buttonImprimare_Click);
            // 
            // buttonGrafic
            // 
            this.buttonGrafic.Location = new System.Drawing.Point(22, 244);
            this.buttonGrafic.Name = "buttonGrafic";
            this.buttonGrafic.Size = new System.Drawing.Size(131, 45);
            this.buttonGrafic.TabIndex = 4;
            this.buttonGrafic.Text = "Afisare Grafic";
            this.buttonGrafic.UseVisualStyleBackColor = true;
            this.buttonGrafic.Click += new System.EventHandler(this.buttonGrafic_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(22, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 212);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Grafic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonImprimare);
            this.Controls.Add(this.buttonGrafic);
            this.Controls.Add(this.panel1);
            this.Name = "Grafic";
            this.Size = new System.Drawing.Size(414, 302);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonImprimare;
        private System.Windows.Forms.Button buttonGrafic;
        private System.Windows.Forms.Panel panel1;
    }
}
