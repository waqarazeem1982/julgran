using System;

namespace Julgranar
{
    /// <summary>
    /// Class for printing Christmas Tree
    /// </summary>
    class JulGran
    {
        /// <summary>
        /// Interface method for drawing level 1 triangle with default size 10.
        /// size in this case specifies number of rows of the triangle
        /// </summary>
        /// <param name="size">size (number of rows) of the triangle</param>
        public void DrawLevelOneTriangle(int size = 10)
        {
            DrawTree(1, size);
        }

        /// <summary>
        /// Interface method for drawing a complete christmas tree with 
        /// size 20. Size in this case means nuber of rows in level 2. Level 3 
        /// and 4 are relative to the size of level 2
        /// </summary>
        /// <param name="size"></param>
        public void DrawTree(int size = 20)
        {
            // Call all three levels (2 to 4) to draw a complete tree
            for (int level = 2; level <= 4; level++)
            {
                DrawTree(level, size);
            }
        }

        /// <summary>
        /// Class internal generic method for drawing a specific level of the tree
        /// individual levels can be drawn independently however it makes a complete
        /// tree if all levels from 2 to 4 are drawn sequentially
        /// </summary>
        /// <param name="level">level of the program</param>
        /// <param name="size">relative term for specifying size of the tree/triangle</param>
        private void DrawTree(int level, int size)
        {
            // Check tree size range
            try {
                if (size < 8 || size > 30)
                {
                    throw new ArgumentOutOfRangeException();
                    //Console.WriteLine("Can't draw, outside valid size range (8-30)!");
                    //return;
                }
            } catch(ArgumentOutOfRangeException e)

            {
                Console.WriteLine("{0} : Can't draw, given size ({1}) outside valid range (8-30)!", e.GetType().Name, size);
                return;
            }
            // Check which level it is and set local data
            int start = (level == 3 || level == 4) ? size / 2 + 1 : 0;
            int trunkHeight = start - 2;

            switch (level)
            {
                case 1: // Level 1, triangle
                case 2: // level 2, top part of the tree
                case 3: // level 3, middle part of the tree
                    for (int i = start; i < size; i++)
                    {
                        for (int j = size; j >= 0; j--)
                        {
                            if (j > i)
                            {
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.Write("*" + ((level == 1) ? "" : " "));
                            }
                        }
                        Console.WriteLine();
                    }
                    break;

                case 4: // Level 4, tree trunk
                    for (int i = 0; i < trunkHeight; i++)
                    {
                        for (int j = 0; j <= size + 2; j++)
                        {
                            if (j < size - 2)
                            {
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.Write("*");
                            }
                        }
                        Console.WriteLine();
                    }
                    break;

                default:
                    Console.WriteLine("Unrecognized level ({0}) outside valid level range (1-4)!", level);
                    break;
            }
        }

        /// <summary>
        /// Program entry point
        /// </summary>
        /// <param name="args">command line arguments</param>
        static void Main(string[] args)
        {
            JulGran julGran = new JulGran();

            // Size out of range, will result in an exception
            julGran.DrawLevelOneTriangle(1);

            // Draw level 1 triangle with given size
            julGran.DrawLevelOneTriangle(10);

            // Draw christmas tree with given size
            julGran.DrawTree(15);
        }
    }
}
