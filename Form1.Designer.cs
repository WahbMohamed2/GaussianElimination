namespace AppLinearsystem
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbRow = new ComboBox();
            CreateBtn = new Button();
            ClearBtn = new Button();
            SolveBtn = new Button();
            cmb2 = new ComboBox();
            matrixgroup = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            resultbox = new RichTextBox();
            SuspendLayout();
            // 
            // cmbRow
            // 
            cmbRow.DropDownStyle = ComboBoxStyle.Simple;
            cmbRow.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cmbRow.FormattingEnabled = true;
            cmbRow.Items.AddRange(new object[] { "2", "3", "4", "5", "6" });
            cmbRow.Location = new Point(68, 27);
            cmbRow.Margin = new Padding(2);
            cmbRow.Name = "cmbRow";
            cmbRow.Size = new Size(56, 33);
            cmbRow.TabIndex = 0;
            cmbRow.SelectedIndexChanged += cmbRow_SelectedIndexChanged;
            // 
            // CreateBtn
            // 
            CreateBtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            CreateBtn.ForeColor = Color.Black;
            CreateBtn.Location = new Point(149, 91);
            CreateBtn.Margin = new Padding(2);
            CreateBtn.Name = "CreateBtn";
            CreateBtn.Size = new Size(122, 47);
            CreateBtn.TabIndex = 2;
            CreateBtn.Text = "Create";
            CreateBtn.UseVisualStyleBackColor = true;
            CreateBtn.Click += CreateBtn_Click;
            // 
            // ClearBtn
            // 
            ClearBtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            ClearBtn.ForeColor = Color.Black;
            ClearBtn.Location = new Point(526, 91);
            ClearBtn.Margin = new Padding(2);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(122, 47);
            ClearBtn.TabIndex = 4;
            ClearBtn.Text = "Clear";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // SolveBtn
            // 
            SolveBtn.Enabled = false;
            SolveBtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            SolveBtn.ForeColor = Color.Black;
            SolveBtn.Location = new Point(473, 791);
            SolveBtn.Margin = new Padding(2);
            SolveBtn.Name = "SolveBtn";
            SolveBtn.Size = new Size(122, 47);
            SolveBtn.TabIndex = 5;
            SolveBtn.Text = "Solve";
            SolveBtn.UseVisualStyleBackColor = true;
            SolveBtn.Click += SolveBtn_Click;
            // 
            // cmb2
            // 
            cmb2.DropDownStyle = ComboBoxStyle.Simple;
            cmb2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cmb2.FormattingEnabled = true;
            cmb2.Items.AddRange(new object[] { "2", "3", "4", "5", "6" });
            cmb2.Location = new Point(295, 27);
            cmb2.Margin = new Padding(2);
            cmb2.Name = "cmb2";
            cmb2.Size = new Size(56, 33);
            cmb2.TabIndex = 1;
            // 
            // matrixgroup
            // 
            matrixgroup.Anchor = AnchorStyles.None;
            matrixgroup.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            matrixgroup.Location = new Point(2, 142);
            matrixgroup.Margin = new Padding(2);
            matrixgroup.Name = "matrixgroup";
            matrixgroup.Padding = new Padding(2);
            matrixgroup.Size = new Size(826, 629);
            matrixgroup.TabIndex = 7;
            matrixgroup.TabStop = false;
            matrixgroup.Text = "Matrix";
            matrixgroup.Enter += matrixgroup_Enter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 37);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 8;
            label1.Text = "ROWS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(189, 37);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 9;
            label2.Text = "COLUMNS";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.WindowFrame;
            textBox1.Location = new Point(828, -25);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(561, 796);
            textBox1.TabIndex = 10;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // resultbox
            // 
            resultbox.Location = new Point(836, 3);
            resultbox.Name = "resultbox";
            resultbox.Size = new Size(553, 768);
            resultbox.TabIndex = 11;
            resultbox.Text = "";
            resultbox.TextChanged += resultbox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1398, 849);
            Controls.Add(resultbox);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(matrixgroup);
            Controls.Add(cmb2);
            Controls.Add(SolveBtn);
            Controls.Add(ClearBtn);
            Controls.Add(CreateBtn);
            Controls.Add(cmbRow);
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimumSize = new Size(1115, 484);
            Name = "Form1";
            Text = "Linear System Solver";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
		private ComboBox cmbRow;
		private Button CreateBtn;
		private Button ClearBtn;
		private Button SolveBtn;
		private ComboBox cmb2;
		private GroupBox matrixgroup;
        private Label label2;
        private TextBox textBox1;
        private RichTextBox resultbox;
    }
}