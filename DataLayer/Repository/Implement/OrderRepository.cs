﻿using DataLayer.Entities;
using DataLayer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Implement
{
	public class OrderRepository: RepositoryBase<Order>, IOrderRepository
	{
		public OrderRepository(StoreDBContext context) : base(context)
		{
		}
	}
}
