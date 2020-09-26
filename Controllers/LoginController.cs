using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace LoginAppApi.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public Models.Login Autenticar([FromBody] Models.UserMin user)
        {
            //var ConnectionStringLocal = _configuration.GetValue<string>("ConnectionStringLocal");
            ////var ConnectionStringAzure = _configuration.GetValue<string>("ConnectionStringAzure");
            //using (ILogin Login = Factorizador.CrearConexionServicio(Api.Library.Models.ConnectionType.MSSQL, ConnectionStringLocal))
            //{
            //    //List<Api.Library.Models.User> objusrs = Login.ObtenerUsers();
            //    Api.Library.Models.User objusr = Login.EstablecerLogin(user.Nick, user.Password);

            Models.Login objusr = null;
            //if (objusr.ID > 0)
            if (user.Password == "96CAE35CE8A9B0244178BF28E4966C2CE1B8385723A96A6B838858CDD6CA0A1E" && user.Nick == "santi.ati")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("maestria-mtwdm-2020"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://plataforma.poderjudicial-gto.gob.mx",
                    audience: "https://plataforma.poderjudicial-gto.gob.mx",
                    claims: new List<System.Security.Claims.Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                objusr = new Models.Login()
                {
                    Token = tokenString,
                    ID = 10,
                    Name = "Ramón Santiago"
                };
            }
                return objusr;
            //}

        }

    }
}
