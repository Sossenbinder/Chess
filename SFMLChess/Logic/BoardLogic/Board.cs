﻿using System.Collections.Generic;
using SFMLChess.ChessPieces;

namespace SFMLChess.Logic.BoardLogic
{
    public class Board
    {
        private Tile m_selectedTile;

        private Tile[,] m_board;

        private List<BoardPosition> m_validMovePositions = new List<BoardPosition>();
        
        public Board()
        {
            ResetBoard();
        }

        private void ResetBoard(bool isWhiteTop = false)
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
                m_board[i, 6].SetChessPiece(new Pawn(topColor));
                //m_board[i, 6].SetChessPiece(new Pawn(bottomColor));                
            }

            m_board[5, 4].SetChessPiece(new Knight(bottomColor));

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
            return m_board[x, y].GetChessColor();
        }

        public ChessPiece GetChessPieceForSpecificTile(int x, int y)
        {
            return m_board[x, y].GetChessPiece();
        }

        public Tile GetTileAtPos(int x, int y)
        {
            return m_board[x, y];
        }

        public void HandleSelectTile(Tile tile)
        {
            if (m_selectedTile != null)
            {
                m_selectedTile.SetSelectionState(false);
                m_validMovePositions.Clear();
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

        private void ApplyMovesetToBoard()
        {
            var selectedChessPiece = m_selectedTile.GetChessPiece();
            var moveSet = selectedChessPiece.GetMoveSetFromTile(m_selectedTile, this);

            foreach(BoardPosition boardPos in moveSet.GetMoveSetPositions())
            {
                m_validMovePositions.Add(boardPos);
            }
        }

        public List<BoardPosition> GetValidMovePositions()
        {
            return m_validMovePositions;
        }
    }
}
