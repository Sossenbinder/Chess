using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.ChessPieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(ChessColor color)
            : base(color)
        {
            m_chessPieceName = "Bishop";
            LoadTexture();
        }

        public override MoveSet GetMoveSetFromTile(Tile tile, Board board)
        {
            var boardPosition = tile.GetBoardPosition();
            var possiblePositions = new List<BoardPosition>();

            int x = boardPosition.X;
            int y = boardPosition.Y;

            while (x >= 0 && y >= 0)
            {
                
            }


            return new MoveSet(null);
        }
    }
}
