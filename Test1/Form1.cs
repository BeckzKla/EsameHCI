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
    public partial class Form1 : Form
    {
        
        // utilizziamo BitMap e Graphics per modelare le figure dentro la figure box
        Bitmap canvasBitmap;
        Graphics canvasGraphics;


        //in questa parte inizializziamo un luivello di difficoltà
        Level currentL;


        // larghezza e altezza della tela (Canvas) 
        int canvasWidth=1 ;
        int canvasHeight =1;
        int[,] canvasDotArray;
        int[,] holdCanvasArray;
        int dotSize=  20;




        // adesso inizializzo la forma corrente 
        Shape currentShape;
        Shape nextShape;


        //adesso vado a inizializzare due var che servinaranno per individuare la posizione del blocco
        int currentX;
        int currentY;

        //Per individuare quanto è grossa la finestra di destra 
        int sizePicture2; 

        public Form1()
        {

            
           
            InitializeComponent();

            loadCanvas();
            init();



            //uso la funzione turn object per coontrollare se si è cliccato R che lo fa ruotare
            this.KeyDown+= Form1_KeyDown;

            //questo comando mi dice che la taastiera viene presa prima dei buttn 
            this.KeyPreview = true;

            drawShape();
        }

        //metodo utilizzato per adattare le dim dello schermo e inserire un background 
        public void init()
        {
            pictureBox1.Location = new Point(Const.widthScreen/2-pictureBox1.Width/2-40, 30);

            //Per priam cosa vado a poszionare i vari elementi sullo schermo 
            int currentDot = dotSize;
            if (currentL.difficulty == 2)
            {
                currentDot = (int)dotSize / 2;
            }
            else if (currentL.difficulty == 1)
            {
                currentDot = (int)dotSize / 4;
            }
            sizePicture2 = 6 * currentDot;


            int posXObjectRight = pictureBox1.Location.X + pictureBox1.Width + 10;


            label1.Location= new Point(posXObjectRight, pictureBox1.Location.Y);


            pictureBox2.Location = new Point(posXObjectRight,  label1.Location.Y+50);

            button2.Location=  new Point(posXObjectRight, pictureBox2.Location.Y + sizePicture2 + 20);


            ButtonReset.Location= new Point(pictureBox1.Location.X, pictureBox1.Location.Y+pictureBox1.Height+20);

            label2.Location = new Point(posXObjectRight, button2.Location.Y + button2.Height + 20);

            buttonMenu.Location= new Point(20, 20);
            


            //adesso andiamo a impostare i colori dei pulsanti e dello schemro 
            //Colore schermo:
            this.BackColor = Const.BackgroundColor;

            //colore dei pulsanti
            Const.settingColorButton(ref button2);
            Const.settingColorButton(ref ButtonReset);
            Const.settingColorButton(ref buttonMenu);
            Const.checkButtonLangh(ref button2, typeButton.skip);
            Const.checkLabelLangh(ref label1, typeLabel.proxFig);
            Const.checkLabelLangh(ref label2, typeLabel.score);


            //la figura corrente viene scelta randomicamente attraverso una funzione appositamente creata per questo scopo 
            nextShape = getNextShape();
            currentShape = nextShape;

        }


        //funzione che carica la tela 
        public void loadCanvas()
        {
            currentL = Const.currentLevel;


            canvasWidth = currentL.selectWidthLevel();
            canvasHeight = currentL.selectHeightLevel();
            dotSize = currentL.sizeBlock;

            // Qui vado a scegliere le dimensioni del rettangolo dovae andranno i blocchi 
            pictureBox1.Width = canvasWidth * dotSize;
            pictureBox1.Height = canvasHeight * dotSize;

            // Create Bitmap with picture box's size
            canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            canvasGraphics = Graphics.FromImage(canvasBitmap);

            canvasGraphics.FillRectangle(new SolidBrush(Const.ButtonColor), 0, 0, canvasBitmap.Width, canvasBitmap.Height);

            // Load bitmap into picture box
            pictureBox1.Image = canvasBitmap;

            // Initialize canvas dot array. by default all elements are zero
            canvasDotArray = new int[canvasWidth, canvasHeight];

            holdCanvasArray= new int[canvasWidth, canvasHeight];
        }






        private void label3_Click(object sender, EventArgs e)
        {

        }


        // questa parte mo serve per la figura succesiva
        Bitmap nextShapeBitmap;
        Graphics nextShapeGraphics;


        private Shape getRandomShapeWithCenterAligned()
        {
            var shape = ShapesHandler.GetRandomShape();

            // Calculate the x and y values as if the shape lies in the center

            //Point posLabel = label1.Location;
            currentX = 0;
            currentY = 0;

            return shape;
        }


        private Shape getNextShape()
        {

            int currentDot = dotSize;

            if (currentL.difficulty == 2)
            {
                currentDot = (int)dotSize / 2;
            }
            else if (currentL.difficulty == 1)
            {
                currentDot = (int)dotSize / 4;
            }

            var shape = getRandomShapeWithCenterAligned();

            // Codes to show the next shape in the side panel
            nextShapeBitmap = new Bitmap(6 * currentDot, 6 * currentDot);
            nextShapeGraphics = Graphics.FromImage(nextShapeBitmap);

            nextShapeGraphics.FillRectangle(new SolidBrush(Const.ButtonColor), 0, 0, nextShapeBitmap.Width, nextShapeBitmap.Height);


            // Find the ideal position for the shape in the side panel
            var startX = (6 - shape.Width) / 2;
            var startY = (6 - shape.Height) / 2;

            for (int i = 0; i < shape.Height; i++)
            {
                for (int j = 0; j < shape.Width; j++)
                {
                    nextShapeGraphics.FillRectangle(
                        shape.Dots[i, j] == 1 ? Brushes.White : new SolidBrush(Const.ButtonColor),
                        (startX + j) * currentDot, (startY + i) * currentDot, currentDot, currentDot);
                }
            }

            pictureBox2.Size = nextShapeBitmap.Size;
            pictureBox2.Image = nextShapeBitmap;

            return shape;
        }

        Bitmap workingBitmap;
        Graphics workingGraphics;


        Bitmap holdworkingBitmap;
        Graphics holdworkingGraphics;


        public void drawShape()
        {
            drawGrid();
            workingBitmap = new Bitmap(canvasBitmap);
            workingGraphics = Graphics.FromImage(workingBitmap);

            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] == 1)
                    {
                        if (isOverlap())
                        {
                            workingGraphics.FillRectangle(Brushes.Red, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                        }
                        else if (mousIspress)
                        {
                            workingGraphics.FillRectangle(Brushes.Blue, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                        }
                        else
                            workingGraphics.FillRectangle(Brushes.White, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);

                    }

                }
            }

            pictureBox1.Image = workingBitmap;
        }

        private void drawGrid()
        {
            Graphics g = Graphics.FromImage(this.pictureBox1.Image);
            int numOfCells = canvasHeight * canvasWidth;
            int cellSize = dotSize;
            Pen p = new Pen(Color.Black);


            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }

        private void updateCanvasDotArrayWithCurrentShape()
        {


            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] == 1)
                    {
                        //checkIfGameOver();

                        canvasDotArray[currentX + i, currentY + j] = 1;
                    }
                }
            }
            
        }

        bool isOverlap()
        {
            int newX = currentX;
            int newY = currentY;

            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if ((currentShape.Dots[j, i] & canvasDotArray[newX + i, newY + j]) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        // returns if it reaches the bottom or touches any other blocks
        private bool moveShapeIfPossible(int newX = 0, int newY = 0)
        {

            // check if it reaches the bottom or side bar
            if (newX < 0 || newX + currentShape.Width > canvasWidth
                || newY + currentShape.Height > canvasHeight )
                return false;

            if (newY < 0 )
                return false;


            currentX = newX;
            currentY = newY;
            drawShape();
            return true;
        }


        bool mousIspress = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {



            mousIspress = true;
            drawShape();


        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mousIspress = false;

            if (!isOverlap())
            {
                drawShape();

                // copy working image into canvas image
                canvasBitmap = new Bitmap(workingBitmap);

                //holdCanvasArray = canvasDotArray;

                updateCanvasDotArrayWithCurrentShape();

                // get next shape

                nextShape = getNextShape();
                currentShape = nextShape;


            }


        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mousIspress)
            {
                //label1.Text = "Y:" + e.Y;
                int newX = (e.X / dotSize);
                int newY = e.Y / dotSize;

                moveShapeIfPossible(newX, newY);

            }

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                currentShape.turn();
                drawShape();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                currentShape.turn();
                drawShape();
            }
            
            if (e.KeyCode == Keys.E)
            {
                if (canvasDotArray == holdCanvasArray)
                {
                    label1.Text = "Il go back non funziona" ;
                }
                canvasDotArray = holdCanvasArray; 
            }

            if(e.KeyCode==Keys.M)
            {
                currentShape.mirroring();
                drawShape();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (canvasDotArray == holdCanvasArray)
            {
                label1.Text = "Il go back non funziona";
            }
            canvasDotArray = holdCanvasArray;

 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Const.score++;
            Const.checkLabelLangh(ref label2, typeLabel.score);
            currentShape = getNextShape();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.None;

            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {

            loadCanvas();
            init();

            drawShape();

        }

        private void buttonMenu_Click_1(object sender, EventArgs e)
        {
            Const.score = 0; 
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
