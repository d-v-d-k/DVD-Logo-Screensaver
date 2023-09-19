namespace ScreenSaver
{
    partial class Configure
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbSpeed = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.tbStep = new System.Windows.Forms.TrackBar();
            this.gbStep = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStep)).BeginInit();
            this.gbStep.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 180);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(153, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbSpeed
            // 
            this.gbSpeed.Controls.Add(this.label4);
            this.gbSpeed.Controls.Add(this.tbSpeed);
            this.gbSpeed.Controls.Add(this.label3);
            this.gbSpeed.Location = new System.Drawing.Point(12, 12);
            this.gbSpeed.Name = "gbSpeed";
            this.gbSpeed.Size = new System.Drawing.Size(216, 79);
            this.gbSpeed.TabIndex = 2;
            this.gbSpeed.TabStop = false;
            this.gbSpeed.Text = "Speed (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "100";
            // 
            // tbSpeed
            // 
            this.tbSpeed.LargeChange = 25;
            this.tbSpeed.Location = new System.Drawing.Point(8, 32);
            this.tbSpeed.Maximum = 100;
            this.tbSpeed.Minimum = 10;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(200, 45);
            this.tbSpeed.SmallChange = 25;
            this.tbSpeed.TabIndex = 0;
            this.tbSpeed.TickFrequency = 25;
            this.tbSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbSpeed.Value = 25;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "10";
            // 
            // tbStep
            // 
            this.tbStep.LargeChange = 2;
            this.tbStep.Location = new System.Drawing.Point(8, 32);
            this.tbStep.Maximum = 8;
            this.tbStep.Minimum = 1;
            this.tbStep.Name = "tbStep";
            this.tbStep.Size = new System.Drawing.Size(200, 45);
            this.tbStep.TabIndex = 0;
            this.tbStep.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbStep.Value = 4;
            this.tbStep.Scroll += new System.EventHandler(this.tbStep_Scroll);
            // 
            // gbStep
            // 
            this.gbStep.Controls.Add(this.tbStep);
            this.gbStep.Controls.Add(this.label1);
            this.gbStep.Controls.Add(this.label2);
            this.gbStep.Location = new System.Drawing.Point(12, 97);
            this.gbStep.Name = "gbStep";
            this.gbStep.Size = new System.Drawing.Size(216, 79);
            this.gbStep.TabIndex = 3;
            this.gbStep.TabStop = false;
            this.gbStep.Text = "Step (pixels)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "8";
            // 
            // Configure
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(240, 215);
            this.Controls.Add(this.gbStep);
            this.Controls.Add(this.gbSpeed);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configure";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DVD Logo Screen Saver Settings";
            this.Load += new System.EventHandler(this.Configure_Load);
            this.gbSpeed.ResumeLayout(false);
            this.gbSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStep)).EndInit();
            this.gbStep.ResumeLayout(false);
            this.gbStep.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbSpeed;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.TrackBar tbStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbStep;
    }
}