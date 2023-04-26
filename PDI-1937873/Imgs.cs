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
    public partial class Imgs : Form
    {
        public Imgs()
        {
            InitializeComponent();
        }

        private void contarPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            RT mainRT = new RT();
            mainRT.Show();
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Videos video = new Videos();
            video.Show();
        }
    }
}
