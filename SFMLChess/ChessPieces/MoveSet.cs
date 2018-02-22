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

        private SpecialMove m_specialMove;

        public Moveset(List<BoardPosition> moveSetPositions, SpecialMove specialMove = SpecialMove.None)
        {
            m_moveSetPositions = moveSetPositions;
            m_specialMove = specialMove;
        }

        public List<BoardPosition> GetMoveSetPositions()
        {
            return m_moveSetPositions;
        }

        public SpecialMove GetSpecialMove()
        {
            return m_specialMove;
        }
    }
}
