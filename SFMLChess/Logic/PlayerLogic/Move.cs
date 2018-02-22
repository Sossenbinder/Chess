using SFMLChess.Logic.BoardLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLChess.Logic.PlayerLogic
{
    public class Move
    {
        private BoardPosition m_previousPosition;
        private BoardPosition m_newPosition;

        public Move(BoardPosition previousPosition, BoardPosition newPosition)
        {
            m_previousPosition = previousPosition;
            m_newPosition = newPosition;
        }

        public BoardPosition GetPreviousPosition()
        {
            return m_previousPosition;
        }

        public BoardPosition GetNewPosition()
        {
            return m_newPosition;
        }
    }
}
