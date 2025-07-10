using Inventory.Entities;
using Inventory.Persistence;
using MediatR;

namespace Inventory.Modules.Sales.Command.CreateSale
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateSaleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var createCommand = new SaleMaster()
                {
                    SaleDate = DateTime.Now,
                    CustomerId = request.CustomerId,
                    TotalAmount = request.TotalAmount,
                    PaidAmount = request.PaidAmount,
                    DueAmount = request.DueAmount,
                };
                var _createCommand = await _unitOfWork.SaleMasterRepository.AddAsync(createCommand);
                //var response = await _unitOfWork.Save();
                //if (response > 0)
                //{
                if (request.createSalesDetailsCommands.Count > 0)
                {
                    foreach (var item in request.createSalesDetailsCommands)
                    {
                        var checkProductQnt = (await _unitOfWork.ProductRepository.ListAllAsync()).Where(p => p.ProductId == item.ProductId).FirstOrDefault();
                        if (checkProductQnt == null)
                        {
                            return ("Product not found");
                        }
                        else
                        {
                            if (item.Quantity > checkProductQnt.StockQty)
                            {
                                return ("Stock is insufficient");
                            }
                            else
                            {
                                var response = await _unitOfWork.Save();
                                var saleDetails = new SaleDetails()
                                {
                                    SaleMasterId = _createCommand.SaleId,
                                    ProductId = item.ProductId,
                                    Quantity = item.Quantity,
                                    Price = item.Price * item.Quantity,
                                };
                                await _unitOfWork.SaleDetailsRepository.AddAsync(saleDetails);
                                var detailsResponse = await _unitOfWork.Save();
                                if (detailsResponse > 0)
                                {
                                    checkProductQnt.StockQty = checkProductQnt.StockQty - item.Quantity;
                                    await _unitOfWork.ProductRepository.UpdateAsync(checkProductQnt);
                                    await _unitOfWork.Save();
                                }
                            }
                        }

                    }
                    //}
                }
                return ("Sale add Successfully");
            }


            catch (Exception ex)
            {
                return ("Could not sale");
            }
        }
    }
}

