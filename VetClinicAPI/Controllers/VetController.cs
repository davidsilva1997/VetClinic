using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetClinicAPI.Repositories.Vet;

namespace VetClinicAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VetController : Controller
    {
        private readonly IVetRepository vetRepository;
        private readonly IMapper mapper;

        public VetController(IVetRepository vetRepository, IMapper mapper)
        {
            this.vetRepository = vetRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVetsAsync()
        {
            var vets = await vetRepository.GetAllAsync();

            var vetsDTO = mapper.Map<IEnumerable<Models.DTO.Vet>>(vets);

            return Ok(vetsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetVetAsync")]
        public async Task<IActionResult> GetVetAsync([FromRoute] Guid id)
        {
            var vet = await vetRepository.GetAsync(id);

            if (vet is null)
            {
                return NotFound();
            }

            var vetDTO = mapper.Map<Models.DTO.Vet>(vet);

            return Ok(vetDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddVetAsync([FromBody] Models.DTO.Vet newVet)
        {
            Models.Vet vet = new Models.Vet()
            {
                FirstName = newVet.FirstName,
                LastName = newVet.LastName,
                Email = newVet.Email,
                Birthday = newVet.Birthday
            };

            vet = await vetRepository.AddAsync(vet);

            var vetDTO = mapper.Map<Models.DTO.Vet>(vet);

            return CreatedAtAction(nameof(GetVetAsync), new {id = vet.Id }, vetDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateVetAsync([FromRoute] Guid id, [FromBody] Models.DTO.Vet vetToUpdate)
        {
            Models.Vet? vet = new Models.Vet()
            {
                FirstName = vetToUpdate.FirstName,
                LastName = vetToUpdate.LastName,
                Email = vetToUpdate.Email,
                Birthday = vetToUpdate.Birthday
            };

            vet = await vetRepository.UpdateAsync(id, vet);

            if (vet is null)
            {
                return NotFound();
            }

            var vetDTO = mapper.Map<Models.DTO.Vet>(vet);

            return Ok(vetDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
        {
            var vet = await vetRepository.RemoveAsync(id);

            if (vet is null)
            {
                return NotFound();
            }

            var vetDTO = mapper.Map<Models.DTO.Vet>(vet);

            return Ok(vetDTO);
        }
    }
}
