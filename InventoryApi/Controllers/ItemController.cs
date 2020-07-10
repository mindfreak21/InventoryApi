using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryApi.Context;
using InventoryApi.Interfaces;
using InventoryApi.Models;
using InventoryApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        ICatalogItem catalogItem;

        public ItemController(ICatalogItem _catalogItem)
        {
            catalogItem = _catalogItem;
        }

        [HttpGet]
        [Route("GetItems")]
        public async Task<IActionResult> GetItems()
        {
            var items = await catalogItem.GetItems();

            try
            {

                if (items == null)
                {
                    return NotFound();
                }



            } catch (Exception)
            {
                BadRequest();
            }

            return Ok(items);

        }

        [HttpGet("{id}")]
        [Route("GetItems")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await catalogItem.GetItemById(id);

            if (item == null)
            {
                BadRequest(0);
            }

            return Ok(item);
        }


        [HttpPost]
        [Route("AddItem")]
        [Authorize(Roles = "Administrador")]

        public async Task<IActionResult> AddItem([FromBody]Item model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var itemId = await catalogItem.AddItem(model);

                    if (itemId > 0)
                    {
                        return Ok(itemId);
                    } else
                    {
                        return NotFound();
                    }

                } catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateItem")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> updateItem([FromBody]Item model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await catalogItem.UpdateItem(model);

                    return Ok();

                } catch (Exception ex)
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
        [Route("DeleteItem")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await catalogItem.DeleteItem(id);

                if (result == 0)
                {
                    return NotFound();
                }

                return Ok();

            } catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
