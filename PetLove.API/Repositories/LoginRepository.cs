using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace PetLove.API.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        //Injeção de Dependência
        PetLoveContext contextoBanco;

        public LoginRepository(PetLoveContext _contextoBanco)
        {
            contextoBanco = _contextoBanco;
        }

        
        

        public string Logar(string email, string senha)
        {
            //return contextoBanco.Usuarios.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            // Irá realizar uma pesquisa pelo email do usuário
            var usuario = contextoBanco.Usuario
                .Include(t => t.TipoUsuario)
                .FirstOrDefault(x => x.Email == email);
            

            if (usuario != null)
            {
                // Verifica se a senha que recebe por parâmetro é a mesma senha que está no banco
                bool validPassword = BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
                
                

                if (validPassword)
                {
                    // Criar as credênciais do JWT

                    // Definimos as Claims
                    var minhasClaims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Role, usuario.TipoUsuario.Tipo.ToString())
                       
                    };

                    // Criamos as chaves
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("clinica-vet-2022-@#$-chave-de-authenticacao"));

                    // Criamos as credênciais
                    var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Geramos o token
                    var meuToken = new JwtSecurityToken(
                        issuer: "clinica.webAPI",
                        audience: "clinica.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: credenciais
                    );

                    // Retornamos o token em formato de string
                    return new JwtSecurityTokenHandler().WriteToken(meuToken);
                }
                    
            }

            return null;
        }
    }
}
