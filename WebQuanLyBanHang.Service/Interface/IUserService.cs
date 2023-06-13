using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IUserService
    {
        public Task<ResponseData<UserVM>> GetAll(Pageding pageding);
        public Task ChangePassword(UserPaword userPaword);
        public Task Add(UserVM singleType);
        public Task Update(UserVM singleType);
        public Task Delete(Guid id);
        public Task<UserVM> Get(Guid id);
        public Task<bool> CheckData(string word);
        public List<Role> GetListRole();
    }
}