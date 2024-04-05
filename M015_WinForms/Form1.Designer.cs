namespace M015_WinForms
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
			button1 = new Button();
			comboBox1 = new ComboBox();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Font = new Font("Segoe UI", 12F);
			button1.Location = new Point(124, 388);
			button1.Name = "button1";
			button1.Size = new Size(186, 50);
			button1.TabIndex = 0;
			button1.Text = "Mein erster Button";
			button1.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(76, 12);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(265, 23);
			comboBox1.TabIndex = 1;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(431, 450);
			Controls.Add(comboBox1);
			Controls.Add(button1);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion

		private Button button1;
		private ComboBox comboBox1;
	}
}
