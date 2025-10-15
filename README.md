# Medical Appointment Management System

## Overview

This Medical Appointment Management System allows users/admin to schedule, update, and manage medical appointments efficiently, also The admin can create a Doctor and a Patient and update or delete the information. It supports doctor specialty filtering, appointment scheduling with date/time validation, 
email notifications for patients, and a detailed history of sent emails.

## Features

- **Create a Doctor**  
  Add new doctors to the system with detailed information such as name, identification, specialty, and contact details. Enables filtering doctors by specialty when scheduling appointments.

- **Create a Patient**  
  Register patients with personal details including name, identification, contact information, and email address for appointment notifications and record-keeping.

- **Schedule Medical Appointments**  
  Assign a patient, doctor, and date/time to an appointment with validation to prevent double booking.

- **Validate Appointments**  
  Ensures that neither doctors nor patients have overlapping appointments.

- **Manage Appointment States**  
  Cancel or mark appointments as attended.

- **Email Notification**  
  Sends confirmation emails to patients upon successful appointment creation.

- **Email History Tracking**  
  Records and displays the history of sent emails with their success status.

- **List Appointments**  
  List appointments by patient or doctor.

---
## Technologies Used

- C# (.NET Core)
- SMTP for sending emails via Gmail
- Console-based user interface

---

## Project structure

```bash
MedicalAppointments/
│
├── Data/
│   └── Database.cs
│
├── Interfaces/
│   ├── ICreate.cs
│   ├── IDelete.cs
│   ├── IDoctor.cs
│   ├── IGet.cs
│   ├── IUpdateMedicalAppointment.cs
│   └── IUpdatePerson.cs
│
├── Menus/
│   ├── DoctorMenu.cs
│   ├── MainMenu.cs
│   ├── MedicalAppointmentMenu.cs
│   ├── PatientMenu.cs
│   ├── UpdateDoctorMenu.cs
│   └── UpdatePatientMenu.cs
│
├── Models/
│   ├── Doctor.cs
│   ├── EmailLog.cs
│   ├── MedicalAppointments.cs
│   ├── Patient.cs
│   └── Person.cs
│
├── Repositories/
│   ├── DoctorRepository.cs
│   ├── EmailHistoryRepository.cs
│   ├── MedicalAppointmentRepository.cs
│   └── PatientRepository.cs
│
├── Services/
│   ├── DoctorService.cs
│   ├── MedicalAppointmentService.cs
│   └── PatientService.cs
│
├── Utils/
│   ├── ConsoleInputHelper.cs
│   ├── ConsoleUI.cs
│   └── EmailSender.cs
│
├── Program.cs
└── README.md


```
---
## How to Use
-Prerequisites
Have .NET 8.0 SDK or higher installed.
👉 You can verify this by running the following in the terminal:

```bash
dotnet --version
```
1. Clone the repository: https://github.com/valeriacadenay/MedicalAppointments.git
2. Run the application.
   
```bash
cd CitasMedicas
```

 ```bash
- dotnet run --framework net8.0
```

2. Navigate through the main menu.
3. Select one of the 3 Menus
4. Select one of the options
5. Enter the requested data that ask
6. To made a MedicalAppoinment you have to create and Appoinment and enter all the data
7. The system will validate availability and send a confirmation email.
8. View, update, or delete appointments as needed.
9. Check the email sending history through the dedicated menu option.

---

## 👩‍💻 Author
- Valeria Cadena Yance 
- Clan: Caiman
- valecade16@gmail.com
