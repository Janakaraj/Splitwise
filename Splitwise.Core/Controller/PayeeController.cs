using Microsoft.AspNetCore.Mvc;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.Repository.PayeeRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayeeController : ControllerBase
    {
        private readonly IPayeeRepository _payeeRepository;

        public PayeeController(IPayeeRepository payeeRepository)
        {
            this._payeeRepository = payeeRepository;
        }

        // GET: api/payee/payeebyexpenseid/2
        [HttpGet("payeeByExpenseId/{expenseId}")]
        public async Task<ActionResult<IEnumerable<PayeeAC>>> GetPayeesByExpenseId(int expenseId)
        {
            return Ok(await this._payeeRepository.GetPayeesByExpenseId(expenseId));
        }

        // GET: api/payee/expensebypayeeid/{payeeId}
        [HttpGet("expenseByPayeeId/{payeeId}")]
        public async Task<ActionResult<IEnumerable<PayeeAC>>> GetExpensesByPayeeId(string payeeId)
        {
            return Ok(await this._payeeRepository.GetExpensesByPayeeId(payeeId));
        }

        // PUT: api/PayeesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayee(string payeeid, int expenseid, PayeeAC payee)
        {
            try
            {
                payee.PayeeId = payeeid;
                await this._payeeRepository.UpdatePayee(payeeid,expenseid,payee);

            }
            catch (Exception)
            {
                if (!PayeeExists(payeeid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(payee);
        }

        // POST: api/payee
        [HttpPost]
        public async Task<ActionResult<PayeeAC>> PostPayee(PayeeAC payee)
        {
            if (ModelState.IsValid)
            {
                await this._payeeRepository.AddPayee(payee);
                return Ok(payee);
            }
            return BadRequest();
        }

        // DELETE: api/PayeesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PayeeAC>> DeletePayee(string id)
        {
            if (this.PayeeExists(id))
            {
                await _payeeRepository.DeletePayee(id);
                return Ok(id);
            }
            return NotFound();
        }

        private bool PayeeExists(string id)
        {
            return _payeeRepository.PayeeExists(id);
        }
    }
}
