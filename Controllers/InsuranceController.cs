using Microsoft.AspNetCore.Mvc;
using CSharpCode.DTO;
using CSharpCode.Data;
using CSharpCode.Models;
using CSharpCode.Services;

namespace CSharpCode.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public InsuranceController(ApplicationDbContext context)
        {
            _context = context;
        }
            
        /*private readonly ApplicationDbContext _context = context;*/

        // Calculate Insurance API Endpoint
        [HttpPost("calculate")]
        public async Task<IActionResult> CalculateInsurance([FromBody] InsuranceData data)
        {
            // Validate the incoming data
            if (data == null || data.Age <= 0 || data.InsurancePlan <= 0 || data.Income <= 0)
            {
                return BadRequest("Invalid data provided.");
            }

            // Base cost for insurance and months based on insurance plan duration
            int baseCost = 1500;
            int months = data.InsurancePlan * 12;

            // Call FinanceService to calculate insurance amount and tax
            int insuranceAmount = FinanceService.Insurance(data.Age, baseCost, months);
            double tax = FinanceService.CalculateTax(data.Income);

            // Save the calculated data into the database
            data.Amount = insuranceAmount;
            _context.InsuranceApplications.Add(data);
            _context.SaveChanges();

            // Return calculated values as response
            return Ok(new
            {
                insuranceAmount = insuranceAmount,
                taxAmount = tax
            });
        }
    }
}
