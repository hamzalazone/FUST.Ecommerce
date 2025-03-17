using Microsoft.AspNetCore.Components.Forms;
using Fust.Ecommerce.Models;
using Fust.Ecommerce.Services;
using Microsoft.AspNetCore.Components;


namespace Fust.Ecommerce.Components.Pages.Admin.Items;

public partial class Update(IItemDataAccess itemDataAccess)
{
    [Parameter]
    public int Id { get; set; }
    private EditContext? _editContext;
    private Item Input { get; set; } = new();
    private bool showSuccessAlert = false;
    public DateTime currentDate = DateTime.Now;

    protected override void OnInitialized()
    {
        Input = itemDataAccess.GetItem(Id)
        ?? throw new Exception("Item not found");
        _editContext = new EditContext(Input);
    }
    public void Save()
    {
        itemDataAccess.UpdateItem(Input);
        showSuccessAlert = true;
    }
}
