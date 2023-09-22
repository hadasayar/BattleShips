using BattleShipGame.Models;
using BattleShipGame.Services;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameManagerService _gameManager;

        public GameController(GameManagerService gameManager)
        {
            _gameManager = gameManager;
        }

        [HttpPost("newplayer")]
        public IActionResult NewPlayer()
        {
            var playerId = _gameManager.NewPlayer();
            if (playerId != Guid.Empty)
            {
                return Ok(playerId);
            }
            else
            {
                return BadRequest("Maximum number of players reached.");
            }
        }

        [HttpGet("myboard")]
        public IActionResult GetMyBoard(Guid playerId)
        {
            var board = _gameManager.GetMyBoard(playerId);
            if (board != null)
            {
                string boardString = board.GetBoardAsString();
                CellState[,] BattleField = board.BattleField;
                return Ok(boardString);
            }
            else
            {
                return NotFound("Player not found.");
            }
        }

        [HttpGet("oppboard")]
        public IActionResult GetOppBoard(Guid playerId)
        {
            var board = _gameManager.GetOppBoard(playerId);
            if (board != null)
            {
                string boardString = board.GetBoardAsString();
                return Ok(boardString);
            }
            else
            {
                return NotFound("Player not found.");
            }
        }

        [HttpGet("isgameover")]
        public IActionResult IsGameOver()
        {
            var isGameOver = _gameManager.IsGameOver();
            return Ok(isGameOver);
        }

        [HttpGet("isplayersready")]
        public IActionResult IsPlayersReady()
        {
            var isGameOver = _gameManager.IsPlayersReady();
            return Ok(isGameOver);
        }


        [HttpPost("makemove")]
        public IActionResult MakeMove( int i, int j, Guid playerId)
        {
            (int, int) cell = (i, j);   
            var moveResult = _gameManager.MakeMove(cell, playerId);
            return Ok(moveResult);
        }

        [HttpGet("whosturn")]
        public IActionResult WhosTurn()
        {
            Guid playerThatCanPlay = _gameManager.WhosTurn();
            return Ok(playerThatCanPlay);
        }

    } 
    }