using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Shape
    {

        public int Width;
        public int Height;
        public int[,] Dots;

        private int[,] backupDots;


        /// <summary>
        /// metodi per girare la forma e per tornare indietro.
        /// Il rollback avviene quando il giocatore cerca di girare la forma ma quella mossa non è 
        /// disponibile perché raggiunge il fondo o tocca altre forme.
        /// </summary>
        public void turn()
        {
            // back the dots values into backup dots
            // so that it can be simply used for rolling back
            backupDots = Dots;

            Dots = new int[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Dots[i, j] = backupDots[Height - 1 - j, i];
                }
            }

            var temp = Width;
            Width = Height;
            Height = temp;
        }

        public void mirroring()
        {
            // back the dots values into backup dots
            // so that it can be simply used for rolling back
            backupDots = Dots;

            Dots = new int[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Dots[i, j] = backupDots[j, Width-i];
                }
            }

            var temp = Width;
            Width = Height;
            Height = temp;
        }

        // the rolling back occurs when player rotating the shape
        // but it will touch other shapes and needs to be rolled back
        public void rollback()
        {
            Dots = backupDots;

            var temp = Width;
            Width = Height;
            Height = temp;
        }

        /// <summary>
        /// metodi per girare la forma e per tornare indietro.
        /// Il rollback avviene quando il giocatore cerca di girare la forma ma quella mossa non è 
        /// disponibile perché raggiunge il fondo o tocca altre forme.
        /// </summary>



    }

    static class ShapesHandler
    {
        private static Shape[] shapesArray;

        //public static int NumCellInGrid; 

        // static constructor : No need to manually initialize
        static ShapesHandler()
        {
            // Create shapes add into the array.
            shapesArray = new Shape[]
                {
                    new Shape{
                        Width = 1,
                        Height = 1,
                        Dots = new int[,]
                        {
                            { 1}
                        }
                    },

                    new Shape{
                        Width = 1,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 1},
                            { 1}
                        }
                    }, 

                    new Shape {
                        Width = 2,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 1, 1 },
                            { 1, 1 }
                        }
                    },
                    new Shape {
                        Width = 1,
                        Height = 4,
                        Dots = new int[,]
                        {
                            { 1 },
                            { 1 },
                            { 1 },
                            { 1 }
                        }
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 1, 0 },
                            { 1, 1, 1 }
                        }
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 0, 1 },
                            { 1, 1, 1 }
                        }
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 1, 0, 0 },
                            { 1, 1, 1 }
                        }
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 1, 1, 0 },
                            { 0, 1, 1 }
                        }
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 1, 1 },
                            { 1, 1, 0 }
                        }
                    }
                    // new shapes can be added here..
                };
        }

        // Get a shape form the array in a random basis
        public static Shape GetRandomShape()
        {
            var shape = shapesArray[new Random().Next(shapesArray.Length)];

            return shape;
        }
    }
}
