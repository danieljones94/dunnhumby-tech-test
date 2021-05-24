using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses.Models
{
    public class Row
    {
        public int[] points;

        public Row()
        {
            //initialises each row and an array of ints
            points = new int[3];
        }

        public int ChoosePointOnRow(int point, int turns)
        {
            //conditions depending on whether point is valid
            if (point > 3 || point < 1)
            {
                return 0;
            }
            if (points[point - 1] != 0)
            {
                return 0;
            }

            //changes value of point depending on which turn and thus which player -- see show method below to see how grid is rendered depending on value
            if (turns % 2 == 0)
            {
                points[point - 1] = 1;
                return point;
            }
            else
            {
                points[point - 1] = 2;
                return point;
            }
        }

        public void Show()
        {
            string row = "";

            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] == 0)
                {
                    row += "| - |";
                }
                else if (points[i] == 1)
                {
                    row += "| X |";
                }
                else if (points[i] == 2)
                {
                    row += "| O |";
                }
            }

            Console.WriteLine(row);
        }
    }
}
