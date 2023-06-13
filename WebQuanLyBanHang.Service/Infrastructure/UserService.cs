using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper,
            UserManager<User> userManager, IRoleRepository roleRepository
             )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _roleRepository = roleRepository;
        }

        public async Task Add(UserVM uservm)
        {
            try
            {
                
                var user = _mapper.Map<User>(uservm);

                uservm.RoleName=  _roleRepository.Get(x => x.Id == uservm.RoleId).Name;

                user.SecurityStamp = Guid.NewGuid().ToString();

                await _userManager.CreateAsync(user, uservm.PasswordHash);

                // Thêm quyền chu user
                await _userManager.AddToRoleAsync(user, uservm.RoleName);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
            }
        }

        public async Task ChangePassword(UserPaword userPaword)
        {
            
            try
            {
                var user = await _userManager.FindByIdAsync(userPaword.Id.ToString());
                if (user != null)
                {

                    user.PasswordHash = _userManager.PasswordHasher.
                                        HashPassword(user,userPaword.PaswordNew);

                    var result = await _userManager.UpdateAsync(user);
                }
                
            }catch (Exception ex)
            {
               await _unitOfWork.RollbackAsync();
            }
        }

        public Task<bool> CheckData(string word)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserVM> Get(Guid id)
        {
            UserVM userVM = new UserVM();
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());

                userVM = _mapper.Map<UserVM>(user);
                var role =  _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                if (role != null)
                {
                    userVM.RoleName = role;
                }
                return userVM;
            }
            catch (Exception ex)
            {
                return new UserVM();
            }
        }

        public async Task<ResponseData<UserVM>> GetAll(Pageding pageding)
        {
            ResponseData<UserVM> response = new ResponseData<UserVM>();

            var data = _userManager.Users;
            if (!string.IsNullOrEmpty(pageding.KeyWord))
            {
                data = data.Where(x => x.FullName.Contains(pageding.KeyWord));
            };
            int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
            data = data.OrderByDescending(x => x.Id)
                        .Skip(pageding.PageSize * (pageding.PageNum - 1))
                        .Take(pageding.PageSize);

            var list = await _mapper.ProjectTo<UserVM>(data).ToListAsync();

            response.TotalPage = toltalpages;
            response.PageIndex = pageding.PageNum;
            response.Items = list;

            return response;
        }

        public List<Role> GetListRole()
        {
            List<Role> roleList = new List<Role>();
            try
            {
                roleList =  _roleRepository.GetAll().ToList();
            }
            catch
            {
                roleList = new List<Role>();
            }
            return roleList;
        }

        public Task Update(UserVM singleType)
        {
            throw new NotImplementedException();
        }
    }
}