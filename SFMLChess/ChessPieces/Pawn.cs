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
            var boardPosition = tile.GetBoardPosition();
            var possiblePositions = new List<BoardPosition>();

            var x = boardPosition.X;
            var y = boardPosition.Y;

            if (m_color == ChessColor.Black)
            {
                if(y + 1 < 8)
                {
                    possiblePositions.Add(new BoardPosition(x, y + 1));
                }

                if(!m_didMove && y + 2 < 8)
                {
                    possiblePositions.Add(new BoardPosition(x, y + 2));
                }
            }
            else
            {
                if (y - 1 > 0)
                {
                    possiblePositions.Add(new BoardPosition(x, y - 1));
                }

                if (!m_didMove && y - 2 > 0)
                {
                    possiblePositions.Add(new BoardPosition(x, y - 2));
                }
            }

            return new Moveset(possiblePositions);
        }
    }
}
