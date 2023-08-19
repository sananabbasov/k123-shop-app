using System;
using AutoMapper;
using K123ShopApp.Business.Abstract;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Core.Utilities.Results.Concrete.SuccessResults;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.Entities.Concrete;
using K123ShopApp.Entities.Dtos.SpecificationDtos;

namespace K123ShopApp.Business.Concrete
{
    public class SpecificationManager : ISpecificationService
    {
        private readonly ISpecificationDal _specificationDal;
        private readonly IMapper _mapper;

        public SpecificationManager(ISpecificationDal specificationDal, IMapper mapper)
        {
            _specificationDal = specificationDal;
            _mapper = mapper;
        }

        public IResult CreateSpecifications(int productId, List<SpecificationCreateDto> specifications)
        {
            var mapper = _mapper.Map<List<Specification>>(specifications);
            _specificationDal.AddSpecifications(productId,mapper);
            return new SuccessResult();
        }
    }
}

