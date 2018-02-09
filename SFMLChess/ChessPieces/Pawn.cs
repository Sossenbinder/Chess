using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.ChessPieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(ChessColor color)
            : base(color)
        {
            m_chessPieceName = "Pawn";
            LoadTexture();
        }

        public override Moveset GetMoveSetFromTile(Tile tile)
        {
            throw new NotImplementedException();
        }
    }
}
