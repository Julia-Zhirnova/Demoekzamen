//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Приятный_шелест.Enitities
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER
    {
        public int ID { get; set; }
        public string LOGIN { get; set; }
        public string PASSWORD { get; set; }
        public int ROLEID { get; set; }
    
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual ROLE ROLE { get; set; }
    }
}
