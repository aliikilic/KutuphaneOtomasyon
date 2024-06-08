using KutuphaneOtomasyon.Models.EntityModels;
using KutuphaneOtomasyon.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface INeighborhoodRepository : IRepositoryBase<Neighborhood>
    {
        List<Neighborhood> GetNeighborhoods(bool trackChanges);

    }
}
