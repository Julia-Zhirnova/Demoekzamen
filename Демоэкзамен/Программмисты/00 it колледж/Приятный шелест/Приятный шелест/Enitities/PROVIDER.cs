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
    
    public partial class PROVIDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROVIDER()
        {
            this.PROVIDERGOOD = new HashSet<PROVIDERGOOD>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        public string INN { get; set; }
        public int AGENTTYPEID { get; set; }
    
        public virtual AGENTTYPE AGENTTYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROVIDERGOOD> PROVIDERGOOD { get; set; }
    }
}
