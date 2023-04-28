using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Paviza_Zapocet.Data;
using Paviza_Zapocet.Data.Model;
using Paviza_Zapocet.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Paviza_Zapocet.Services
{

    public class ClientDataService : MasterService, IClientDataService
    {
        public ClientDataService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<ClientDataExport> GetClientData() {

            List<ClientDataExport> clientDataExports = new List<ClientDataExport>();

            var headers = _context.PurchaseOrderHeaders.ToList();
            foreach (var header in headers) {

                double totalPrice = 0;
                var purchaseOrder = _context.PurchaseOrderItems.SingleOrDefault(x => x.PurchaserOrderId == header.Id);
                if (purchaseOrder != null)
                {
                    totalPrice = purchaseOrder.Amount * purchaseOrder.PricePerUnit;
                }

                clientDataExports.Add(new ClientDataExport(header, totalPrice));
            }

            return clientDataExports;
        }

        public ClientDataResponseDto AddClientData(List<ClientDataDto> clientDataDto) {

            ClientDataResponseDto responseDto = new ClientDataResponseDto();

            foreach (var dataRow in clientDataDto)
            {

                if (_context.PurchaseOrderHeaders.Any(x => x.PoNumber == dataRow.poid))
                {
                    responseDto.FailedCount++;
                    responseDto.FailedListPoid.Add(dataRow.poid);
                    responseDto.Message = "Duplicate POIDs!";
                    continue;
                }

                var purchaseOrderHeaders = new PurchaseOrderHeaders()
                {
                    PoNumber = dataRow.poid,
                    CustomerName = dataRow.first_name,
                    CustomerLastName = dataRow.last_name,
                    CreatedOn = DateTime.ParseExact(dataRow.createdon, "M/dd/yyyy", CultureInfo.InvariantCulture),
                    CustomerEmail = dataRow.email
                };

                _context.PurchaseOrderHeaders.Add(purchaseOrderHeaders);
                _context.SaveChanges();

                var purchaseOrderItems = new PurchaseOrderItems()
                {
                    PurchaserOrderId = purchaseOrderHeaders.Id,
                    ShopItemTitle = dataRow.item,
                    Amount = dataRow.amount,
                    PricePerUnit = dataRow.price
                };

                responseDto.SuccessCount++;
                responseDto.SuccessListPoid.Add(dataRow.poid);

                _context.PurchaseOrderItems.Add(purchaseOrderItems);
                _context.SaveChanges();
            }

            return responseDto;
        }

    }
}
