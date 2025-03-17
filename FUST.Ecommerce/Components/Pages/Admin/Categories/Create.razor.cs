using Microsoft.AspNetCore.Components.Forms;
using Fust.Ecommerce.Models;
using Fust.Ecommerce.Services;

namespace Fust.Ecommerce.Components.Pages.Admin.Categories;

public partial class Create(ICategoryDataAccess categoryDataAccess)
{
    private EditContext? _editContext;
    private Category Input { get; set; } = new();
    private bool showSuccessAlert = false;

    protected override void OnInitialized()
    {
        _editContext = new EditContext(Input);

    }
    private void Save()
    {
        categoryDataAccess.AddCategory(Input);
        showSuccessAlert = true;
    }
}
