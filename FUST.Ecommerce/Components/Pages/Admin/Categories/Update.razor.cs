using Microsoft.AspNetCore.Components.Forms;
using Fust.Ecommerce.Models;
using Fust.Ecommerce.Services;
using Microsoft.AspNetCore.Components;


namespace Fust.Ecommerce.Components.Pages.Admin.Categories;

public partial class Update(ICategoryDataAccess categoryDataAccess)
{
    [Parameter]
    public int Id { get; set; }
    private EditContext? _editContext;
    private Category Input { get; set; } = new();
    private bool showSuccessAlert = false;
    protected override void OnInitialized()
    {
        Input = categoryDataAccess.GetCategory(Id)
        ?? throw new Exception("Category not found");
        _editContext = new EditContext(Input);
    }
    public void Save()
    {
        categoryDataAccess.UpdateCategory(Input);
        showSuccessAlert = true;
    }
}
