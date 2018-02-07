using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLChess.ChessPieces
{
    public class Knight : ChessPiece
    {

        public Knight(ChessColor color)
            : base(color)
        {
            m_chessPieceName = "Knight";
        }
    }
}
