//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uchet_Zayavok.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zayavka
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> DataAdd { get; set; }
        public Nullable<int> OborudID { get; set; }
        public Nullable<int> TypeNeispID { get; set; }
        public string OpisanieProblem { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> IspolnitelID { get; set; }
        public string Comment { get; set; }
        public string Material { get; set; }
        public Nullable<int> Cost { get; set; }
        public string ReasonNeisp { get; set; }
        public string OpisanieHelp { get; set; }
        public Nullable<int> ZapchastID { get; set; }
        public Nullable<System.DateTime> DataEnd { get; set; }
        public string PhotoPath { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Ispolnitel Ispolnitel { get; set; }
        public virtual Neisp Neisp { get; set; }
        public virtual Oborud Oborud { get; set; }
        public virtual Status Status { get; set; }
        public virtual Zapchast Zapchast { get; set; }
    }
}
