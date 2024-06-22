using Madhuu_PMS.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madhuu_PMS.Model.ViewModels
{
    public class ProductsViewModel
    {
        public SearchViewModel searchViewModel { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}