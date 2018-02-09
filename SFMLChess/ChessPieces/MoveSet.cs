using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.ChessPieces
{
    public class Moveset
    {
        private List<BoardPosition> m_moveSetPositions;

        public Moveset(List<BoardPosition> moveSetPositions)
        {
            m_moveSetPositions = moveSetPositions;
        }

        public List<BoardPosition> GetMoveSetPositions()
        {
            return m_moveSetPositions;
        }
    }
}
