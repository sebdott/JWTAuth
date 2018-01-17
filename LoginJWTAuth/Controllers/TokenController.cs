using Microsoft.AspNetCore.Mvc;
using LoginJWTAuth.Models.Token;
using LoginJWTAuth.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace LoginJWTAuth.Controllers
{
    [Route("token")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody]LoginInputModel inputModel)
        {
            if (inputModel.Username != "james" && inputModel.Password != "bond")
                return Unauthorized();

            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("fiver-secret-key"))
                                .AddSubject("james bond")
                                .AddIssuer("LoginJWTAuth")
                                .AddAudience("LoginJWTAuth")
                                .AddClaim("MembershipId", "111")
                                .AddExpiry(0)
                                .Build();

            //return Ok(token);
            return Ok(token.Value);
        }
    }
}
