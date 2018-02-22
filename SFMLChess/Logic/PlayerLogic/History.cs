using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLChess.Logic.PlayerLogic
{
    public class History
    {
        public List<Move> m_moves;

        public History()
        {
            m_moves = new List<Move>();
        }

        public List<Move> GetMoveList()
        {
            return m_moves;
        }

        public void AddMove(Move move)
        {
            if (move != null)
            {
                m_moves.Add(move);
            }
        }
    }
}
