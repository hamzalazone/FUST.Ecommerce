using Microsoft.AspNetCore.Components;
using Fust.Ecommerce.Models;
using Fust.Ecommerce.Services;

namespace Fust.Ecommerce.Components.Pages.Admin.Categories;

public partial class Details(ICategoryDataAccess categoryDataAccess)
{
    private Category? _category { get; set; }
    [Parameter]
    public int Id { get; set; }

    protected override void OnInitialized()
    {
        _category = categoryDataAccess.GetCategory(Id);
    }
}
