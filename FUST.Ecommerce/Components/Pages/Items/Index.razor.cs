using Fust.Ecommerce.Services;
using Fust.Ecommerce.Models;
using Microsoft.AspNetCore.Components;


namespace Fust.Ecommerce.Components.Pages.Items;

public partial class Index(IItemDataAccess itemDataAccess)
{
    private IEnumerable<Item>? _items;
    

    private void ToggleCompleted(Item item)
    {
       
    }

    protected override void OnInitialized()
    {
        _items = itemDataAccess.GetItems();
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
