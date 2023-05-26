using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDI_1937873
{
    public partial class Videos : Form
    {
        public Videos()
        {
            InitializeComponent();
        }

        private void imágenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Imgs imgs = new Imgs();
            imgs.Show();
        }

        private void contarPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            RT mainRT = new RT();
            mainRT.Show();
        }
    }
}
