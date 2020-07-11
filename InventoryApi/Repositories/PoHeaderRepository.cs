using InventoryApi.Context;
using InventoryApi.Interfaces;
using InventoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Repositories
{
    public class PoHeaderRepository : IPOHeader
    {
        InventoryContext _context;

        public PoHeaderRepository(InventoryContext context)
        {
            _context = context;
        }

        public async Task<int> AddPOHeader(POHeader header)
        {
            int identityItem;

            if (_context != null)
            {
                await _context.POHeader.AddAsync(header);
                await _context.SaveChangesAsync();

                identityItem = header.idPO;

                return identityItem;
            }

            return 0;
        }


        public async Task<int> DeletePOHeader(int id)
        {
            int result = 0;

            if (_context != null)
            {
                var poHeader = await _context.POHeader.FirstOrDefaultAsync(x => x.idPO == id);

                if (poHeader != null)
                {
                    _context.POHeader.Remove(poHeader);
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }

            return result;
        }

        public async Task<HearderTable> GetPOHeaderById(int id)
        {
            HearderTable headerTable = new HearderTable();

            if (id > 0)
            {
                var headerList = await (from h in _context.POHeader
                                        join c in _context.customerCatalog on h.CustomeridCustomer equals c.idCustomer
                                        join s in _context.statusOrder on h.StatusPurchaseOrderidStatus equals s.idStatus
                                        where h.idPO == id
                                        select new
                                        {
                                            h.idPO
                                           ,
                                            c.CustomerName
                                           ,
                                            s.StatusName
                                           ,
                                            h.OrderDate
                                        }).ToListAsync();

                if (headerList != null)
                {
                    foreach (var item in headerList)
                    {
                        headerTable.idPo = item.idPO;
                        headerTable.Customer = item.CustomerName;
                        headerTable.Status = item.StatusName;
                        headerTable.OrderDate = item.OrderDate;
                       
                    }
                }

                return headerTable;
            }
            return null;
        }

        public async Task<List<HearderTable>> GetPOHeaders()
        {
            List<HearderTable> listaHeader = new List<HearderTable>();
          
            if (_context != null)
            {
               var  headerList = await (from h in _context.POHeader
                                    join c in _context.customerCatalog on h.CustomeridCustomer equals c.idCustomer
                                    join s in _context.statusOrder on h.StatusPurchaseOrderidStatus equals s.idStatus
                                    select new
                                    {
                                        h.idPO
                                       ,
                                        c.CustomerName
                                       ,
                                        s.StatusName
                                       ,
                                        h.OrderDate
                                    }).ToListAsync();
                                   
                if (headerList != null)
                {
                    foreach (var item in headerList)
                    {
                        HearderTable headerTable = new HearderTable();

                        headerTable.idPo = item.idPO;
                        headerTable.Customer = item.CustomerName;
                        headerTable.Status = item.StatusName;
                        headerTable.OrderDate = item.OrderDate;
                        listaHeader.Add(headerTable);
                    }
                }

                return listaHeader;
            }

            return null;
        }

        public async Task UpdatePOHeader(POHeader header)
        {
            if (_context != null)
            {
                _context.POHeader.Update(header);
                await _context.SaveChangesAsync();
            }

        }
    }
}
