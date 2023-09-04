﻿using EF.Core.Repository.Interface.Repository;
using Library.Web.Models.DomainModels;

namespace Library.Web.Interfaces.Repository
{
    public interface IBooksRepository: ICommonRepository<Books>
    {
    }
}
