//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMONIC.Airlines
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedules
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public int AircraftID { get; set; }
        public int RouteID { get; set; }
        public decimal EconomyPrice { get; set; }
        public bool Confirmed { get; set; }
        public string FlightNumber { get; set; }
    
        public virtual Aircrafts Aircrafts { get; set; }
        public virtual Routes Routes { get; set; }
    }
}
