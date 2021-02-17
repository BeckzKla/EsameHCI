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
    public partial class Menu : Form
    {

        public Menu()
        {
            Const.init();

            InitializeComponent();

            initConst();

            init();
            Const.setMenu(this);
        }


        private void Menu_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.None;

            this.WindowState = FormWindowState.Maximized;

        }
        public void initConst()
        {

            //Per prima cosa rileviamo le dimensioni dello schermo 
            Const.widthScreen = Screen.PrimaryScreen.Bounds.Width;
            Const.heightScreen = Screen.PrimaryScreen.Bounds.Height;

            //inizializzo la classe che contiene le costanti 
            Const.init();
        }
        public void init()
        {


            //vado a posizionare i vari pulsanti sullp schemo 
            startGame.Location = new Point(Const.widthScreen / 2 - startGame.Width / 2, Const.heightScreen / 4 - startGame.Height);
            help.Location = new Point(Const.widthScreen / 2 - startGame.Width / 2, startGame.Location.Y + 100);
            setting.Location = new Point(Const.widthScreen / 2 - startGame.Width / 2, help.Location.Y + 100);
            ButtonExit.Location = new Point(Const.widthScreen / 2 - ButtonExit.Width / 2, setting.Location.Y + 100);

            //adesso andiamo a impostare i colori dei pulsanti e dello schemro 
            //Colore schermo:
            this.BackColor = Const.BackgroundColor;


            //colore dei pulsanti
            Const.settingColorButton(ref startGame);
            Const.settingColorButton(ref setting);
            Const.settingColorButton(ref ButtonExit);
            Const.settingColorButton(ref help);

            Const.checkButtonLangh(ref startGame, typeButton.start);
            Const.checkButtonLangh(ref setting, typeButton.setting);
            Const.checkButtonLangh(ref ButtonExit, typeButton.exit);


        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            //this.Close();
            //Application.Run(new Form1());
            Const.proj.init();
            Const.proj.loadCanvas();
            Const.proj.drawShape();
            Const.proj.ShowDialog();
        }

        private void setting_Click(object sender, EventArgs e)
        {
            Const.setting.ShowDialog();
        }

        private void help_Click(object sender, EventArgs e)
        {
            Const.help.ShowDialog();
        }
    }
}
