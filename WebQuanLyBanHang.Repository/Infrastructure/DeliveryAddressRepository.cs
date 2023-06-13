﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;

namespace WebQuanLyBanHang.Repository.Infrastructure
{
    public class DeliveryAddressRepository: Repository<DeliveryAddress>, IDeliveryAddressRepository
    {
        public DeliveryAddressRepository(QuanLyBanHangDbContent dbContext) : base(dbContext)
        {
        }
    }
  
}
