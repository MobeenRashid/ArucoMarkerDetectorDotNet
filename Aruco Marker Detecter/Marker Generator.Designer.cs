namespace Aruco_Marker_Detecter
{
    partial class MarkerGenerator
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnClick = new MetroFramework.Controls.MetroButton();
            this.txtId = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtMarkSize = new MetroFramework.Controls.MetroTextBox();
            this.txtPadding = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(123, 83);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(24, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Id:";
            // 
            // btnClick
            // 
            this.btnClick.Location = new System.Drawing.Point(275, 205);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(74, 23);
            this.btnClick.TabIndex = 1;
            this.btnClick.Text = "OK";
            this.btnClick.UseCustomBackColor = true;
            this.btnClick.UseSelectable = true;
            this.btnClick.UseStyleColors = true;
            this.btnClick.Click += new System.EventHandler(this.btnClick_Click);
            // 
            // txtId
            // 
            this.txtId.Lines = new string[0];
            this.txtId.Location = new System.Drawing.Point(169, 83);
            this.txtId.MaxLength = 32767;
            this.txtId.Name = "txtId";
            this.txtId.PasswordChar = '\0';
            this.txtId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtId.SelectedText = "";
            this.txtId.Size = new System.Drawing.Size(124, 23);
            this.txtId.TabIndex = 2;
            this.txtId.UseCustomBackColor = true;
            this.txtId.UseSelectable = true;
            this.txtId.UseStyleColors = true;
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtId_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(112, 119);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(35, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Size:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(85, 153);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(62, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Padding:";
            // 
            // txtMarkSize
            // 
            this.txtMarkSize.Lines = new string[] {
        "100"};
            this.txtMarkSize.Location = new System.Drawing.Point(169, 119);
            this.txtMarkSize.MaxLength = 32767;
            this.txtMarkSize.Name = "txtMarkSize";
            this.txtMarkSize.PasswordChar = '\0';
            this.txtMarkSize.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMarkSize.SelectedText = "";
            this.txtMarkSize.Size = new System.Drawing.Size(124, 23);
            this.txtMarkSize.TabIndex = 6;
            this.txtMarkSize.Text = "100";
            this.txtMarkSize.UseCustomBackColor = true;
            this.txtMarkSize.UseSelectable = true;
            this.txtMarkSize.UseStyleColors = true;
            this.txtMarkSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarkSize_KeyPress);
            // 
            // txtPadding
            // 
            this.txtPadding.Lines = new string[] {
        "15"};
            this.txtPadding.Location = new System.Drawing.Point(169, 153);
            this.txtPadding.MaxLength = 32767;
            this.txtPadding.Name = "txtPadding";
            this.txtPadding.PasswordChar = '\0';
            this.txtPadding.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPadding.SelectedText = "";
            this.txtPadding.Size = new System.Drawing.Size(124, 23);
            this.txtPadding.TabIndex = 7;
            this.txtPadding.Text = "15";
            this.txtPadding.UseCustomBackColor = true;
            this.txtPadding.UseSelectable = true;
            this.txtPadding.UseStyleColors = true;
            this.txtPadding.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPadding_KeyPress);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(293, 122);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(42, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "pixels";
            // 
            // MarkerGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 251);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtPadding);
            this.Controls.Add(this.txtMarkSize);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnClick);
            this.Controls.Add(this.metroLabel1);
            this.Name = "MarkerGenerator";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Marker Generator";
            this.Load += new System.EventHandler(this.Marker_Id_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MarkerId_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnClick;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        public MetroFramework.Controls.MetroTextBox txtPadding;
        public MetroFramework.Controls.MetroTextBox txtMarkSize;
        public MetroFramework.Controls.MetroTextBox txtId;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}