using Microsoft.AspNetCore.Mvc;
using RubSort.DataStorageSystem;

namespace RubSort.ApiApplication.Controllers
{
    public class DbController : ControllerBase
    {
        private readonly IEntityRepository<UserDbo> repository;

        public DbController(IEntityRepository<UserDbo> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Home()
        {
            return Ok(repository.Get());
        }
    }
}