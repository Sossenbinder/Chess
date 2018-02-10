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
            var boardPosition = tile.GetBoardPosition();
            var possiblePositions = new List<BoardPosition>();

            var x = boardPosition.X;
            var y = boardPosition.Y;
            
            //Left up
            if(x - 1 > 0 && y - 1 > 0)
            {
                possiblePositions.Add(new BoardPosition(x - 1, y - 1));
            }

            //Left
            if (x - 1 > 0)
            {
                possiblePositions.Add(new BoardPosition(x - 1, y));
            }

            //Left down
            if (x - 1 > 0 && y + 1 < 8)
            {
                possiblePositions.Add(new BoardPosition(x - 1, y + 1));
            }

            //Down
            if (y + 1 < 8)
            {
                possiblePositions.Add(new BoardPosition(x, y + 1));
            }

            //Right down
            if (x + 1 < 8 && y + 1 < 8)
            {
                possiblePositions.Add(new BoardPosition(x + 1, y + 1));
            }

            //Right
            if (x + 1 < 8)
            {
                possiblePositions.Add(new BoardPosition(x + 1, y));
            }

            //Right up
            if (x + 1 < 8 && y - 1 > 0)
            {
                possiblePositions.Add(new BoardPosition(x + 1, y - 1));
            }

            //Up
            if (y - 1 > 0)
            {
                possiblePositions.Add(new BoardPosition(x, y - 1));
            }

            return new Moveset(possiblePositions);
        }
    }
}
