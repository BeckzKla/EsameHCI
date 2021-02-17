using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();

            init();
        }


        public void init()
        {

            //Colore schermo:
            this.BackColor = Const.BackgroundColor;


            //colore dei pulsanti
            Const.settingColorButton(ref ButtonMenu);

            Const.checkLabelLangh(ref label1, typeLabel.helptext);

        }
        private void Help_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.None;

            this.WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
