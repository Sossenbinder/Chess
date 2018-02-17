using SFMLChess.ChessPieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLChess.Logic.PlayerLogic
{
    public class Graveyard
    {
        private List<ChessPiece> m_deadChessPieces;

        public Graveyard()
        {
            m_deadChessPieces = new List<ChessPiece>();
        }

        public List<ChessPiece> GetDeadChessPieces()
        {
            return m_deadChessPieces;
        }

        public void AddDeadChessPieces(ChessPiece chessPiece)
        {
            if(chessPiece != null)
            {
                m_deadChessPieces.Add(chessPiece);
            }
        }
    }
}
