//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Internet_Shop
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public decimal ID { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<decimal> ProductID { get; set; }
        public string FullName { get; set; }
        public Nullable<decimal> OrderID { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
