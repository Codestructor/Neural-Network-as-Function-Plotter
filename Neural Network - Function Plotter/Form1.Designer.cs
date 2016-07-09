namespace Neural_Network___Function_Plotter
{
    partial class Form1
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
            this.pnlPlot = new System.Windows.Forms.Panel();
            this.lblX0 = new System.Windows.Forms.Label();
            this.lblXF = new System.Windows.Forms.Label();
            this.btnF1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.pnlPlot.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPlot
            // 
            this.pnlPlot.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPlot.Controls.Add(this.lblX0);
            this.pnlPlot.Controls.Add(this.lblXF);
            this.pnlPlot.Location = new System.Drawing.Point(155, 12);
            this.pnlPlot.Name = "pnlPlot";
            this.pnlPlot.Size = new System.Drawing.Size(834, 521);
            this.pnlPlot.TabIndex = 0;
            this.pnlPlot.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlPlot_MouseClick);
            // 
            // lblX0
            // 
            this.lblX0.AutoSize = true;
            this.lblX0.Location = new System.Drawing.Point(3, 0);
            this.lblX0.Name = "lblX0";
            this.lblX0.Size = new System.Drawing.Size(35, 13);
            this.lblX0.TabIndex = 2;
            this.lblX0.Text = "label1";
            // 
            // lblXF
            // 
            this.lblXF.AutoSize = true;
            this.lblXF.Location = new System.Drawing.Point(3, 24);
            this.lblXF.Name = "lblXF";
            this.lblXF.Size = new System.Drawing.Size(35, 13);
            this.lblXF.TabIndex = 3;
            this.lblXF.Text = "label1";
            // 
            // btnF1
            // 
            this.btnF1.Location = new System.Drawing.Point(12, 426);
            this.btnF1.Name = "btnF1";
            this.btnF1.Size = new System.Drawing.Size(137, 23);
            this.btnF1.TabIndex = 1;
            this.btnF1.Text = "Draw Function 1";
            this.btnF1.UseVisualStyleBackColor = true;
            this.btnF1.Click += new System.EventHandler(this.btnF1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Import Network Structure:";
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Location = new System.Drawing.Point(12, 25);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.ReadOnly = true;
            this.txtBoxPath.Size = new System.Drawing.Size(137, 20);
            this.txtBoxPath.TabIndex = 4;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(12, 51);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(137, 23);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(12, 80);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(137, 23);
            this.btnTrain.TabIndex = 6;
            this.btnTrain.Text = "Train x5";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 545);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtBoxPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlPlot);
            this.Controls.Add(this.btnF1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.pnlPlot.ResumeLayout(false);
            this.pnlPlot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPlot;
        private System.Windows.Forms.Button btnF1;
        private System.Windows.Forms.Label lblX0;
        private System.Windows.Forms.Label lblXF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxPath;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnTrain;
    }
}

