using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock_to_Text_Converter
{
    public partial class Form_Clock : Form
    {
        public Form_Clock()
        {
            InitializeComponent();
        }
        Clock_Text_Methodes ClockMethodesOBJ = new Clock_Text_Methodes();
        private void TXT_clock_Enter(object sender, EventArgs e)
        {
            if (TXT_clock.Text == "Clock" && TXT_clock.ForeColor == SystemColors.InactiveCaption)
            { TXT_clock.Text = ""; TXT_clock.ForeColor = SystemColors.ActiveCaptionText; }
        }

        private void TXT_clock_Leave(object sender, EventArgs e)
        {
            if (TXT_clock.Text == "" && TXT_clock.ForeColor == SystemColors.ActiveCaptionText)
            { TXT_clock.Text = "Clock"; TXT_clock.ForeColor = SystemColors.InactiveCaption; }
        }

        private void TXT_language_Enter(object sender, EventArgs e)
        {
            if (TXT_language.Text == "Language" && TXT_language.ForeColor == SystemColors.InactiveCaption)
            { TXT_language.Text = ""; TXT_language.ForeColor = SystemColors.ActiveCaptionText; }
        }

        private void TXT_language_Leave(object sender, EventArgs e)
        {
            if (TXT_language.Text == "" && TXT_language.ForeColor == SystemColors.ActiveCaptionText)
            { TXT_language.Text = "Language"; TXT_language.ForeColor = SystemColors.InactiveCaption; }
        }

        private void TXT_dayhalf_Enter(object sender, EventArgs e)
        {
            if (TXT_dayhalf.Text == "Dayhalf" && TXT_dayhalf.ForeColor == SystemColors.InactiveCaption)
            { TXT_dayhalf.Text = ""; TXT_dayhalf.ForeColor = SystemColors.ActiveCaptionText; }
        }

        private void TXT_dayhalf_Leave(object sender, EventArgs e)
        {
            if (TXT_dayhalf.Text == "" && TXT_dayhalf.ForeColor == SystemColors.ActiveCaptionText)
            { TXT_dayhalf.Text = "Dayhalf"; TXT_dayhalf.ForeColor = SystemColors.InactiveCaption; }
        }

        private void BTN_validation_Click(object sender, EventArgs e)
        {
            int err_id;string err_message;
            if (TXT_clock.Text == "Clock" && TXT_clock.ForeColor == SystemColors.InactiveCaption)
                TXT_clock.Text = "";
            if (TXT_language.Text == "Language" && TXT_language.ForeColor == SystemColors.InactiveCaption)
                TXT_language.Text = "";
            if (TXT_dayhalf.Text == "Dayhalf" && TXT_dayhalf.ForeColor == SystemColors.InactiveCaption)
                TXT_dayhalf.Text = "";
            ClockMethodesOBJ.validation(TXT_clock.Text, TXT_language.Text, TXT_dayhalf.Text, out err_id, out err_message);
            if (TXT_clock.Text == "" && TXT_clock.ForeColor == SystemColors.InactiveCaption)
                TXT_clock.Text = "Clock";
            if (TXT_language.Text == "" && TXT_language.ForeColor == SystemColors.InactiveCaption)
                TXT_language.Text = "Language";
            if (TXT_dayhalf.Text == "" && TXT_dayhalf.ForeColor == SystemColors.InactiveCaption)
                TXT_dayhalf.Text = "Dayhalf";
            LBL_result.Text = err_id + " : " + err_message;
            if (err_id == 0)
                BTN_convert.Enabled = true;
        }

        private void TXT_clock_TextChanged(object sender, EventArgs e)
        {
            BTN_convert.Enabled = false;
            LBL_result.Text = "Result";
        }

        private void TXT_language_TextChanged(object sender, EventArgs e)
        {
            BTN_convert.Enabled = false;
            LBL_result.Text = "Result";
        }

        private void TXT_dayhalf_TextChanged(object sender, EventArgs e)
        {
            BTN_convert.Enabled = false;
            LBL_result.Text = "Result";
        }

        private void BTN_convert_Click(object sender, EventArgs e)
        {
            string temp;
            if (TXT_clock.Text == "Clock" && TXT_clock.ForeColor == SystemColors.InactiveCaption)
                TXT_clock.Text = "";
            if (TXT_language.Text == "Language" && TXT_language.ForeColor == SystemColors.InactiveCaption)
                TXT_language.Text = "";
            if (TXT_dayhalf.Text == "Dayhalf" && TXT_dayhalf.ForeColor == SystemColors.InactiveCaption)
                TXT_dayhalf.Text = "";
            temp = ClockMethodesOBJ.Clock_Converter(TXT_clock.Text, TXT_language.Text, TXT_dayhalf.Text);
            if (TXT_clock.Text == "" && TXT_clock.ForeColor == SystemColors.InactiveCaption)
                TXT_clock.Text = "Clock";
            if (TXT_language.Text == "" && TXT_language.ForeColor == SystemColors.InactiveCaption)
                TXT_language.Text = "Language";
            if (TXT_dayhalf.Text == "" && TXT_dayhalf.ForeColor == SystemColors.InactiveCaption)
                TXT_dayhalf.Text = "Dayhalf";
            LBL_result.Text = temp;
            BTN_convert.Enabled = true;
        }
    }
}
