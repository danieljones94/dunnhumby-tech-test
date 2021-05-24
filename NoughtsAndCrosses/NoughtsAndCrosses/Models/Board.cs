using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses.Models
{
    public class Board
    {
        public Row[] rows;

        public Board()
        {
            //Initialises each row in grid as new row with points
            rows = new Row[3];
            for (int i = 0; i < 3; i++)
            {
                rows[i] = new Row();
            }
        }

        public void GetBoard()
        {
            //calls the show method to display grid in current state
            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Show();
            }
        }

        public int ChooseRow(string choice)
        {
            int row;

            if (int.TryParse(choice, out row))
            {
                //checks if valid row
                if (row > 3 || row < 1)
                {
                    return 0;
                }

                //returns row if valid
                return int.Parse(choice);
            }
            else
            {
                return 0;
            }
        }

    }
}
