using System;
using System.IO;
using AutoMapper;
using K123ShopApp.Business.Abstract;
using K123ShopApp.Core.Utilities.Business;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Core.Utilities.Results.Concrete.ErrorResults;
using K123ShopApp.Core.Utilities.Results.Concrete.SuccessResults;
using K123ShopApp.Core.Utilities.Security.Hashing;
using K123ShopApp.Core.Utilities.Security.Jwt;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.Entities.Concrete;
using K123ShopApp.Entities.Dtos.UserDtos;
using K123ShopApp.Entities.SharedModels;
using MassTransit;

namespace K123ShopApp.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IWishListService _wishListService;
        public AppUserManager(IAppUserDal appUserDal, IMapper mapper, IPublishEndpoint publishEndpoint, IWishListService wishListService)
        {
            _appUserDal = appUserDal;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
            _wishListService = wishListService;
        }

        public IDataResult<UserInfoDto> GetUserInfo(int id)
        {
            var user = _appUserDal.Get(x => x.Id == id);
            var mappingResult = _mapper.Map<UserInfoDto>(user);
            return new SuccessDataResult<UserInfoDto>(mappingResult);
        }

        public IDataResult<UserOrderDto> GetUserOrders(int id)
        {
            var user = _appUserDal.GetUserOrders(id);
            var mapUser = _mapper.Map<UserOrderDto>(user);
            return new SuccessDataResult<UserOrderDto>(mapUser);
        }

        public IResult LoginUser(UserLoginDto userLogin)
        {


            var result = BusinessRule.CheckRules(
                CheckUserByEmail(userLogin.Email),
                CheckUserPassword(userLogin.Email, userLogin.Password),
                ChekLoginAttempt(userLogin.Email)
                );
            var user = _appUserDal.Get(x => x.Email == userLogin.Email);
            if (!result.Success)
            {
                user.LoginAttempt += 1;
                _appUserDal.Update(user);
                return new ErrorResult();
            }

            var token = Token.CreateToken(user, "User");

            return new SuccessResult(token);

        }

        public async Task<IResult> Register(UserRegisterDto userRegister)
        {
            var result = BusinessRule.CheckRules(CheckUserIsExist(userRegister.Email));
            if (!result.Success)
                return new ErrorResult();

            var mappingUser = _mapper.Map<AppUser>(userRegister);
            byte[] passwordHash, passordSalt;
            PasswordHashing.HashPassword(userRegister.Password, out passwordHash, out passordSalt);
            mappingUser.PasswordHash = passwordHash;
            mappingUser.PasswordSalt = passordSalt;
            mappingUser.ConfirmationToken = Guid.NewGuid().ToString();
            _appUserDal.Add(mappingUser);
            SendEmailCommand sendEmail = new();
            sendEmail.Email = userRegister.Email;
            sendEmail.FirstName = userRegister.FirstName;
            sendEmail.LastName = userRegister.LastName;
            sendEmail.Token = mappingUser.ConfirmationToken;
            _publishEndpoint.Publish<SendEmailCommand>(sendEmail);
            return new SuccessResult();
        }

        public IResult VerifyEmail(string email, string verifyToken)
        {
            var user = _appUserDal.Get(x => x.Email == email);

            if (user.ConfirmationToken == verifyToken)
            {
                user.EmailConfirmed = true;
                _appUserDal.Update(user);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<UserWishListDto> GetUserWishListById(int id)
        {
            var user = _appUserDal.Get(x => x.Id == id);
            var mapUser = _mapper.Map<UserWishListDto>(user);
            var wishList = _wishListService.GetUserWishList(id);
            mapUser.WishLists = wishList.Data;

            return new SuccessDataResult<UserWishListDto>(mapUser);
        }


        private IResult CheckUserIsExist(string email)
        {
            var user = _appUserDal.Get(x => x.Email == email);
            if (user is not null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult ChekLoginAttempt(string email)
        {
            var user = _appUserDal.Get(x => x.Email == email);
            if (user.LoginAttempt < 3)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckUserByEmail(string email)
        {
            var user = _appUserDal.Get(x => x.Email == email);
            if (user is null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();

        }


        private IResult CheckUserPassword(string email, string password)
        {
            var user = _appUserDal.Get(x => x.Email == email);
            bool checkPassword = PasswordHashing.VerifyPassword(password, user.PasswordHash, user.PasswordSalt);

            if (!checkPassword)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }


    }
}

