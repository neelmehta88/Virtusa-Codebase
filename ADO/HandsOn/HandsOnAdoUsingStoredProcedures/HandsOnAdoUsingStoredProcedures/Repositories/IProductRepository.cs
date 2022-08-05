using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnAdoUsingStoredProcedures.Entities;
namespace HandsOnAdoUsingStoredProcedures.Repositories
{
    interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProduct(int Pid);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int Pid);
    }
}
