using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLChess.ChessPieces
{
    public class Bishop : ChessPiece
    {

        public Bishop(ChessColor color)
            : base(color)
        {
            m_chessPieceName = "Bishop";
        }
    }
}
