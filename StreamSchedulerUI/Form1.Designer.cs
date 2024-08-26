
namespace StreamSchedulerUI
{
    partial class Form1
    {
        private const bool V = true;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtMonday = new TextBox();
            txtTuesday = new TextBox();
            txtWednesday = new TextBox();
            txtThursday = new TextBox();
            txtFriday = new TextBox();
            txtSaturday = new TextBox();
            txtSunday = new TextBox();
            btnSave = new Button();
            btnClear = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(58, 21);
            label1.TabIndex = 0;
            label1.Text = "Monday";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 70);
            label2.Name = "label2";
            label2.Size = new Size(58, 21);
            label2.TabIndex = 1;
            label2.Text = "Tuesday";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 110);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 2;
            label3.Text = "Wednesday";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 150);
            label4.Name = "label4";
            label4.Size = new Size(66, 21);
            label4.TabIndex = 3;
            label4.Text = "Thursday";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 190);
            label5.Name = "label5";
            label5.Size = new Size(48, 21);
            label5.TabIndex = 4;
            label5.Text = "Friday";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 230);
            label6.Name = "label6";
            label6.Size = new Size(66, 21);
            label6.TabIndex = 5;
            label6.Text = "Saturday";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 270);
            label7.Name = "label7";
            label7.Size = new Size(55, 21);
            label7.TabIndex = 6;
            label7.Text = "Sunday";
            // 
            // txtMonday
            // 
            txtMonday.Location = new Point(150, 30);
            txtMonday.Name = "txtMonday";
            txtMonday.Size = new Size(100, 29);
            txtMonday.TabIndex = 7;
            // 
            // txtTuesday
            // 
            txtTuesday.Location = new Point(150, 70);
            txtTuesday.Name = "txtTuesday";
            txtTuesday.Size = new Size(100, 29);
            txtTuesday.TabIndex = 8;
            // 
            // txtWednesday
            // 
            txtWednesday.Location = new Point(150, 110);
            txtWednesday.Name = "txtWednesday";
            txtWednesday.Size = new Size(100, 29);
            txtWednesday.TabIndex = 9;
            // 
            // txtThursday
            // 
            txtThursday.Location = new Point(150, 150);
            txtThursday.Name = "txtThursday";
            txtThursday.Size = new Size(100, 29);
            txtThursday.TabIndex = 10;
            // 
            // txtFriday
            // 
            txtFriday.Location = new Point(150, 190);
            txtFriday.Name = "txtFriday";
            txtFriday.Size = new Size(100, 29);
            txtFriday.TabIndex = 11;
            // 
            // txtSaturday
            // 
            txtSaturday.Location = new Point(150, 230);
            txtSaturday.Name = "txtSaturday";
            txtSaturday.Size = new Size(100, 29);
            txtSaturday.TabIndex = 12;
            // 
            // txtSunday
            // 
            txtSunday.Location = new Point(150, 270);
            txtSunday.Name = "txtSunday";
            txtSunday.Size = new Size(100, 29);
            txtSunday.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(30, 320);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 30);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(120, 320);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 30);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(210, 320);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 30);
            btnExit.TabIndex = 16;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form1
            // 
            AcceptButton = btnSave;
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            CancelButton = btnExit;
            ClientSize = new Size(322, 380);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(txtMonday);
            Controls.Add(txtTuesday);
            Controls.Add(txtWednesday);
            Controls.Add(txtThursday);
            Controls.Add(txtFriday);
            Controls.Add(txtSaturday);
            Controls.Add(txtSunday);
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(btnExit);
            Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            RightToLeft = RightToLeft.No;
            Text = "Stream Scheduler";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMonday;
        private System.Windows.Forms.TextBox txtTuesday;
        private System.Windows.Forms.TextBox txtWednesday;
        private System.Windows.Forms.TextBox txtThursday;
        private System.Windows.Forms.TextBox txtFriday;
        private System.Windows.Forms.TextBox txtSaturday;
        private System.Windows.Forms.TextBox txtSunday;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
    }
}
