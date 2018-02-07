using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLChess.ChessPieces
{
    public class Queen : ChessPiece
    {

        public Queen(ChessColor color)
            : base(color)
        {
            m_chessPieceName = "Queen";
        }
    }
}
