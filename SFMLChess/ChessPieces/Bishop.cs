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

        public override Moveset GetMoveSetFromTile(Tile tile)
        {
            var boardPosition = tile.GetBoardPosition();
            var possiblePositions = new List<BoardPosition>();

            var x = boardPosition.X;
            var y = boardPosition.Y;

            while (x > 0 && y > 0)
            {
                --x;
                --y;
                possiblePositions.Add(new BoardPosition(x, y));
            }

            x = boardPosition.X;
            y = boardPosition.Y;

            while (x > 0 && y < 7)
            {
                --x;
                ++y;
                possiblePositions.Add(new BoardPosition(x, y));
            }

            x = boardPosition.X;
            y = boardPosition.Y;

            while (x < 7 && y < 7)
            {
                ++x;
                ++y;
                possiblePositions.Add(new BoardPosition(x, y));
            }

            x = boardPosition.X;
            y = boardPosition.Y;

            while (x < 7 && y > 0)
            {
                ++x;
                --y;
                possiblePositions.Add(new BoardPosition(x, y));
            }

            x = boardPosition.X;
            y = boardPosition.Y;

            possiblePositions.Add(new BoardPosition(x, y));

            return new Moveset(possiblePositions);
        }
    }
}
