//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Lab_4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Position
    {
        public int IdPosition { get; set; }
        public int IdEmployee { get; set; }
        public int IdSpec { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}