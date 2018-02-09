using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.ChessPieces
{
    public class Knight : ChessPiece
    {

        public Knight(ChessColor color)
            : base(color)
        {
            m_chessPieceName = "Knight";
            LoadTexture();
        }

        public override Moveset GetMoveSetFromTile(Tile tile)
        {
            throw new NotImplementedException();
        }
    }
}
