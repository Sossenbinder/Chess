using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.ChessPieces
{
    public class King : ChessPiece
    {
        public King(ChessColor color)
            : base(color)
        {
            m_chessPieceName = "King";
            LoadTexture();
        }

        public override Moveset GetMoveSetFromTile(Tile tile)
        {
            throw new NotImplementedException();
        }
    }
}
