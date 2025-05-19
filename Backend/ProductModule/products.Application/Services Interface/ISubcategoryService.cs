using Products.View_Request_Modals.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products.Application.Services_Interface
{
    public interface ISubcategoryService
    {
        Task<List<Subcategory_ViewModal>> GetSubcategoriesByCategoryId(int categoryId);
    }
}
