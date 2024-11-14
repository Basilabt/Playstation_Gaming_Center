namespace Playstation_Gaming_Center.Screens
{
    partial class frmReservationInfo
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
            this.txtboxPlayerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxNumberOfHours = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtboxPlayerName
            // 
            this.txtboxPlayerName.BackColor = System.Drawing.Color.Black;
            this.txtboxPlayerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtboxPlayerName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtboxPlayerName.Location = new System.Drawing.Point(127, 26);
            this.txtboxPlayerName.Name = "txtboxPlayerName";
            this.txtboxPlayerName.Size = new System.Drawing.Size(197, 20);
            this.txtboxPlayerName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player Name:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Playstation_Gaming_Center.Properties.Resources.ps4Controller;
            this.pictureBox1.Location = new System.Drawing.Point(-4, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hours:";
            // 
            // comboBoxNumberOfHours
            // 
            this.comboBoxNumberOfHours.BackColor = System.Drawing.Color.Black;
            this.comboBoxNumberOfHours.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxNumberOfHours.FormattingEnabled = true;
            this.comboBoxNumberOfHours.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxNumberOfHours.Location = new System.Drawing.Point(127, 61);
            this.comboBoxNumberOfHours.Name = "comboBoxNumberOfHours";
            this.comboBoxNumberOfHours.Size = new System.Drawing.Size(197, 21);
            this.comboBoxNumberOfHours.TabIndex = 4;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfirm.Location = new System.Drawing.Point(123, 113);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(83, 23);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // frmReservationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(332, 157);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.comboBoxNumberOfHours);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxPlayerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReservationInfo";
            this.Text = "Reservation Info";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxPlayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxNumberOfHours;
        private System.Windows.Forms.Button btnConfirm;
    }
}