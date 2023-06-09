﻿using DataLayer.Entities;
using DataLayer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Implement
{
	public class ProductRepository : RepositoryBase<Product>, IProductRepository
	{
		public ProductRepository(StoreDBContext context) : base(context)
		{
		}
	}
}
