
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
    public class POLineRepository : IPODetail

    {

        private InventoryContext _context;

        public POLineRepository(InventoryContext context)
        {
            _context = context;
        }

        public async Task<int> AddDetailLine(PODetails detail)
        {
            int idDetail = 0;

            try
            {
                if (_context != null)
                {
                    await _context.PODetail.AddAsync(detail);
                    await _context.SaveChangesAsync();
                    idDetail = detail.idPODetails;
                    return idDetail ;
                }
            }
            catch (Exception)
            {
              
            }

            return idDetail;
        }

        public async Task<int> DeleteDetailLine(int idOrdenDetalle)
        {
            int result = 0;

            if (_context != null)
            {
                var poLine = await _context.PODetail.FirstOrDefaultAsync(x => x.idPODetails == idOrdenDetalle);

                if (poLine != null)
                {
                    _context.PODetail.Remove(poLine);
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }

            return result;

        }

        public async Task<List<PoDetailTable>> GetDetailByOrder(int idOrden)
        {
            List<PoDetailTable> listaTablaDetalle = new List<PoDetailTable>();

            try
            {
                if (idOrden > 0)
                {
                    var listaDetalle = await (from ph in _context.POHeader
                                              join pl in _context.PODetail on ph.idPO equals pl.POHeaderidPo
                                              join i in _context.itemCatalog on pl.ItemidItem equals i.idItem
                                              where ph.idPO == idOrden
                                              select new
                                              {
                                                pl.idPODetails
                                               ,pl.Quantiy
                                               ,i.description
                                               ,pl.Price
                                               ,ph.idPO

                                              }).ToListAsync();

                if (listaDetalle != null)
                    {
                        foreach (var item in listaDetalle)
                        {
                            PoDetailTable tabla = new PoDetailTable();
                            tabla.idPoDetails = item.idPODetails;
                            tabla.idPo = item.idPO;
                            tabla.description = item.description;
                            tabla.price = item.Price;
                            tabla.quantity = item.Quantiy;
                            listaTablaDetalle.Add(tabla);
                        }

                        return listaTablaDetalle;
                    }

                }
            }
            catch (Exception e)
            {
                string message = e.Message;
            }

            return null;

        }

        public async Task UpdateDetailLine(PODetails detail)
        {
            if (_context != null)
            {
                _context.PODetail.Update(detail);
                await _context.SaveChangesAsync();
            }
        }
    }
}

