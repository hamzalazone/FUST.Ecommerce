using Microsoft.AspNetCore.Components;
using Fust.Ecommerce.Models;
using Fust.Ecommerce.Services;

namespace Fust.Ecommerce.Components.Pages.Admin.Items;

public partial class Details(IItemDataAccess itemDataAccess)
{
    private Item? _item { get; set; }
    [Parameter]
    public int Id { get; set; }

    protected override void OnInitialized()
    {
        _item = itemDataAccess.GetItem(Id);
    }
}
