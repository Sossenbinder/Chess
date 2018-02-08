using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace SFMLChess.ChessPieces
{
    public class Rook : ChessPiece
    {

        public Rook(ChessColor color) 
            : base(color)
        {
            m_chessPieceName = "Rook";
            LoadTexture();
        }
    }
}
