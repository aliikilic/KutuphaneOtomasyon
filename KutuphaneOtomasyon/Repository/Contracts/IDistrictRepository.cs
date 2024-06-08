using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IDistrictRepository : IRepositoryBase<District>
    {
        List<District> GetDistricts(bool trackChanges);

    }
}
