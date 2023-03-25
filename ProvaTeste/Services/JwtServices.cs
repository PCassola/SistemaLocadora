using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System;
using ProvaTeste.Models;
using Jose;

namespace ProvaTeste.Services
{
    public class JwtServices
    {
        const string hmacKey = "9s-M<ytaZs";

        public static JwtTokenModels GenerateAccessToken(string user, string empresa, int time)
        {
            var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var issueTime = DateTime.Now.ToUniversalTime();  // retira uma 5m enquanto tiver requizições pelo backend antigo
            var now = (int)issueTime.Subtract(utc0).TotalSeconds;
            var exp = (int)issueTime.AddSeconds(time).Subtract(utc0).TotalSeconds; // aumenta o tempo de sessão em uma hora enquanto tiver requisições pelo bakend antigo

            JwtTokenModels fbtoken = new JwtTokenModels()
            {
                Sub = user,
                Iss = "Server-Manager",
                Pro = new Pro() { UserName = user, Company = empresa },
                Iat = now,
                Exp = exp
            };

            return fbtoken;
        }

        public static string EncodeJson(string text)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(hmacKey);
                RSACryptoServiceProvider rsaCrypto = new RSACryptoServiceProvider();
                string token = JWT.Encode(text, bytes, JwsAlgorithm.HS256);

                return token;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public static JwtTokenModels DecodeJson(string text)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(hmacKey);
                string token = Jose.JWT.Decode(text.Replace("Bearer ", ""), bytes);

                var smToken = JsonConvert.DeserializeObject<JwtTokenModels>(token);

                var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                var issueTime = DateTime.Now.ToUniversalTime();
                var now = (int)issueTime.Subtract(utc0).TotalSeconds;

                if (now >= smToken.Iat && now <= smToken.Exp)
                    return smToken;
                else
                    return null;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
    }
}
