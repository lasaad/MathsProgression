namespace WebServiceConsumer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Compute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultOutput = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Compute
            // 
            this.Compute.Location = new System.Drawing.Point(34, 130);
            this.Compute.Name = "Compute";
            this.Compute.Size = new System.Drawing.Size(140, 23);
            this.Compute.TabIndex = 0;
            this.Compute.Text = "Fibonacci(10)";
            this.Compute.UseVisualStyleBackColor = true;
            this.Compute.Click += new System.EventHandler(this.Compute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Résultat : ";
            // 
            // ResultOutput
            // 
            this.ResultOutput.AutoSize = true;
            this.ResultOutput.Location = new System.Drawing.Point(120, 166);
            this.ResultOutput.Name = "ResultOutput";
            this.ResultOutput.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ResultOutput.Size = new System.Drawing.Size(0, 13);
            this.ResultOutput.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 100);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 202);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ResultOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Compute);
            this.Name = "MainForm";
            this.Text = "Fibonacci 10";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Compute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ResultOutput;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

