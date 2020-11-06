using Microsoft.AspNetCore.Mvc;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.Repository.ExpenseRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            this._expenseRepository = expenseRepository;
        }

        // GET: api/expense
        [HttpGet("getExpensesByGroupId/{groupId}")]
        public async Task<ActionResult<IEnumerable<ExpenseAC>>> GetexpensesByGroupId([FromRoute] int groupId)
        {
            return Ok(await this._expenseRepository.GetExpensesByGroupId(groupId));
        }
        // GET: api/expense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseAC>> GetExpense([FromRoute] int id)
        {
            var expense = await this._expenseRepository.GetExpense(id);

            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        // PUT: api/ExpensesApi/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ExpenseAC>> PutExpense(int id, ExpenseAC expense)
        {
            try
            {
                expense.ExpenseId = id;
                await this._expenseRepository.UpdateExpense(expense);

            }
            catch (Exception)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(expense);
        }

        // POST: api/expense
        [HttpPost]
        public async Task<ActionResult<ExpenseAC>> PostExpense(ExpenseAC expense)
        {
            if (ModelState.IsValid)
            {
                var result = await this._expenseRepository.AddExpense(expense);
                return Ok(result);
            }
            return BadRequest();
        }

        // DELETE: api/Expense/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteExpense(int id)
        {
            //var Expense = await _context.depatments.FindAsync(id);
            if (this.ExpenseExists(id))
            {
                await _expenseRepository.DeleteExpense(id);
                return Ok(id);
            }
            return NotFound();
        }

        private bool ExpenseExists(int id)
        {
            return _expenseRepository.ExpenseExists(id);
        }
    }
}
