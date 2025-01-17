using MVCEtut_0.Models.PureVms.RequestModels.AppUsers;
using MVCEtut_0.Models.PureVms.RequestModels.Categories;

namespace MVCEtut_0.Models.PageVms.CategoryControllerProcess
{
    public class CategoryCreateProcessPageVm
    {
        public CreateCategoryRequestModel Category { get; set; }
        public CreateAppUserRequestModel AppUser { get; set; }
    }
}
