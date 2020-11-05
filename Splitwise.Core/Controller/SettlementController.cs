using Microsoft.AspNetCore.Mvc;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.Repository.SettlementRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettlementController : ControllerBase
    {
        private readonly ISettlementRepository _settlementRepository;

        public SettlementController(ISettlementRepository settlementRepository)
        {
            this._settlementRepository = settlementRepository;
        }

        // GET: api/settlement
        [HttpGet]
        public async Task<IEnumerable<SettlementAC>> Getsettlements()
        {
            return await this._settlementRepository.GetSettlements();
        }
        // GET: api/settlement/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSettlement([FromRoute] int id)
        {
            var settlement = await this._settlementRepository.GetSettlement(id);

            if (settlement == null)
            {
                return NotFound();
            }

            return Ok(settlement);
        }
        // GET: api/settlement/5
        [HttpGet("bygroupid/{groupid}")]
        public async Task<IActionResult> GetSettlementsByGroupId([FromRoute] int groupid)
        {
            var settlement = await this._settlementRepository.GetSettlementsByGroupId(groupid);

            if (settlement == null)
            {
                return NotFound();
            }

            return Ok(settlement);
        }
        // GET: api/settlement/byexpenseid/2
        [HttpGet("byexpenseid/{expenseid}")]
        public async Task<IActionResult> GetSettlementsByExpenseId([FromRoute] int expenseid)
        {
            var settlement = await this._settlementRepository.GetSettlementsByExpenseId(expenseid);

            if (settlement == null)
            {
                return NotFound();
            }

            return Ok(settlement);
        }

        // PUT: api/SettlementsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSettlement(int id, SettlementAC settlement)
        {
            try
            {
                settlement.SettlementId = id;
                await this._settlementRepository.UpdateSettlement(id, settlement);

            }
            catch (Exception)
            {
                if (!SettlementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(settlement);
        }

        // POST: api/settlement
        [HttpPost]
        public async Task<ActionResult<SettlementAC>> PostSettlement(SettlementAC settlement)
        {
            if (ModelState.IsValid)
            {
                await this._settlementRepository.AddSettlement(settlement);
                return Ok(settlement);
            }
            return BadRequest();
        }

        // DELETE: api/SettlementsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SettlementAC>> DeleteSettlement(int id)
        {
            //var Settlement = await _context.depatments.FindAsync(id);
            if (this.SettlementExists(id))
            {
                await _settlementRepository.DeleteSettlement(id);
                return Ok(id);
            }
            return NotFound();
        }

        private bool SettlementExists(int id)
        {
            return _settlementRepository.SettlementExists(id);
        }
    }
}