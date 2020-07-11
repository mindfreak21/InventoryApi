
using InventoryApi.Context;
using InventoryApi.Interfaces;
using InventoryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Repositories
{
    public class POLineRepository 
    {

//        private InventoryContext _context;

//        public POLineRepository(InventoryContext context)
//        {
//            _context = context;
//        }

//        public async Task<string> AddDetailLine(PODetails detail)
//        {
//            string message = null;

//            try
//            {
//                if (_context != null)
//                {
//                    await _context.PODetail.AddAsync(detail);
//                    await _context.SaveChangesAsync();
//                    message = "Se ha agregado la linea # " + detail.idPODetails.ToString();
//                    return message;
//                }
//            } catch(Exception e)
//            {
//                message = "Error al procesar la transaccion " + e.Message ;
//            }

//            return message;
//        }

//        public async Task<int> DeleteDetailLine(int idOrdenDetalle)
//        {
//            int result = 0;

//            if (_context != null)
//            {
//                var poLine = await _context.PODetail.FirstOrDefaultAsync(x => x.idPODetails == idOrdenDetalle);

//                if (poLine != null)
//                {
//                    _context.PODetail.Remove(poLine);
//                    result = await _context.SaveChangesAsync();
//                }

//                return result;
//            }

//            return result;

//        }

//        public async Task<AnonymousObject> GetDetailByOrder(int idOrden)
//        {
           

//            try
//            {
//                if (idOrden > 0)
//                {
//                    var listaDetalle = await (from ph in _context.POHeader
//                                              join pl in _context.PODetail on ph.idPO equals pl.POHeaderidPo
//                                              join i in _context.itemCatalog on pl.ItemidItem equals i.idItem
//                                              where ph.idPO == idOrden
//                                              select new
//                                              {
//                                                  i.idItem
//                                                 ,
//                                                  i.description
//                                                 ,
//                                                  i.unitOfMeasure
//                                                 ,
//                                                  pl.Quantiy
//                                                 ,
//                                                  pl.Price
//                                              }).ToListAsync();

                   

//                }
//            } catch (Exception e)
//            {
//                string message = e.Message;   
//            }

//            return null;
        
//        }

//        public async Task UpdateDetailLine(PODetails detail)
//        {
//            if (_context != null)
//            {
//                _context.PODetail.Update(detail);
//                await _context.SaveChangesAsync();
//            }
//        }
    }
}

