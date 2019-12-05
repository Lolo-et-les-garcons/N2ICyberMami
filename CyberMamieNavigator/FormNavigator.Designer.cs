namespace CyberMamieNavigator
{
    partial class FormNavigator
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.browser = new Gecko.GeckoWebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // browser
            // 
            this.browser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.browser.Location = new System.Drawing.Point(0, 49);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(1050, 470);
            this.browser.TabIndex = 0;
            this.browser.UseHttpActivityObserver = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 49);
            this.panel1.TabIndex = 1;
            // 
            // FormNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 519);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.browser);
            this.Name = "FormNavigator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CyberMamieNavigator";
            this.ResumeLayout(false);

        }

        #endregion

        private Gecko.GeckoWebBrowser browser;
        private System.Windows.Forms.Panel panel1;
    }
}

