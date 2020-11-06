using Microsoft.AspNetCore.Mvc;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.Repository.PayerRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayerController : ControllerBase
    {
        private readonly IPayerRepository _payerRepository;

        public PayerController(IPayerRepository payerRepository)
        {
            this._payerRepository = payerRepository;
        }

        // GET: api/payer/payerbyexpenseid/2
        [HttpGet("payersByExpenseId/{expenseId}")]
        public async Task<ActionResult<IEnumerable<PayerAC>>> GetPayersByExpenseId(int expenseId)
        {
            return Ok(await this._payerRepository.GetPayersByExpenseId(expenseId));
        }

        // GET: api/payer/expensebypayerid/{payerId}
        [HttpGet("expensesByPayerId/{payerId}")]
        public async Task<ActionResult<IEnumerable<ExpenseAC>>> GetExpensesByPayerId(string payerId)
        {
            return Ok(await this._payerRepository.GetExpensesByPayerId(payerId));
        }

        // PUT: api/PayersApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayer(string payerid, int expenseid, PayerAC payer)
        {
            try
            {
                payer.PayerId = payerid;
                await this._payerRepository.UpdatePayer(payerid, expenseid, payer);

            }
            catch (Exception)
            {
                if (!PayerExists(payerid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(payer);
        }

        // POST: api/payer
        [HttpPost]
        public async Task<ActionResult<PayerAC>> PostPayer(PayerAC payer)
        {
            if (ModelState.IsValid)
            {
                await this._payerRepository.AddPayer(payer);
                return Ok(payer);
            }
            return BadRequest();
        }

        // DELETE: api/PayersApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PayerAC>> DeletePayer(string id)
        {
            if (this.PayerExists(id))
            {
                await _payerRepository.DeletePayer(id);
                return Ok(id);
            }
            return NotFound();
        }

        private bool PayerExists(string id)
        {
            return _payerRepository.PayerExists(id);
        }
    }
}
