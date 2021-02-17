using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Test1
{
    public enum typeButton { start, setting, exit , skip, save}

    public enum typeLabel { proxFig, Language, Liv, colorBack, colorBBackGr, colorText, helptext, score}

    public static class Const
    {
        public static int widthScreen;
        public static int heightScreen;

        public static Color BackgroundColor;
        public static Color ButtonColor;
        public static Color TextColor;

        //creo un boolenano che mi dice se si sta utilizzando l'italiano
        public static int isItalian; 


        public static Form1 proj;
        public static Menu menu;
        public static SettingForm setting;
        public static Help help;

        public static Level currentLevel;


        public static string[,] possibleColor= new string[2, 10] { { "Bianco", "Nero", "Verde", "Rosso", "Blu", "Beige", "Azzurro", "Marrone", "Grigio", "Verdone"},
            { "White", "Black",  "Green" , "Red",  "Blue" , "Beige" , "Azure", "Brown", "Gray", "DarkSlateGray"} };

        public static string[,] ColorBackGroundPossibile = Const.possibleColor; 

        public static string[,] ColorButtonBackground = Const.possibleColor;
        public static string[,] ColorButtonText = Const.possibleColor;

        public static string[, ] LanguagePossible= { { "Italiano", "Inglese" }, { "Italian", "English" }}; 

        public static string[] LevelPossible= { "1", "2", "3", "4", "5", "6", "7", "8" }; 


        public static int score ;

        public static void init()
        {
            BackgroundColor = Color.Beige;
            ButtonColor = Color.DarkSlateGray;
            TextColor = Color.White;
            isItalian = 1; 

            Const.loadSettingFile();

            //TextColor = Color.bla;

            proj = new Form1();
            setting = new SettingForm();
            help = new Help();


            Const.score = 0; 
        }

        public static void setMenu(Menu m)
        {
            menu = m;
        }

        public static void settingColorButton(ref Button b)
        {
            b.BackColor = Const.ButtonColor;
            b.ForeColor = Const.TextColor;
        }

        public static string[] getRow(string[,] arr, int index)
        {
            return Enumerable.Range(0, arr.GetLength(1))
            .Select(x => arr[index, x])
            .ToArray();
        }


        public static Color parseStringToColor(string s)
        {
            if (Const.isItalian == 0)
            {

                int indx = Array.IndexOf((Const.getRow(Const.ColorBackGroundPossibile, 0)), s);

                if (indx == -1)
                {
                    return Const.BackgroundColor;
                }

                return Color.FromName(Const.ColorBackGroundPossibile[1, indx]);
            }
            else
            {
                return Color.FromName(s);
            }

        }

        public static string convertTextIngToIT(string it)
        {


            int indx = Array.IndexOf((Const.getRow(Const.ColorBackGroundPossibile, 1)), it);

            if (indx == -1)
            {
                return Const.BackgroundColor.Name;
            }

            return Const.ColorBackGroundPossibile[Const.isItalian, indx];

        }

        public static string convertTextItToIng(string ing)
        {


            int indx = Array.IndexOf((Const.getRow(Const.ColorBackGroundPossibile, 0)), ing);

            if (indx == -1)
            {
                return Const.BackgroundColor.Name;
            }

            return Const.ColorBackGroundPossibile[Const.isItalian, indx];

        }


        public static void checkButtonLangh(ref Button b, typeButton type)
        {
            if (isItalian == 0)
            {
                switch (type)
                {
                    case typeButton.start:
                        b.Text = "Inizia Simulazione";
                        break;
                    case typeButton.setting:
                        b.Text = "Impostazioni";
                        break;
                    case typeButton.skip:
                        b.Text = "Salta";
                        break;
                    case typeButton.save:
                        b.Text = "Salva";
                        break;
                    case typeButton.exit:
                        b.Text = "Esci";
                        break;
                }
            }
            else {
                switch (type)
                {
                    case typeButton.start:
                        b.Text = "Start Simulation";
                        break;
                    case typeButton.setting:
                        b.Text = "Setting";
                        break;
                    case typeButton.skip:
                        b.Text = "Skip";
                        break;
                    case typeButton.save:
                        b.Text = "Save";
                        break;
                    case typeButton.exit:
                        b.Text = "Exit";
                        break;
                }
            }
        }
        public static void checkLabelLangh(ref Label b, typeLabel type)
        {
            if (isItalian == 0)
            {
                switch (type)
                {
                    case typeLabel.proxFig:
                        b.Text = "Figura corrente";
                        break;
                    case typeLabel.Liv:
                        b.Text = "Livello";
                        break;
                    case typeLabel.Language:
                        b.Text = "Lingua";
                        break;
                    case typeLabel.colorText:
                        b.Text = "Colore Testo Pulsanti";
                        break;
                    case typeLabel.colorBBackGr:
                        b.Text = "Colore Sfondo Pulsanti";
                        break;

                    case typeLabel.colorBack:
                        b.Text = "Colore Sfondo";
                        break;
                    case typeLabel.helptext:
                        b.Text = "Descrizioni del programma: \rObiettivo: riempire il reettangolo con le figure che ti vengono proposte \r\r" +
                            "Comandi: utilizza mouse per spostare le figure e usa il tasto R per ruotare le figure \re il tasto M per specchiarle \r\r\r\r\r\r" +
                            "Versione Programma: 1.0.0 \r" +
                            "Data: 07 / 02 / 2021\r";
                        break;

                    case typeLabel.score:
                        b.Text = "Figure slatate: "+Const.score.ToString();
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case typeLabel.proxFig:
                        b.Text = "Current Figure";
                        break;
                    case typeLabel.Liv:
                        b.Text = "Level";
                        break;
                    case typeLabel.Language:
                        b.Text = "Language";
                        break;
                    case typeLabel.colorText:
                        b.Text = "Text Color Buttons";
                        break;
                    case typeLabel.colorBBackGr:
                        b.Text = "Background Color Buttons";
                        break;

                    case typeLabel.colorBack:
                        b.Text = "Background Color";
                        break;
                    case typeLabel.helptext:
                        b.Text = "Program Descriptions: \rObjective: fill in the rectangle with the figures that are suggested to you \r\r" +
                            "Controls: use mouse to move the figures and use the R key to rotate the figures \r the M key to mirror them \r\r\r\r\r\r" +
                            "Program Version: 1.0.0\r" +
                            "Date: 07 / 02 / 2021\r";
                        break;
                    case typeLabel.score:
                        b.Text = "Jumped figures: " + Const.score.ToString();
                        break;
                }
            }

            //b.ForeColor = Const.TextColor;
            //b.BackColor = Const.BackgroundColor;
        }


        public static void saveSettingOnFile()
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("Settings.txt");
                //Write a line of text
                sw.WriteLine(Const.isItalian.ToString());
                sw.WriteLine(Const.currentLevel.difficulty);


                if (isItalian==0)
                {
                    sw.WriteLine(Const.convertTextIngToIT(Const.ButtonColor.Name));
                    sw.WriteLine(Const.convertTextIngToIT(Const.BackgroundColor.Name));
                    sw.WriteLine(Const.convertTextIngToIT(Const.TextColor.Name));

                }
                else
                {
                    sw.WriteLine(Const.ButtonColor.Name);
                    sw.WriteLine(Const.BackgroundColor.Name);
                    sw.WriteLine(Const.TextColor.Name);
                }


                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }



        public static void loadSettingFile()
        {
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("Settings.txt");
                //Read the first line of text


                Const.isItalian = Int32.Parse(sr.ReadLine());
                Const.currentLevel = new Level(Int32.Parse(sr.ReadLine()));


                if (Const.isItalian==0)
                {
                    Const.ButtonColor =Const.parseStringToColor( Const.convertTextItToIng( sr.ReadLine()));
                    Const.BackgroundColor = Const.parseStringToColor(Const.convertTextItToIng(sr.ReadLine()));
                    Const.TextColor = Const.parseStringToColor(Const.convertTextItToIng(sr.ReadLine()));
                }
                else
                {
                    Const.ButtonColor = Const.parseStringToColor(sr.ReadLine());
                    Const.BackgroundColor = Const.parseStringToColor(sr.ReadLine());
                    Const.TextColor = Const.parseStringToColor(sr.ReadLine());
                }


                //Close the file
                sr.Close();

                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Const.currentLevel = new Level(3);

            }
        }

    }
}
