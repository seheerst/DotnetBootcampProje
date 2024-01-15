using AutoMapper;
using DotnetBootcampProje.Core.Dtos;
using DotnetBootcampProje.Core.Dtos.Authentication;
using DotnetBootcampProje.Core.Models;
using DotnetBootcampProje.Core.Repositories;
using DotnetBootcampProje.Core.Services;
using DotnetBootcampProje.Core.UnitOfWork;
using DotnetBootcampProje.Service.Authorization.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Service.Services
{
    public class TeacherService : GenericService<Teacher>, ITeacherService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Teacher> _repository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public TeacherService(IGenericRepository<Teacher> repository, IUnitOfWork unitOfWork, IMapper mapper, IJwtAuthenticationManager jwtAuthenticationManager,
            ITeacherRepository teacherRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _teacherRepository = teacherRepository;
        }

        public TeacherDto FindUser(string email, string password)
        {
            string passHashed = GeneratePasswordHash(email, password);
            var teacher = _repository.Where(x => x.Email == email && x.Password == passHashed).FirstOrDefault();
            var teacherDto = _mapper.Map<TeacherDto>(teacher);
            return teacherDto;
        }

        public string GeneratePasswordHash(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(email));
            }

            byte[] userBytes = Encoding.UTF8.GetBytes(email);
            string userByteString = Convert.ToBase64String(userBytes);
            string smallByteString = $"{userByteString.Take(2)}.{userByteString.Reverse().Take(2)}";
            byte[] smallBytes = Encoding.UTF8.GetBytes(smallByteString);
            byte[] passBytes = Encoding.UTF8.GetBytes(password);

            byte[] hashed = this.GenerateSaltedHash(passBytes, smallBytes);

            return Convert.ToBase64String(hashed);
        }
        private byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        public AuthResponseDto Login(AuthRequestDto request)
        {
            AuthResponseDto responseDto = new AuthResponseDto();
            TeacherDto teacher = FindUser(request.Email, request.Password);
            responseDto = _jwtAuthenticationManager.Authenticate(request.Email, request.Password);
            responseDto.Teacher = teacher;

            return responseDto;
        }

        public Teacher SignUp(AuthRequestDto authDto)
        {
            #region Password'un hashli halini veri tabanına göndermek için güncelleme yap
            var passwordHash = GeneratePasswordHash(authDto.Email, authDto.Password);
            #endregion

            var teacher = AddAsync(new Core.Models.Teacher
            {
                Email = authDto.Email,
                Password = passwordHash,
                ClassId = 1,
                Phone = "5555555",
                Name = "dasdfldkj"
                
            });
            return teacher.Result;
        }
    }
}
