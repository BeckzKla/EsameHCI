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
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();

            init();
            defineCBox();

        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.None;

            this.WindowState = FormWindowState.Maximized;
        }

        public void init()
        {
            //adesso andiamo a impostare i colori dei pulsanti e dello schemro 
            //Colore schermo:
            this.BackColor = Const.BackgroundColor;


            //colore dei pulsanti
            Const.settingColorButton(ref ButtonMenu);
            Const.settingColorButton(ref buttonSave);
            Const.checkButtonLangh(ref buttonSave, typeButton.save);

            Const.checkLabelLangh(ref labelLanguage, typeLabel.Language);
            Const.checkLabelLangh(ref labelLivel, typeLabel.Liv);
            Const.checkLabelLangh(ref labelColor1, typeLabel.colorBack);
            Const.checkLabelLangh(ref labelColor2, typeLabel.colorBBackGr);
            Const.checkLabelLangh(ref labelColor3, typeLabel.colorText);


        }

        public void defineCBox()
        { 
            //vado a impostare adesso i  vari colori selzionabili nelle varie barre 
            cBoxLeanguage.Items.AddRange(Const.getRow(Const.LanguagePossible, Const.isItalian));
            cBoxLeanguage.SelectedItem = Const.getRow(Const.LanguagePossible, Const.isItalian)[Const.isItalian];

            cBoxLevel.Items.AddRange(Const.LevelPossible);
            cBoxLevel.SelectedItem = Const.currentLevel.difficulty.ToString();

            cBoxBackground.Items.AddRange(Const.getRow(Const.ColorBackGroundPossibile, Const.isItalian));
            cBoxBackground.SelectedItem =Const.convertTextIngToIT(Const.BackgroundColor.Name);

            cBoxBBeckground.Items.AddRange(Const.getRow(Const.ColorButtonBackground, Const.isItalian));
            cBoxBBeckground.SelectedItem = Const.convertTextIngToIT(Const.ButtonColor.Name);

            cBoxBText.Items.AddRange(Const.getRow(Const.ColorButtonText, Const.isItalian));
            cBoxBText.SelectedItem = Const.convertTextIngToIT(Const.TextColor.Name);


        }


        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Const.BackgroundColor= Const.parseStringToColor(cBoxBackground.SelectedItem.ToString());
            Const.ButtonColor=Const.parseStringToColor(cBoxBBeckground.SelectedItem.ToString());
            Const.TextColor= Const.parseStringToColor(cBoxBText.SelectedItem.ToString());
            Const.currentLevel = new Level(Int32.Parse( cBoxLevel.SelectedItem.ToString()));

            if ((cBoxLeanguage.SelectedItem.ToString() == "Italiano" || cBoxLeanguage.SelectedItem.ToString() == "Italian"))
            {
                cBoxBackground.Items.Clear();
                cBoxBBeckground.Items.Clear();
                cBoxBText.Items.Clear();
                cBoxLeanguage.Items.Clear();

                Const.isItalian = 0;

                defineCBox();
            }
            else if(Const.isItalian!=1)
            {

                cBoxBackground.Items.Clear();
                cBoxBBeckground.Items.Clear();
                cBoxBText.Items.Clear();
                cBoxLeanguage.Items.Clear();

                Const.isItalian = 1;

                defineCBox();

            }


            init();

            Const.proj.init();
            Const.proj.loadCanvas();
            Const.proj.drawShape();
            Const.menu.init();
            Const.help.init();


            Const.saveSettingOnFile();


        }
    }
}
