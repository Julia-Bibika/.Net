using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationModule.Controllers
{
    public class Vector1Controller : ControllerBase
    {
        [HttpGet("ex1")]
        public async Task<ActionResult<double>> GetScalar(double[] x, double[] y)
        {
            double[] z = new double[x.Length];

            if (x.Length != y.Length)
            {
                return BadRequest("Вектори повинні мати однаковий розмір.");
            }

            for (int i = 0; i < x.Length; i++)
            {
                z[i] = x[i] * y[i];
            }

            return Ok(z);
        }
        [HttpGet("ex2")]
        public async Task<ActionResult<double>> GetSin(int n, double x)
        {
            if (n < 1)
            {
                return BadRequest(400);
            }
            double result = 0;
            for (int i = 1; i <= n; i++)
            {
                result += Math.Pow(Math.Sin(x), i);
            }
            return Ok(result);
        }
    }
}
