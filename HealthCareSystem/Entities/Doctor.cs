using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCareSystem.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        public ICollection<Appointment> Appointments { get; set; }  = new List<Appointment>();
    }
}
