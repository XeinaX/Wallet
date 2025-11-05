using CryptoSim.Data.DTO;
using CryptoSim.Models;
using CryptoSim.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoSim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class WalletController  : ControllerBase
    {
        private readonly WalletService _walletService;
        
        public WalletController(WalletService walletService)
        {
            _walletService = walletService;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var wallet = _walletService.GetWalletById(id);
            if (wallet == null)
            {
                return NotFound();
            }
            return Ok(wallet);
        }
        
        [HttpGet]
        public IActionResult GetAllWallets()
        {
            return Ok(_walletService.GetAllWallets());
        }

        [HttpPost]
        public IActionResult CreateWallet(WalletCreateModel model)
        {
            var wallet = _walletService.CreateWallet(model.WalletName);
            
            return CreatedAtAction(nameof(GetById), new { id = wallet.Id }, wallet);
        }

        [HttpPut("{id}/balance")]
        public IActionResult UpdateWalletBalance(Guid id, [FromBody]decimal newBalance)
        {
            var wallet = _walletService.UpdateWalletBalanceById(id, newBalance);
            if (wallet == null)
            {
                return NotFound("Wallet not found");
            }

            return Ok(wallet);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWallet(Guid id)
        {
            var success = _walletService.DeleteWalletById(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
