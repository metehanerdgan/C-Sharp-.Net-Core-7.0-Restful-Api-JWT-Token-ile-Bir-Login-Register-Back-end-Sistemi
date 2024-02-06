using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NodebookApp.Services.Interface;
using NodebookApp.SharedVM;

namespace NodebookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserService userService,IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        // Yeni bir kullanıcı kaydı işlemi
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] Register model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsycn(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result); 
            }
            return BadRequest("Hatalı");
        }

        // Kullanıcı girişi işlemi
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] Login model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await  _userService.LoginUserAsycn(model);
                    if(result.IsSuccess)
                    {
                        return Ok(result);
                    }
                    return BadRequest(result);
                }
                return BadRequest("Hatalı");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
