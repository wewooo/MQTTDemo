namespace MQTTBroker
{
    partial class Main
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
            this.btn_start = new Sunny.UI.UIButton();
            this.txt_password = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txt_username = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.cb_verify = new Sunny.UI.UICheckBox();
            this.txt_port = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_start.Location = new System.Drawing.Point(210, 264);
            this.btn_start.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(125, 44);
            this.btn_start.TabIndex = 7;
            this.btn_start.Text = "启动";
            this.btn_start.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // txt_password
            // 
            this.txt_password.DoubleValue = 123456D;
            this.txt_password.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_password.IntValue = 123456;
            this.txt_password.Location = new System.Drawing.Point(106, 212);
            this.txt_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_password.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_password.Name = "txt_password";
            this.txt_password.ShowText = false;
            this.txt_password.Size = new System.Drawing.Size(229, 36);
            this.txt_password.TabIndex = 6;
            this.txt_password.Text = "123456";
            this.txt_password.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_password.Watermark = "";
            this.txt_password.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel3.Location = new System.Drawing.Point(21, 212);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(78, 35);
            this.uiLabel3.TabIndex = 5;
            this.uiLabel3.Text = "密码";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_username
            // 
            this.txt_username.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_username.Location = new System.Drawing.Point(106, 160);
            this.txt_username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_username.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_username.Name = "txt_username";
            this.txt_username.ShowText = false;
            this.txt_username.Size = new System.Drawing.Size(229, 36);
            this.txt_username.TabIndex = 4;
            this.txt_username.Text = "test";
            this.txt_username.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_username.Watermark = "";
            this.txt_username.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel2.Location = new System.Drawing.Point(21, 160);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(78, 35);
            this.uiLabel2.TabIndex = 3;
            this.uiLabel2.Text = "用户名";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cb_verify
            // 
            this.cb_verify.Checked = true;
            this.cb_verify.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_verify.Location = new System.Drawing.Point(106, 108);
            this.cb_verify.MinimumSize = new System.Drawing.Size(1, 1);
            this.cb_verify.Name = "cb_verify";
            this.cb_verify.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.cb_verify.Size = new System.Drawing.Size(38, 36);
            this.cb_verify.TabIndex = 2;
            this.cb_verify.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_port
            // 
            this.txt_port.DoubleValue = 1883D;
            this.txt_port.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_port.IntValue = 1883;
            this.txt_port.Location = new System.Drawing.Point(106, 56);
            this.txt_port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_port.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_port.Name = "txt_port";
            this.txt_port.ShowText = false;
            this.txt_port.Size = new System.Drawing.Size(229, 36);
            this.txt_port.TabIndex = 1;
            this.txt_port.Text = "1883";
            this.txt_port.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_port.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_port.Watermark = "";
            this.txt_port.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel1.Location = new System.Drawing.Point(21, 56);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(78, 35);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "端口";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiLabel4.Location = new System.Drawing.Point(21, 108);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(78, 35);
            this.uiLabel4.TabIndex = 8;
            this.uiLabel4.Text = "验证";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(373, 333);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.cb_verify);
            this.Controls.Add(this.uiLabel2);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "MQTTBroker";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITextBox txt_port;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton btn_start;
        private Sunny.UI.UITextBox txt_password;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txt_username;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UICheckBox cb_verify;
        private Sunny.UI.UILabel uiLabel4;
    }
}