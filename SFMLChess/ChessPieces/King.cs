using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLChess.ChessPieces
{
    public class King : ChessPiece
    {
        public King(ChessColor color)
            : base(color)
        {
            m_chessPieceName = "King";
        }
    }
}
