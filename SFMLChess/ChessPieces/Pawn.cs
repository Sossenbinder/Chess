using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLChess.ChessPieces
{
    public class Pawn : ChessPiece
    {

        public Pawn(ChessColor color)
            : base(color)
        {
            m_chessPieceName = "Pawn";
        }
    }
}
