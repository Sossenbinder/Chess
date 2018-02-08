using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.ChessPieces
{
    public class MoveSet
    {
        private List<BoardPosition> m_moveSetPositions;

        public MoveSet(List<BoardPosition> moveSetPositions)
        {
            m_moveSetPositions = moveSetPositions;
        }
    }
}
