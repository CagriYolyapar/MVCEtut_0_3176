
using MVCEtut_0.Models.PureVms.ResponseModels.Categories;

namespace MVCEtut_0.Models.PageVms.CategoryControllerProcess
{
    public class CategoryProcessPageVm
    {
        public List<CategoryResponseModel> Categories { get; set; }
        public CategoryResponseModel TheMostPopularCategory { get; set; }
    }
}
