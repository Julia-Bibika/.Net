using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly AplicationDBContext _context;
        public CarController(AplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> Get()
        {
            return Ok(await this._context.Dai.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Car>>> AddNewCar(Car car)
        {
            this._context.Dai.Add(car);
            await this._context.SaveChangesAsync();

            return Ok(await this._context.Dai.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Car>>> UpdateCar(Car car)
        {
            this._context.Dai.Update(car);
            await this._context.SaveChangesAsync();

            return Ok(await this._context.Dai.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Car>>> DeleteCar(int id)
        {
            var DBcar = await this._context.Dai.FindAsync(id);
            if (DBcar == null)
            {
                return BadRequest("Value is null");
            }
            this._context.Dai.Remove(DBcar);
            await this._context.SaveChangesAsync();
            return Ok(await this._context.Dai.ToListAsync());
        }
    }
}
