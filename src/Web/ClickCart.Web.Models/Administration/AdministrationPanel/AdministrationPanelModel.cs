using ClickCart.Service.Models.Categories;
using ClickCart.Service.Models.Products;

namespace ClickCart.Web.Models.Administration.AdministrationPanel
{
    public class AdministrationPanelModel
    {
        public List<ProductDto> Products { get; set; }

        public List<ProductCategoryDto> ProductCategories { get; set; }
    }
}
