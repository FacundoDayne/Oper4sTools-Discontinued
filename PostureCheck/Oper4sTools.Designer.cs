namespace PostureCheck
{
	partial class Oper4sTools
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
			this.testUserControl1 = new PostureCheck.Panels.testUserControl();
			this.SuspendLayout();
			// 
			// testUserControl1
			// 
			this.testUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.testUserControl1.Location = new System.Drawing.Point(0, 0);
			this.testUserControl1.Name = "testUserControl1";
			this.testUserControl1.Size = new System.Drawing.Size(800, 450);
			this.testUserControl1.TabIndex = 0;
			// 
			// Oper4sTools
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.testUserControl1);
			this.MinimumSize = new System.Drawing.Size(816, 489);
			this.Name = "Oper4sTools";
			this.Text = "Oper4\'s Tools";
			this.ResumeLayout(false);

		}

		#endregion

		private Panels.testUserControl testUserControl1;
	}
}

