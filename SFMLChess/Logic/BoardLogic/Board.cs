using System.Collections.Generic;
using SFMLChess.ChessPieces;
using SFMLChess.Logic.PlayerLogic;

namespace SFMLChess.Logic.BoardLogic
{
    public class Board
    {
        private Tile m_selectedTile;

        private Tile[,] m_board;

        private List<BoardPosition> m_validMovePositions;

        private Graveyard m_blackGraveyard;
        private History m_blackHistory;

        private Graveyard m_whiteGraveyard;
        private History m_whiteHistory;

        private ChessColor m_activeColor;
        
        public Board(Graveyard blackGraveyard, History blackHistory, Graveyard whiteGraveyard, History whiteHistory)
        {
            m_blackGraveyard = blackGraveyard;
            m_blackHistory = blackHistory;
            m_whiteGraveyard = whiteGraveyard;
            m_whiteHistory = whiteHistory;

            m_activeColor = ChessColor.White;

            m_validMovePositions = new List<BoardPosition>();

            ResetBoard();
        }

        public void ResetBoard(bool isWhiteTop = false)
        {
            m_board = new Tile[8, 8];

            for (var i = 0; i < 8; ++i)
            {
                var blackFirstRow = i % 2 == 1;

                for (var j = 0; j < 8; ++j)
                {
                    if ((blackFirstRow && (j % 2 == 0)) || (!blackFirstRow && (j % 2 == 1)))
                    {
                        m_board[i,j] = new Tile(ChessColor.Black, i, j);
                    }
                    else
                    {
                        m_board[i,j] = new Tile(ChessColor.White, i, j);
                    }
                }
            }

            ChessColor topColor = isWhiteTop ? ChessColor.White : ChessColor.Black;
            ChessColor bottomColor = isWhiteTop ? ChessColor.Black : ChessColor.White;
            
            m_board[0, 0].SetChessPiece(new Rook(topColor));
            m_board[1, 0].SetChessPiece(new Knight(topColor));
            m_board[2, 0].SetChessPiece(new Bishop(topColor));
            m_board[3, 0].SetChessPiece(new Queen(topColor));
            m_board[4, 0].SetChessPiece(new King(topColor));
            m_board[5, 0].SetChessPiece(new Bishop(topColor));
            m_board[6, 0].SetChessPiece(new Knight(topColor));
            m_board[7, 0].SetChessPiece(new Rook(topColor));

            for (var i = 0; i < 8; ++i)
            {
                m_board[i, 1].SetChessPiece(new Pawn(topColor));
            }

            for (var i = 0; i < 8; ++i)
            {
                m_board[i, 6].SetChessPiece(new Pawn(bottomColor));
            }

            m_board[0, 7].SetChessPiece(new Rook(bottomColor));
            m_board[1, 7].SetChessPiece(new Knight(bottomColor));
            m_board[2, 7].SetChessPiece(new Bishop(bottomColor));
            m_board[3, 7].SetChessPiece(new Queen(bottomColor));
            m_board[4, 7].SetChessPiece(new King(bottomColor));
            m_board[5, 7].SetChessPiece(new Bishop(bottomColor));
            m_board[6, 7].SetChessPiece(new Knight(bottomColor));
            m_board[7, 7].SetChessPiece(new Rook(bottomColor));
        }

        public ChessColor GetBoardColorForSpecificTile(int x, int y)
        {
            if (x < 0 || x > 7)
            {
                return ChessColor.White;
            }
            return m_board[x, y].GetChessColor();
        }

        public ChessPiece GetChessPieceForSpecificTile(int x, int y)
        {
            if(x < 0 || x > 7)
            {
                return null;
            }

            return m_board[x, y].GetChessPiece();
        }

        public Tile GetTileAtPos(int x, int y)
        {
            if (x < 0 || x > 7)
            {
                return null;
            }
            return m_board[x, y];
        }

        public void HandleSelectTile(Tile tile)
        {
            if (m_selectedTile != null)
            {
                if(IsNewSelectionMovable(tile))
                {
                    PerformMove(tile);
                    ClearSelection();
                    return;
                }
                
                ClearSelection();
            }

            if (tile.GetChessPiece() != null && !tile.GetChessPiece().GetColor().Equals(m_activeColor))
            {               
                return;
            }

            m_selectedTile = m_selectedTile == tile ? null : tile;

            if (m_selectedTile != null)
            {
                m_selectedTile.SetSelectionState(true);

                if (m_selectedTile?.GetChessPiece() != null)
                {
                    ApplyMovesetToBoard();
                }
            }
        }

        public Tile GetSelectedTile()
        {
            return m_selectedTile;
        }

        public List<BoardPosition> GetValidMovePositions()
        {
            return m_validMovePositions;
        }

        private void ApplyMovesetToBoard()
        {
            var selectedChessPiece = m_selectedTile.GetChessPiece();
            var moveSet = selectedChessPiece.GetMoveSetFromTile(m_selectedTile, this);

            foreach(BoardPosition boardPos in moveSet.GetMoveSetPositions())
            {
                m_validMovePositions.Add(boardPos);
            }
        }

        private void ClearSelection()
        {
            m_selectedTile.SetSelectionState(false);
            m_validMovePositions.Clear();
        }

        private bool IsNewSelectionMovable(Tile tile)
        {
            var tileBoardPos = tile.GetBoardPosition();
            var tileX = tileBoardPos.X;
            var tileY = tileBoardPos.Y;

            foreach (BoardPosition pos in m_validMovePositions)
            {
                if(pos.X == tileX && pos.Y == tileY)
                {
                    return true;
                }
            }
            return false;
        }

        private void PerformMove(Tile tile)
        {
            var chessPieceToMove = m_selectedTile.GetChessPiece();
            var previousChessPieceOnNewTile = tile.GetChessPiece();

            m_selectedTile.SetChessPiece(null);

            tile.SetChessPiece(chessPieceToMove);

            var moveInformation = new Move(new BoardPosition(m_selectedTile.GetBoardPosition().X, m_selectedTile.GetBoardPosition().Y),
                new BoardPosition(tile.GetBoardPosition().X, tile.GetBoardPosition().Y));

            chessPieceToMove.Move(moveInformation);

            if (previousChessPieceOnNewTile != null)
            {

            }

            if(m_activeColor.Equals(ChessColor.White))
            {
                m_whiteHistory.AddMove(moveInformation);
                m_activeColor = ChessColor.Black;
            }
            else
            {
                m_blackHistory.AddMove(moveInformation);
                m_activeColor = ChessColor.White;
            }
        }
    }
}
