using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Application.Contracts.Product
{
    public class EditProduct:CreateProduct
    {
        public int ProductId { get; set; }

    }
}
