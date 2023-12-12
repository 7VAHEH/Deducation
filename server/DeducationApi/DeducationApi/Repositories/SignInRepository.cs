using DeducationApi.Models;
using DeducationApi.Models.DBModels;
using DeducationApi.Models.RequestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DeducationApi.Repositories
{
    public class SignInRepository : ISignInRepository
    {
        private readonly DeducationDBContext dBContext;
        private readonly IConfiguration _configuration;

        public SignInRepository(DeducationDBContext dBContext, IConfiguration configuration)
        {
            this.dBContext = dBContext;
            _configuration = configuration;
        }

        public async Task<string> StudentRegistration(StudentRegistrationRequestModel studentRegistrationModel)
        {
            var studentExist = await dBContext.Students.AnyAsync(x => x.Email == studentRegistrationModel.Email);

            if (studentExist)
                return null;

            string prefs = "";
            for (int i = 0; i < studentRegistrationModel.Preferences.Length; i++)
            {
                prefs = prefs + ", " + studentRegistrationModel.Preferences[i];
            }

            var newStudent = new Student
            {
                FirstName = studentRegistrationModel.FirstName,
                LastName = studentRegistrationModel.LastName,
                Email = studentRegistrationModel.Email,
                Birthdate = DateTime.Parse(studentRegistrationModel.Birthdate),
                Password = studentRegistrationModel.Password,
                Country = studentRegistrationModel.Country,
                Preferences = prefs,
                ProfilePictureUrl = null,
                UniversityName = studentRegistrationModel.University,
                ClassOf = studentRegistrationModel.ClassOf,
                Faculty = studentRegistrationModel.Faculty,
            };

            await dBContext.Students.AddAsync(newStudent);
            await dBContext.SaveChangesAsync();

            var token = CreateJwtToken(newStudent.Id, "student");
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtSecurityToken CreateJwtToken(Guid id, string role)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", id.ToString()),
                        new Claim(ClaimTypes.Role, role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signIn);

            return token;
        }

        public async Task<string> SignIn(SignInRequestModel signInModel)
        {
            var student = await dBContext.Students.SingleOrDefaultAsync(x => x.Email == signInModel.Email && x.Password == signInModel.Password);
            if (student != null)
            {
                var token = CreateJwtToken(student.Id,"student");
                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            //var university = await dBContext.Professors.SingleOrDefaultAsync(x => x.Email == signInModel.Email && x.Password == signInModel.Password)
            //if (student != null)
            //{
            //    var token = CreateJwtToken(student.Id, "student"); 
            //    return new JwtSecurityTokenHandler().WriteToken(token);
            //}

            //if (student != null)
            //{
            //    var token = CreateJwtToken(student.Id, "student");
            //    return new JwtSecurityTokenHandler().WriteToken(token);
            //}

            //if (student != null)
            //{
            //    var token = CreateJwtToken(student.Id, "student");
            //    return new JwtSecurityTokenHandler().WriteToken(token);
            //}

            return null;

        }
    }
}
