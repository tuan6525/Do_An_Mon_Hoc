namespace GiaoDien_DangNhap
{
    partial class frmInHoaDon
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txt_Ma_Hoa_Don = new System.Windows.Forms.TextBox();
            this.grb_Ma_Hoa_Don = new System.Windows.Forms.GroupBox();
            this.btn_In_Hoa_Don = new System.Windows.Forms.Button();
            this.grb_Ma_Hoa_Don.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(1, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(764, 639);
            this.reportViewer1.TabIndex = 0;
            // 
            // txt_Ma_Hoa_Don
            // 
            this.txt_Ma_Hoa_Don.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Ma_Hoa_Don.Location = new System.Drawing.Point(6, 29);
            this.txt_Ma_Hoa_Don.Name = "txt_Ma_Hoa_Don";
            this.txt_Ma_Hoa_Don.Size = new System.Drawing.Size(183, 30);
            this.txt_Ma_Hoa_Don.TabIndex = 1;
            // 
            // grb_Ma_Hoa_Don
            // 
            this.grb_Ma_Hoa_Don.Controls.Add(this.txt_Ma_Hoa_Don);
            this.grb_Ma_Hoa_Don.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_Ma_Hoa_Don.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grb_Ma_Hoa_Don.Location = new System.Drawing.Point(789, 177);
            this.grb_Ma_Hoa_Don.Name = "grb_Ma_Hoa_Don";
            this.grb_Ma_Hoa_Don.Size = new System.Drawing.Size(195, 69);
            this.grb_Ma_Hoa_Don.TabIndex = 2;
            this.grb_Ma_Hoa_Don.TabStop = false;
            this.grb_Ma_Hoa_Don.Text = "Mã Hóa Đơn";
            // 
            // btn_In_Hoa_Don
            // 
            this.btn_In_Hoa_Don.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_In_Hoa_Don.ForeColor = System.Drawing.Color.Blue;
            this.btn_In_Hoa_Don.Location = new System.Drawing.Point(799, 290);
            this.btn_In_Hoa_Don.MaximumSize = new System.Drawing.Size(177, 71);
            this.btn_In_Hoa_Don.MinimumSize = new System.Drawing.Size(177, 71);
            this.btn_In_Hoa_Don.Name = "btn_In_Hoa_Don";
            this.btn_In_Hoa_Don.Size = new System.Drawing.Size(177, 71);
            this.btn_In_Hoa_Don.TabIndex = 3;
            this.btn_In_Hoa_Don.Text = "LẤY HÓA ĐƠN";
            this.btn_In_Hoa_Don.UseVisualStyleBackColor = true;
            this.btn_In_Hoa_Don.Click += new System.EventHandler(this.btn_In_Hoa_Don_Click);
            // 
            // frmInHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1001, 641);
            this.Controls.Add(this.btn_In_Hoa_Don);
            this.Controls.Add(this.grb_Ma_Hoa_Don);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Hóa Đơn";
            this.Load += new System.EventHandler(this.frmInHoaDon_Load);
            this.grb_Ma_Hoa_Don.ResumeLayout(false);
            this.grb_Ma_Hoa_Don.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox txt_Ma_Hoa_Don;
        private System.Windows.Forms.GroupBox grb_Ma_Hoa_Don;
        private System.Windows.Forms.Button btn_In_Hoa_Don;
    }
}