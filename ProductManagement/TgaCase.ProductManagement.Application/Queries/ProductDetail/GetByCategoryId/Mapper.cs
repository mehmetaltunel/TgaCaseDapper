using AutoMapper;
using TgaCase.SharedKernel.Extensions;

namespace TgaCase.ProductManagement.Application.Queries.ProductDetail.GetByCategoryId
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Domain.Schemas.MAIN.ProductDetailAggregates.ProductDetailGetBtCategoryId, ProductGetByCategoryIdDto>().ForMember(dest => dest.SalesPrice, opt=>opt.MapFrom(src=> src.SalesPrice.ToTurkishCurrency()));
            //            CreateMap<Domain.Schemas.MAIN.CommentsAggregates.Comments, Comments>().ForMember(dest => dest.SentimentAnalysis, opt=> opt.MapFrom(src => SentimentAnalysis.Analiysis(src.Comment)));

        }
    }
}