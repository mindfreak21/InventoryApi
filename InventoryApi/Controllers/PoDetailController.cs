using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using InventoryApi.Interfaces;
using InventoryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoDetailController : ControllerBase
    {
        IPODetail poDetail;

        public PoDetailController(IPODetail _poDetail)
        {
            poDetail = _poDetail;
        }

     [HttpGet]
     [Route("GetLines")]
     public async Task<IActionResult> GetLines(int idPo)
        {
            var lines = await poDetail.GetDetailByOrder(idPo);

            try
            {
                if (lines == null)
                {
                    return NotFound();
                }

            } catch (Exception)
            {
                NotFound();
            }

            return Ok(lines);
        }

        [HttpPost]
        [Route("AddPoDetail")]
        public async Task<IActionResult> AddPODetail([FromBody] PODetails detail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var detailId = await poDetail.AddDetailLine(detail);

                    if (detailId > 0)
                    {
                        return Ok(detailId);
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


        [HttpDelete]
        [Route("DeletePODetail")]
        public async Task<IActionResult> DeletePODetail(int id)
        {
            int result = 0;

            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                result = await poDetail.DeleteDetailLine(id);

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
