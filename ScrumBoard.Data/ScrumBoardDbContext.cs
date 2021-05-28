using ScrumBoard.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ScrumBoard.Data {
    public class ScrumBoardDbContext : DbContext {
        //public ScrumBoardDbContext() { }
        public ScrumBoardDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
    }
}
