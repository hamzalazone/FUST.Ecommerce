using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Fust.Ecommerce.Models;
using Fust.Ecommerce.Services;

namespace Fust.Ecommerce.Components.Pages.Admin.Items;

public partial class Delete(IItemDataAccess itemDataAccess)
{
   [Parameter]
   public int Id { get; set; }
    private bool showSuccessAlert = false;


    protected override void OnInitialized()
    {
        itemDataAccess.DeleteItem(Id);
        showSuccessAlert = true;

    }

}
