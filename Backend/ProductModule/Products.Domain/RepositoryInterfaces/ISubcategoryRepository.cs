using Products.Modal.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.RepositoryInterfaces
{
    public interface ISubcategoryRepository
    {
        Task<List<SubCategories>> GetSubCategoriesByCategoryID(int categoryID);
    }
}
