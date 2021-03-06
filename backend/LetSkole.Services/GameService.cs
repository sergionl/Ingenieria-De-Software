using LetSkole.DataAccess;
using LetSkole.Dto;
using LetSkole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetSkole.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<GameDto>> GetCollection(string filter)
        {
            var Collection =  await _repository.GetCollection(filter ?? string.Empty);
            return Collection.Select(c => new GameDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Link = c.Link,

            }).ToList();
        }

        public async Task<GameDto> GetItem(int id)
        {
            Game game = await _repository.GetItem(id);
            GameDto gameDto = new GameDto();

            gameDto.Id = game.Id;
            gameDto.Name = game.Name;
            gameDto.Description = game.Description;
            gameDto.Link = game.Link;


            return gameDto;
        }

    }
}
