using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Data.Entity;

namespace WebQuanLyBanHang.Data.Extend
{
    public static class ModerbudingExtend
    {
        public static void Send(this ModelBuilder modelBuilder)
        {
            // Create Role // 
            var roleId = Guid.Parse("EAA7D4C6-F51E-4E0E-88B4-556F3550AFA8");
            var roleId1 = Guid.Parse("bc861e4d-6504-4f65-a4cf-e2d3f60d6a1f");
            var roleId2 = Guid.Parse("fd106bef-1b44-44c5-91d5-ca250da233dc");
            var roleId3 = Guid.Parse("8681b0e2-e6fd-4c8b-8977-de04987f80ba");

            modelBuilder.Entity<Role>().HasData(
                    new Role
                    {
                        Id = roleId,
                        Name = "Admin",
                        Description = "Quản trị viên"
                    },
                    new Role
                    {
                        Id = roleId1,
                        Name = "MKT",
                        Description = "Nhân viên MKT"
                    },
                    new Role
                    {
                        Id = roleId2,
                        Name = "Sale",
                        Description = "Nhân viên Sale"
                    },
                    new Role
                    {
                        Id = roleId3,
                        Name = "MgMKT",
                        Description = "Quản lý MKT"
                    }
                    );
            var hasher = new PasswordHasher<User>();
            var userId = Guid.Parse("37DC78BE-5899-4092-9F31-7C336837A531");
            var userId1 = Guid.Parse("e48e4bfc-c4e7-4346-a306-8c455d1241e3");
            var userId2 = Guid.Parse("40a76602-1634-4d58-8e74-522d40e7f524");
            var userId3 = Guid.Parse("8e2027cb-cec4-40d9-9d53-f7e28483d3cb");

            modelBuilder.Entity<User>().HasData(

                new User
                {
                    Id = userId,
                    Email = "Admin123@gmail.com",
                    EmailConfirmed =true,
                    NormalizedEmail = "Admin123@gmail.com",
                    FullName = "Admin",
                    UserName="Admin",
                    NormalizedUserName = "Admin",
                    Address="Admin", 
                    CityId=1, 
                    DateCreated= DateTime.Now,
                    DateOfBirth= DateTime.Now, 
                    PhoneNumber="0369852147", 
                    PasswordHash = hasher.HashPassword(null,"admin123"),
                    SecurityStamp = string.Empty,
                },
                new User
                {
                    Id = userId1,
                    Email = "NhanvienSale@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "Sale123@gmail.com",
                    FullName = "Bùi Xuân Sale",
                    UserName = "Sale123",
                    NormalizedUserName = "Sale123",
                    Address = "Sale123",
                    CityId = 1,
                    DateCreated = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    PhoneNumber = "0369852114",
                    PasswordHash = hasher.HashPassword(null, "Sale123"),
                    SecurityStamp = string.Empty,
                },
                new User
                {
                    Id = userId2,
                    Email = "NhanvienMKT@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "MKT123@gmail.com",
                    FullName = "Đặng Xuân MKT",
                    UserName = "MKT123",
                    NormalizedUserName = "MKT123",
                    Address = "MKT123",
                    CityId = 1,
                    DateCreated = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    PhoneNumber = "0369852145",
                    PasswordHash = hasher.HashPassword(null, "MKT123"),
                    SecurityStamp = string.Empty,
                },
                new User
                {
                    Id = userId3,
                    Email = "QuanlynhanvienMKT@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "MKT123@gmail.com",
                    FullName = "Trần Văn Phường",
                    UserName = "MGMKT123",
                    NormalizedUserName = "MGMKT123",
                    Address = "MGMKT123",
                    CityId = 1,
                    DateCreated = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    PhoneNumber = "0369852150",
                    PasswordHash = hasher.HashPassword(null, "MGMKT123"),
                    SecurityStamp = string.Empty,
                });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                     RoleId = roleId, 
                     UserId = userId

                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleId1,
                    UserId = userId2

                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleId2,
                    UserId = userId1

                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleId3,
                });
        }
    }
}
