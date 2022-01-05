using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pendulumWinForm
{
    public partial class NewLink : Form
    {
        public static string txtb;
        public NewLink()
        {
            InitializeComponent();
        }

        private void btn_Kesz_Click(object sender, EventArgs e)
        {
            txtb = textBox1.Text;
            txtb = string.Join(string.Empty, txtb.Skip(17));
            this.Close();
        }
    }
}
