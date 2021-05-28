using System;
using System.Linq;
using System.Collections.Generic;
using ScrumBoard.Data;
using ScrumBoard.Data.Models;

namespace ScrumBoard.Services
{
    public class BoardService : IBoardService
    {
        private readonly ScrumBoardDbContext _db;

        public BoardService(ScrumBoardDbContext db) {
            _db = db;
        }

        public List<Board> GetAllBoards() {
            return _db.Boards.ToList();
        }

        public Board GetBoard(int Id) {
            //OR var Board = _db.Boards.FirstOrDefault(board => board.Id == Id);
            return _db.Boards.Find(Id);
        }

        public void AddBoard(Board board) {
            _db.Add(board);
            _db.SaveChanges();
        }

        public void DeleteBoard(int Id) {
            var boardToDelete = _db.Boards.Find(Id);
            if (boardToDelete != null) {
                _db.Remove(boardToDelete);
            }
            throw new InvalidOperationException("no boards exists");
        }
    }
}
