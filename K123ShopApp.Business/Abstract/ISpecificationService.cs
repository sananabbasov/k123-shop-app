using System;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Entities.Dtos.SpecificationDtos;

namespace K123ShopApp.Business.Abstract
{
    public interface ISpecificationService
    {
        IResult CreateSpecifications(int productId, List<SpecificationCreateDto> specifications);

    }
}

