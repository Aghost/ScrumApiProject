using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScrumBoard.Services;
using ScrumBoard.Data;

namespace ScrumBoard.Web.Controllers
{
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly ILogger<BoardsController> _logger;
        private readonly IBoardService _boardService;

        public BoardsController(ILogger<BoardsController> logger, IBoardService boardService) {
            _logger = logger;
            _boardService = boardService;
        }

        [HttpGet("/api/Boards")]
        public ActionResult GetBoards() {
            var boards = _boardService.GetAllBoards();
            return Ok(boards);
        }

        [HttpGet("/api/test")]
        public ActionResult Testing() {
            var boards = "i am the boards";
            return Ok(boards);
        }
    }
}
