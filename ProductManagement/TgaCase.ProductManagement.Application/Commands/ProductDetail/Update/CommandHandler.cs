using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TgaCase.ProductManagement.Domain;
using TgaCase.SharedKernel.SeedWork.Repository;

namespace TgaCase.ProductManagement.Application.Commands.ProductDetail.Update
{
    public class CommandHandler : IRequestHandler<Command,bool>
    {
        private IUnitOfWorkFactory<IProductManagementDbContext> _unitOfWork;
        public CommandHandler(IUnitOfWorkFactory<IProductManagementDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            using (var uow = _unitOfWork.Create(true, true))
            {
                var productUpdate = await uow.Context.MAIN.Product.UpdateAsync(
                    new Domain.Schemas.MAIN.ProductAggregates.Product
                    {
                        Id = request.Id,
                        Name = request.Name,
                        UserId = request.UserId,
                        CategoryId = request.CategoryId
                    });
                var productDetail = await uow.Context.MAIN.ProductDetail.GetByProductId(request.Id);
                var productDetailInsert =
                    await uow.Context.MAIN.ProductDetail.InsertAsync(
                        new Domain.Schemas.MAIN.ProductDetailAggregates.ProductDetail
                        {
                            ProductId = request.Id,
                            SalesPrice = request.SalesPrice,
                            PurchasePrice = request.PurchasePrice,
                            Quantity = request.Quantity,
                            UpdatedDate = DateTime.Now,
                            Version = productDetail.Version++
                        });
                uow.CommitTransaction();
                return true;
            }
        }
    }
}