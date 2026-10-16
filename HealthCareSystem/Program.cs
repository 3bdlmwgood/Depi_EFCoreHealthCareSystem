using HealthCareSystem.Data;
using HealthCareSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new AppDbContext();

            #region Create Patient

            var patient = new Patient
            {
                Name = "Ahmed Mohamed",
                DateOfBirth = new DateTime(2000, 5, 15)
            };

            dbContext.Patients.Add(patient);

            #endregion

            #region Create Doctor

            var doctor = new Doctor
            {
                Name = "Dr. Sara",
                Specialization = "Cardiology"
            };

            dbContext.Doctors.Add(doctor);

            dbContext.SaveChanges();

            #endregion

            #region Create Appointment

            var appointment = new Appointment
            {
                PatientId = patient.Id,
                DoctorId = doctor.Id,
                AppointmentDate = DateTime.Now.AddDays(1)
            };

            dbContext.Appointments.Add(appointment);

            dbContext.SaveChanges();

            Console.WriteLine("Appointment created successfully.");

            #endregion

            #region Read Appointments

            var appointments = dbContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToList();

            foreach (var a in appointments)
            {
                Console.WriteLine($"Patient: {a.Patient.Name}");
                Console.WriteLine($"Doctor: {a.Doctor.Name}");
                Console.WriteLine($"Specialization: {a.Doctor.Specialization}");
                Console.WriteLine($"Appointment Date: {a.AppointmentDate}");
                Console.WriteLine("----------------------");
            }

            #endregion
        }
    }
}