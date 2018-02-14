using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLChess.Logic.BoardLogic
{
    public class BoardPosition
    {
        public int X;
        public int Y;

        public bool Beatable;

        public BoardPosition(int x, int y, bool beatable = false)
        {
            X = x;
            Y = y;
            Beatable = beatable;
        }
    }
}
