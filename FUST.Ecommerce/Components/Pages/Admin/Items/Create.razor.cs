using Microsoft.AspNetCore.Components.Forms;
using Fust.Ecommerce.Models;
using Fust.Ecommerce.Services;

namespace Fust.Ecommerce.Components.Pages.Admin.Items;

public partial class Create(IItemDataAccess itemDataAccess)
{
    private EditContext? _editContext;
    private Item Input { get; set; } = new();
    private bool showSuccessAlert = false;
    public DateTime currentDate = DateTime.Now;

    protected override void OnInitialized()
    {
        _editContext = new EditContext(Input);

    }
    private void Save()
    {
        itemDataAccess.AddItem(Input);
        showSuccessAlert = true;
    }
}
