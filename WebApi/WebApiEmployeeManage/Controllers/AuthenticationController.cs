using AutoMapper;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ResourceModel.Api;
using ResourceModel.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiEmployeeManage.Repository;

namespace WebApiEmployeeManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationController(IMapper mapper, ILogger<AuthenticationController> logger, IAuthenticationRepository authenticationRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _authenticationRepository = authenticationRepository;
        }

        [Authorize]
        [HttpGet("GetAllUserDetailsAsync")]
        public async Task<List<UserDetailResModel>> GetAllUserDetailsAsync()
        {
            List<UserDetailModel> userDetails = new List<UserDetailModel>();
            List<UserDetailResModel> userDetailsrm = new List<UserDetailResModel>();

            userDetails = await this._authenticationRepository.GetAllUserDetailsAsync();
            userDetailsrm = this._mapper.Map<List<UserDetailResModel>>(userDetails);

            return userDetailsrm;
        }

        [HttpPost("RegisterUserAsync")]
        public async Task<UserDetailResModel> RegisterUserAsync(RegisterUserResModel registerUserResModel)
        {
            UserDetailModel userDetail = new UserDetailModel();
            UserDetailResModel userDetailRmReturn = new UserDetailResModel();
            JwtToken jwtTokenrm = new JwtToken();

            userDetail = this._mapper.Map<UserDetailModel>(registerUserResModel);
            userDetail = await this._authenticationRepository.RegisterUserAsync(userDetail);

            userDetailRmReturn = this._mapper.Map<UserDetailResModel>(userDetail);

            jwtTokenrm = GenerateJwtToken(userDetailRmReturn);

            return userDetailRmReturn;
        }

        [HttpPost("AuthenticateUser")]
        public async Task<JwtToken> AuthenticateUser(ClientLoginResModel clientLoginResModel)
        {
            JwtToken jwtTokenrm = new JwtToken();
            UserDetailModel userDetail = new UserDetailModel();
            UserDetailResModel userDetailRmReturn = new UserDetailResModel();

            userDetail = await this._authenticationRepository.AuthenticateUser(clientLoginResModel.UserName, clientLoginResModel.Password);

            if (userDetail == null)
            {
                return jwtTokenrm;
            }

            userDetailRmReturn = this._mapper.Map<UserDetailResModel>(userDetail);

            jwtTokenrm = GenerateJwtToken(userDetailRmReturn);

            return jwtTokenrm;
        }

        [Authorize]
        [HttpGet("ValidateUserAuthentication")]
        public async Task<bool> ValidateUserAuthentication()
        {
            return true;
        }

        [Authorize]
        [HttpGet("GetApiUrls")]
        public async Task<List<ApiUrlResModel>> GetApiUrls()
        {
            List<ApiUrlResModel> apiUrls = new List<ApiUrlResModel>();

            apiUrls.Add(new ApiUrlResModel { Api = "ClaimsAServer", ApiUrls = new List<string> { "https://localhost:44381" } });

            return apiUrls;
        }

        private JwtToken GenerateJwtToken(UserDetailResModel userDetailRmReturn)
        {
            JwtToken jwtTokenrm = new JwtToken();

            var signingKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(signingKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDetailRmReturn.FirstName + " "  + userDetailRmReturn.LastName ),
                    new Claim("UserName", userDetailRmReturn.UserName),
                    new Claim("UserId", userDetailRmReturn.UserId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddSeconds(100000),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            jwtTokenrm.Token = tokenString;
            jwtTokenrm.IsUserAuthenticated = true;

            return jwtTokenrm;
        }
    }
}