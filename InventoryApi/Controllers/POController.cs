using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryApi.Interfaces;
using InventoryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POController : ControllerBase
    {
        IPOHeader PoHeader;

        public POController(IPOHeader _PoHeader)
        {
            PoHeader = _PoHeader;
        }


        [HttpGet]
        [Route("GetHeader")]
        public async Task<IActionResult> GetHeaders()
        {
            var headers = await PoHeader.GetPOHeaders();

            try
            {
                if (headers == null)
                {
                    return NotFound();
                }

            } catch (Exception)
            {
                BadRequest();
            }


            return Ok(headers);
        }

        [HttpGet]
        [Route("GetHeaderById")]
        public async Task<IActionResult> GetHeaderById(int id)
        {
            var headers = await PoHeader.GetPOHeaderById(id);

            try
            {
                if (headers == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                BadRequest();
            }


            return Ok(headers);
        }


        [HttpPost]
        [Route("AddPo")]
        public async Task<IActionResult> AddPO([FromBody]POHeader header)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var headerId = await PoHeader.AddPOHeader(header);

                    if (headerId > 0)
                    {
                        return Ok(headerId);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();

        }


        [HttpPut]
        [Route("UpdatePO")]
        public async Task<IActionResult> UpdatePO([FromBody]POHeader header)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await PoHeader.UpdatePOHeader(header);

                    return Ok();

                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeletePO")]
        public async Task<IActionResult> DeletePO(int id)
        {
            int result = 0;

            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                result = await PoHeader.DeletePOHeader(id);

                if (result == 0)
                {
                    return NotFound();
                }

                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
