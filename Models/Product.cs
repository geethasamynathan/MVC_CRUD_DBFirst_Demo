﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MVC_CRUD_DBFirst_Demo.Models;

public partial class Product
{ 
//{
//    [BindProperty]
//    public string SearchTerm { get; set; }
    public string ProductId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public byte? CategoryId { get; set; }

    public decimal Price { get; set; }

    public int QuantityAvailable { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
