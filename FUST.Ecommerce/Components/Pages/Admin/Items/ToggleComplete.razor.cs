using Fust.Ecommerce.Services;
using Fust.Ecommerce.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;

namespace Fust.Ecommerce.Components.Pages.Admin.Items;

public partial class ToggleComplete(IItemDataAccess itemDataAccess)
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
        if(Input.Completed=true)
        {
            itemDataAccess.UpdateToFalse(Input);
        }
        else if(Input.Completed = false)
        {
            itemDataAccess.UpdateToTrue(Input);
        }
    }
    public void Save()
    {
        itemDataAccess.UpdateItem(Input);
        showSuccessAlert = true;
    }
    

}
