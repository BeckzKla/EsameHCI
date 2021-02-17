using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Test1
{
    public class Level
    {
        //utilizziamo la variabile difficulty per categorizzare la forma del mio rettangolo 
        //d=1 -> w e h circa 5 
        //d=2 -> w e h circa 10
        //d=3 -> w e h circa 15
        // e cosi via fino ad arrivare ad un livello massimo d=10

        public int difficulty;
        private Timer timeOdProgram;
        private int dimProv;
        public int sizeBlock; 

        private void getDimProv()
        {
            switch (difficulty)
            {
                case 1:
                    dimProv = 5;
                    sizeBlock = 150; 
                    break;
                case 2:
                    dimProv = 10;
                    sizeBlock = 75;
                    break;
                case 3: //750
                    dimProv = 15;
                    sizeBlock = 50;
                    break;
                case 4:
                    dimProv = 20;
                    sizeBlock = 37;
                    break;
                case 5:
                    dimProv = 25;
                    sizeBlock = 30;
                    break;
                case 6:
                    dimProv = 30;
                    sizeBlock = 25;
                    break;
                case 7:
                    dimProv = 35;
                    sizeBlock = 20;
                    break;
                case 8:
                    dimProv = 40;
                    sizeBlock = 18;
                    break;
            }
        }
    

        public Level(int diff)
        {
            difficulty = diff;
            getDimProv(); 
            timeOdProgram = new Timer(); 
        }

        public int selectWidthLevel()
        {
            return dimProv;
        }

        public int selectHeightLevel()
        {
            return dimProv;
        }




    }
}
