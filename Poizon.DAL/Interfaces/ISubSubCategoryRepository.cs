﻿using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface ISubSubCategoryRepository : IBaseRepository<SubSubCategory>
{
	Task<SubSubCategory> GetSubSubCategoryByName(string name);
}

