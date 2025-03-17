using System;

namespace Fust.Ecommerce.Models;

public class Item
{
   public int Id { get; set; }
   public string Title {get; set;}
   public string? Description {get; set;}
   public int CategoryId {get; set;}
   public string UserId {get; set;}
   public bool Completed {get; set;}
   public DateTime CreatedDate {get; set;}
   public DateTime? CompletedDate {get; set;}
}  
