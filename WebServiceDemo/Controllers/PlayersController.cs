﻿using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebServiceDemo.Entities;
using WebServiceDemo.Repositories;

namespace WebServiceDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : Controller
    {
        private readonly IPlayerRepository _playerRepo;

        public PlayersController(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        [HttpGet]
        public IEnumerable<Player> GetPlayers([FromQuery] string firstName, [FromQuery] string lastName)
        {
            return _playerRepo.GetPlayers(firstName, lastName);
        }

        [HttpGet]
        [Route("{playerId}")]
        public IActionResult GetPlayer(int playerId)
        {
            var player = _playerRepo.GetPlayer(playerId);

            return player != null ? Ok(player) : NotFound();
        }
    }
}
