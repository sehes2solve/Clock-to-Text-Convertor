namespace Clock_to_Text_Converter
{
    partial class Form_Clock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Clock));
            this.BTN_validation = new System.Windows.Forms.Button();
            this.BTN_convert = new System.Windows.Forms.Button();
            this.LBL_result = new System.Windows.Forms.Label();
            this.TXT_language = new System.Windows.Forms.TextBox();
            this.TXT_dayhalf = new System.Windows.Forms.TextBox();
            this.TXT_clock = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BTN_validation
            // 
            this.BTN_validation.Location = new System.Drawing.Point(90, 44);
            this.BTN_validation.Name = "BTN_validation";
            this.BTN_validation.Size = new System.Drawing.Size(163, 25);
            this.BTN_validation.TabIndex = 17;
            this.BTN_validation.Text = "Validation";
            this.BTN_validation.UseVisualStyleBackColor = true;
            this.BTN_validation.Click += new System.EventHandler(this.BTN_validation_Click);
            // 
            // BTN_convert
            // 
            this.BTN_convert.Enabled = false;
            this.BTN_convert.Location = new System.Drawing.Point(329, 7);
            this.BTN_convert.Name = "BTN_convert";
            this.BTN_convert.Size = new System.Drawing.Size(84, 35);
            this.BTN_convert.TabIndex = 16;
            this.BTN_convert.Text = "Convert";
            this.BTN_convert.UseVisualStyleBackColor = true;
            this.BTN_convert.Click += new System.EventHandler(this.BTN_convert_Click);
            // 
            // LBL_result
            // 
            this.LBL_result.AutoSize = true;
            this.LBL_result.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_result.Location = new System.Drawing.Point(11, 83);
            this.LBL_result.Name = "LBL_result";
            this.LBL_result.Size = new System.Drawing.Size(57, 21);
            this.LBL_result.TabIndex = 15;
            this.LBL_result.Text = "Result";
            // 
            // TXT_language
            // 
            this.TXT_language.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TXT_language.Location = new System.Drawing.Point(117, 12);
            this.TXT_language.Name = "TXT_language";
            this.TXT_language.Size = new System.Drawing.Size(100, 26);
            this.TXT_language.TabIndex = 14;
            this.TXT_language.Text = "Language";
            this.TXT_language.TextChanged += new System.EventHandler(this.TXT_language_TextChanged);
            this.TXT_language.Enter += new System.EventHandler(this.TXT_language_Enter);
            this.TXT_language.Leave += new System.EventHandler(this.TXT_language_Leave);
            // 
            // TXT_dayhalf
            // 
            this.TXT_dayhalf.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TXT_dayhalf.Location = new System.Drawing.Point(223, 12);
            this.TXT_dayhalf.Name = "TXT_dayhalf";
            this.TXT_dayhalf.Size = new System.Drawing.Size(100, 26);
            this.TXT_dayhalf.TabIndex = 13;
            this.TXT_dayhalf.Text = "Dayhalf";
            this.TXT_dayhalf.TextChanged += new System.EventHandler(this.TXT_dayhalf_TextChanged);
            this.TXT_dayhalf.Enter += new System.EventHandler(this.TXT_dayhalf_Enter);
            this.TXT_dayhalf.Leave += new System.EventHandler(this.TXT_dayhalf_Leave);
            // 
            // TXT_clock
            // 
            this.TXT_clock.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TXT_clock.Location = new System.Drawing.Point(11, 12);
            this.TXT_clock.Name = "TXT_clock";
            this.TXT_clock.Size = new System.Drawing.Size(100, 26);
            this.TXT_clock.TabIndex = 12;
            this.TXT_clock.Text = "Clock";
            this.TXT_clock.TextChanged += new System.EventHandler(this.TXT_clock_TextChanged);
            this.TXT_clock.Enter += new System.EventHandler(this.TXT_clock_Enter);
            this.TXT_clock.Leave += new System.EventHandler(this.TXT_clock_Leave);
            // 
            // Form_Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 120);
            this.Controls.Add(this.BTN_validation);
            this.Controls.Add(this.BTN_convert);
            this.Controls.Add(this.LBL_result);
            this.Controls.Add(this.TXT_language);
            this.Controls.Add(this.TXT_dayhalf);
            this.Controls.Add(this.TXT_clock);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Clock";
            this.Text = "Clock Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BTN_validation;
        private System.Windows.Forms.Button BTN_convert;
        private System.Windows.Forms.Label LBL_result;
        private System.Windows.Forms.TextBox TXT_language;
        private System.Windows.Forms.TextBox TXT_dayhalf;
        private System.Windows.Forms.TextBox TXT_clock;
    }
}

