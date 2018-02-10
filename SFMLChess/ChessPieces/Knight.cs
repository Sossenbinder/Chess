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
            var boardPosition = tile.GetBoardPosition();
            var possiblePositions = new List<BoardPosition>();

            var x = boardPosition.X;
            var y = boardPosition.Y;

            //Up left
            if (x - 1 >= 0 && y - 2 > 0)
            {
                possiblePositions.Add(new BoardPosition(x - 1, y - 2));
            }

            //Up right
            if (x + 1 < 8 && y - 2 > 0)
            {
                possiblePositions.Add(new BoardPosition(x + 1, y - 2));
            }

            //Left up
            if (x - 2 >= 0 && y - 1 > 0)
            {
                possiblePositions.Add(new BoardPosition(x - 2, y - 1));
            }

            //Left down
            if (x - 2 >= 0 && y + 1 < 8)
            {
                possiblePositions.Add(new BoardPosition(x - 2, y + 1));
            }

            //Down left
            if (x - 1 >= 0 && y + 2 < 8)
            {
                possiblePositions.Add(new BoardPosition(x - 1, y + 2));
            }

            //Down right
            if (x + 1 < 8 && y + 2 < 8)
            {
                possiblePositions.Add(new BoardPosition(x + 1, y + 2));
            }

            //Right up
            if (x + 2 < 8 && y - 1 > 0)
            {
                possiblePositions.Add(new BoardPosition(x + 2, y - 1));
            }

            //Right down
            if (x + 2 < 8 && y + 1 < 8)
            {
                possiblePositions.Add(new BoardPosition(x + 2, y + 1));
            }

            return new Moveset(possiblePositions);
        }
    }
}
