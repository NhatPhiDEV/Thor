namespace Thor.PresentationLayer.Forms
{
    partial class CourseForm
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
            dgvCourses = new DataGridView();
            groupBox1 = new GroupBox();
            panel3 = new Panel();
            label1 = new Label();
            tbCouseDescription = new TextBox();
            panel2 = new Panel();
            label2 = new Label();
            tbCouseName = new TextBox();
            panel1 = new Panel();
            label3 = new Label();
            tbCouseId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCourses
            // 
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Location = new Point(12, 89);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.Size = new Size(776, 349);
            dgvCourses.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(panel1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 71);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin";
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(tbCouseDescription);
            panel3.Location = new Point(523, 22);
            panel3.Name = "panel3";
            panel3.Size = new Size(247, 34);
            panel3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(5, 8);
            label1.Name = "label1";
            label1.Size = new Size(45, 17);
            label1.TabIndex = 1;
            label1.Text = "Mô tả:";
            // 
            // tbCouseDescription
            // 
            tbCouseDescription.BorderStyle = BorderStyle.FixedSingle;
            tbCouseDescription.Location = new Point(72, 6);
            tbCouseDescription.Name = "tbCouseDescription";
            tbCouseDescription.Size = new Size(166, 23);
            tbCouseDescription.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(tbCouseName);
            panel2.Location = new Point(269, 22);
            panel2.Name = "panel2";
            panel2.Size = new Size(238, 34);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(3, 8);
            label2.Name = "label2";
            label2.Size = new Size(66, 17);
            label2.TabIndex = 2;
            label2.Text = "Tên khóa:";
            // 
            // tbCouseName
            // 
            tbCouseName.BorderStyle = BorderStyle.FixedSingle;
            tbCouseName.Location = new Point(75, 6);
            tbCouseName.Name = "tbCouseName";
            tbCouseName.Size = new Size(160, 23);
            tbCouseName.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(tbCouseId);
            panel1.Location = new Point(16, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(238, 34);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic);
            label3.Location = new Point(3, 8);
            label3.Name = "label3";
            label3.Size = new Size(63, 17);
            label3.TabIndex = 2;
            label3.Text = "Mã Khóa:";
            // 
            // tbCouseId
            // 
            tbCouseId.BorderStyle = BorderStyle.FixedSingle;
            tbCouseId.Location = new Point(70, 6);
            tbCouseId.Name = "tbCouseId";
            tbCouseId.Size = new Size(166, 23);
            tbCouseId.TabIndex = 0;
            // 
            // CourseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(dgvCourses);
            Name = "CourseForm";
            Text = "Khóa học";
            Load += CourseForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            groupBox1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCourses;
        private GroupBox groupBox1;
        private TextBox tbCouseId;
        private Panel panel3;
        private TextBox tbCouseDescription;
        private Panel panel2;
        private TextBox tbCouseName;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}