namespace ControllerToPokeOne
{
    partial class Form_XboxToPokeOne
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_cntconn = new System.Windows.Forms.Label();
            this.btn_startwork = new System.Windows.Forms.Button();
            this.clk_updatecontroller = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_cntconn
            // 
            this.lbl_cntconn.AutoSize = true;
            this.lbl_cntconn.Location = new System.Drawing.Point(12, 9);
            this.lbl_cntconn.Name = "lbl_cntconn";
            this.lbl_cntconn.Size = new System.Drawing.Size(132, 13);
            this.lbl_cntconn.TabIndex = 0;
            this.lbl_cntconn.Text = "Controller Angeschlossen?";
            // 
            // btn_startwork
            // 
            this.btn_startwork.Location = new System.Drawing.Point(121, 109);
            this.btn_startwork.Name = "btn_startwork";
            this.btn_startwork.Size = new System.Drawing.Size(132, 23);
            this.btn_startwork.TabIndex = 1;
            this.btn_startwork.Text = "Start";
            this.btn_startwork.UseVisualStyleBackColor = true;
            this.btn_startwork.Click += new System.EventHandler(this.btn_startwork_Click);
            // 
            // clk_updatecontroller
            // 
            this.clk_updatecontroller.Interval = 10;
            this.clk_updatecontroller.Tick += new System.EventHandler(this.clk_updatecontroller_Tick);
            // 
            // Form_XboxToPokeOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 144);
            this.Controls.Add(this.btn_startwork);
            this.Controls.Add(this.lbl_cntconn);
            this.Name = "Form_XboxToPokeOne";
            this.Text = "Xbox 360 to PokeOne";
            this.Load += new System.EventHandler(this.Form_XboxToPokeOne_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_cntconn;
        private System.Windows.Forms.Button btn_startwork;
        private System.Windows.Forms.Timer clk_updatecontroller;
    }
}

