using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Onion_Architecture.Core.DomainModels;
using Onion_Architecture.Core.DomainRepositories.Dto;
using Onion_Architecture.Core.Exceptions;
using Onion_Architecture.Core.Services;

namespace Onion_Architecture.Infractructure.Controllers.Http
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(UsersService usersService) : ControllerBase
    {
        private readonly UsersService usersService = usersService;

        [HttpGet]
        public async Task<IEnumerable<User?>> GetAll()
        {
            return await usersService.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            try
            {
                var user = await usersService.GetById(id);

                return Ok(user);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(CreateUserDto userDto)
        {
            if (userDto == null) return BadRequest();

            var newUser = await usersService.Create(userDto);

            return newUser == null
                       ? ValidationProblem()
                       : Ok(newUser);
        }

        [HttpPut]
        public async Task<ActionResult<User>> Change(User user)
        {
            if (user == null) return BadRequest();

            try
            {
                await usersService.Change(user);

                return Ok(user);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            try
            {
                var user = await usersService.Delete(id);
                return Ok(user);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
