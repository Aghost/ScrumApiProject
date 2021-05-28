using System.Collections.Generic;
using ScrumBoard.Data;
using ScrumBoard.Data.Models;

namespace ScrumBoard.Services {
    public interface IBoardService {
        public List<Board> GetAllBoards();
        public Board GetBoard(int Id);
        public void AddBoard(Board board);
        public void DeleteBoard(int Id);
    }
}
