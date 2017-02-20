namespace WindowsFormsApplication1
{
    partial class Assignment2Form
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
            this.selectLogFile_Button = new System.Windows.Forms.Button();
            this.go_Button = new System.Windows.Forms.Button();
            this.exit_Button = new System.Windows.Forms.Button();
            this.filePath_Textbox = new System.Windows.Forms.TextBox();
            this.openLogFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.display_Box = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // selectLogFile_Button
            // 
            this.selectLogFile_Button.Location = new System.Drawing.Point(1, 10);
            this.selectLogFile_Button.Name = "selectLogFile_Button";
            this.selectLogFile_Button.Size = new System.Drawing.Size(75, 23);
            this.selectLogFile_Button.TabIndex = 0;
            this.selectLogFile_Button.Text = "Select Log FIle";
            this.selectLogFile_Button.UseVisualStyleBackColor = true;
            this.selectLogFile_Button.Click += new System.EventHandler(this.selectLogFile_Button_Click);
            // 
            // go_Button
            // 
            this.go_Button.Location = new System.Drawing.Point(325, 53);
            this.go_Button.Name = "go_Button";
            this.go_Button.Size = new System.Drawing.Size(75, 23);
            this.go_Button.TabIndex = 2;
            this.go_Button.Text = "Go";
            this.go_Button.UseVisualStyleBackColor = true;
            this.go_Button.Click += new System.EventHandler(this.go_Button_Click);
            // 
            // exit_Button
            // 
            this.exit_Button.Location = new System.Drawing.Point(325, 507);
            this.exit_Button.Name = "exit_Button";
            this.exit_Button.Size = new System.Drawing.Size(75, 23);
            this.exit_Button.TabIndex = 3;
            this.exit_Button.Text = "Exit";
            this.exit_Button.UseVisualStyleBackColor = true;
            this.exit_Button.Click += new System.EventHandler(this.exit_Button_Click);
            // 
            // filePath_Textbox
            // 
            this.filePath_Textbox.Location = new System.Drawing.Point(91, 13);
            this.filePath_Textbox.Name = "filePath_Textbox";
            this.filePath_Textbox.Size = new System.Drawing.Size(309, 20);
            this.filePath_Textbox.TabIndex = 4;
            // 
            // openLogFileDialog
            // 
            this.openLogFileDialog.FileName = "openLogFileDialog";
            // 
            // display_Box
            // 
            this.display_Box.FormattingEnabled = true;
            this.display_Box.Location = new System.Drawing.Point(12, 53);
            this.display_Box.Name = "display_Box";
            this.display_Box.Size = new System.Drawing.Size(307, 472);
            this.display_Box.TabIndex = 5;
            // 
            // Assignment2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 560);
            this.Controls.Add(this.display_Box);
            this.Controls.Add(this.filePath_Textbox);
            this.Controls.Add(this.exit_Button);
            this.Controls.Add(this.go_Button);
            this.Controls.Add(this.selectLogFile_Button);
            this.Name = "Assignment2Form";
            this.Text = "Who is Hitting Us?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectLogFile_Button;
        private System.Windows.Forms.Button go_Button;
        private System.Windows.Forms.Button exit_Button;
        private System.Windows.Forms.TextBox filePath_Textbox;
        private System.Windows.Forms.OpenFileDialog openLogFileDialog;
        private System.Windows.Forms.ListBox display_Box;
    }
}

