namespace vision
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainerImages = new System.Windows.Forms.SplitContainer();
            this.imageBoxSource = new Emgu.CV.UI.ImageBox();
            this.imageBoxProcessed = new Emgu.CV.UI.ImageBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.buttonSwitch = new System.Windows.Forms.Button();
            this.splitContainerControls = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerImages)).BeginInit();
            this.splitContainerImages.Panel1.SuspendLayout();
            this.splitContainerImages.Panel2.SuspendLayout();
            this.splitContainerImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxProcessed)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControls)).BeginInit();
            this.splitContainerControls.Panel1.SuspendLayout();
            this.splitContainerControls.Panel2.SuspendLayout();
            this.splitContainerControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainerImages);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 536);
            this.panel1.TabIndex = 0;
            // 
            // splitContainerImages
            // 
            this.splitContainerImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerImages.Location = new System.Drawing.Point(0, 0);
            this.splitContainerImages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainerImages.Name = "splitContainerImages";
            // 
            // splitContainerImages.Panel1
            // 
            this.splitContainerImages.Panel1.Controls.Add(this.imageBoxSource);
            // 
            // splitContainerImages.Panel2
            // 
            this.splitContainerImages.Panel2.Controls.Add(this.imageBoxProcessed);
            this.splitContainerImages.Size = new System.Drawing.Size(1179, 536);
            this.splitContainerImages.SplitterDistance = 291;
            this.splitContainerImages.SplitterWidth = 2;
            this.splitContainerImages.TabIndex = 0;
            // 
            // imageBoxSource
            // 
            this.imageBoxSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBoxSource.Location = new System.Drawing.Point(0, 0);
            this.imageBoxSource.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imageBoxSource.Name = "imageBoxSource";
            this.imageBoxSource.Size = new System.Drawing.Size(291, 536);
            this.imageBoxSource.TabIndex = 2;
            this.imageBoxSource.TabStop = false;
            // 
            // imageBoxProcessed
            // 
            this.imageBoxProcessed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBoxProcessed.Location = new System.Drawing.Point(0, 0);
            this.imageBoxProcessed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imageBoxProcessed.Name = "imageBoxProcessed";
            this.imageBoxProcessed.Size = new System.Drawing.Size(886, 536);
            this.imageBoxProcessed.TabIndex = 2;
            this.imageBoxProcessed.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelDescription);
            this.panel2.Controls.Add(this.buttonSwitch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1179, 52);
            this.panel2.TabIndex = 1;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(126, 7);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(35, 13);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "label1";
            // 
            // buttonSwitch
            // 
            this.buttonSwitch.Location = new System.Drawing.Point(6, 7);
            this.buttonSwitch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSwitch.Name = "buttonSwitch";
            this.buttonSwitch.Size = new System.Drawing.Size(102, 32);
            this.buttonSwitch.TabIndex = 0;
            this.buttonSwitch.Text = "Switch";
            this.buttonSwitch.UseVisualStyleBackColor = true;
            this.buttonSwitch.Click += new System.EventHandler(this.buttonSwitch_Click);
            // 
            // splitContainerControls
            // 
            this.splitContainerControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControls.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerControls.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControls.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainerControls.Name = "splitContainerControls";
            this.splitContainerControls.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerControls.Panel1
            // 
            this.splitContainerControls.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainerControls.Panel2
            // 
            this.splitContainerControls.Panel2.Controls.Add(this.panel1);
            this.splitContainerControls.Size = new System.Drawing.Size(1179, 652);
            this.splitContainerControls.SplitterDistance = 114;
            this.splitContainerControls.SplitterWidth = 2;
            this.splitContainerControls.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 652);
            this.Controls.Add(this.splitContainerControls);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "Emgu - exemples simples";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainerImages.Panel1.ResumeLayout(false);
            this.splitContainerImages.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerImages)).EndInit();
            this.splitContainerImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxProcessed)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainerControls.Panel1.ResumeLayout(false);
            this.splitContainerControls.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControls)).EndInit();
            this.splitContainerControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainerImages;
        private Emgu.CV.UI.ImageBox imageBoxSource;
        private Emgu.CV.UI.ImageBox imageBoxProcessed;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainerControls;
        private System.Windows.Forms.Button buttonSwitch;
        private System.Windows.Forms.Label labelDescription;
    }
}

