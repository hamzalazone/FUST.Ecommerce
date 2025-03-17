using Fust.Ecommerce.Services;
using Fust.Ecommerce.Models;

namespace Fust.Ecommerce.Components.Pages.Categories;

public partial class Index(ICategoryDataAccess categoryDataAccess)
{
    private IEnumerable<Category>? _categories;

    protected override void OnInitialized()
    {
        _categories = categoryDataAccess.GetCategories();
    }
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
    }
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
    }
}
