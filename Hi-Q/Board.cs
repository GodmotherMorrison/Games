using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Q
{
    class cell
    {
        public bool value { get; set; }
    }

    class Board
    {
        public int Size { get; set; }
        public int sizeOfCell { get { return Size / 7; } }

        public cell[,] board { get; set; }

        public void Create()
        {
            board = new cell[7, 7];

            for (int i = 2; i < 5; i++)
                for (int j = 0; j < 7; j++)
                    board[i, j] = new cell { value = true };

            //транспонировать

            for (int i = 0; i < 7; i++)
                for (int j = 2; j < 5; j++)
                    board[i, j] = new cell { value = true };

            board[3, 3] = new cell { value = false };

        }
    }
}
