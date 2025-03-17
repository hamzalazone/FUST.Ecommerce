using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Fust.Ecommerce.Models;
using Fust.Ecommerce.Services;

namespace Fust.Ecommerce.Components.Pages.Admin.Categories;

public partial class Delete(ICategoryDataAccess categoryDataAccess)
{
   [Parameter]
   public int Id { get; set; }
    private bool showSuccessAlert = false;


    protected override void OnInitialized()
    {
        categoryDataAccess.DeleteCategory(Id);
        showSuccessAlert = true;

    }

}
