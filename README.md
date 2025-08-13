# HealthCare

**HealthCare** is a collaborative seminar project developed with ASP.NET Core (API) and Angular (Frontend). It is a role-based web application designed to streamline healthcare management processes. The system supports multiple user roles (Pacijent, Ljekar, Tehnicar, Admin etc.) with tailored access to different features.



## My Contributions

- **Authentication and authorization** – Managing user account access with role assignments
- **Role "Admin"** – Adding new staff members (Ljekar, Tehnicar, Asistent etc.)
- **Role "Ljekar"** – Findings and referrals management, requests for medication
- **Role "Pacijent"** – Findings overview
- **Role "Farmaceut"** – Medication request management
  


## Tech Stack

- **Backend:** ASP.NET Core Web API  
- **Frontend:** Angular  
- **Database:** SQL Server (Code First with Entity Framework)  
- **Authentication:** Basic Auth + 2FA verification via e-mail  
- **Version Control:** Git & GitHub



## Reminder

This project has built-in 2FA verification via e-mail, but that option is turned off due to easier testing of the app. To enable 2FA for a specific user in the database:  
```bash
UPDATE dbo.Korisnik -- Table Korisnik
SET IsEnabled2FA = 1  -- Enable 2FA 
WHERE UserId = 123; -- Replace 123 with the actual user's ID
```



## Running The App

**1. Run the API**

Navigate to the API folder and open the HealthCare.sln solution.

**2. Run Angular frontend**

Open angular folder in Visual Studio Code and install packages:
```bash
npm install
```
After installing packages, run the app: 
```bash
npm start
```



## Login Credentials

Role "Admin"
```bash
E-mail: admin@test.com
Password: Pass123$
```
Role "Ljekar"
```bash
E-mail: ljekar@test.com
Password: Pass123$
```
Role "Pacijent"
```bash
E-mail: pacijent@test.com
Password: Pass123$
```
Role "Asistent"
```bash
E-mail: asistent@test.com
Password: Pass123$
```
Role "Tehnicar"
```bash
E-mail: tehnicar@test.com
Password: Pass123$
```
Role "Farmaceut"
```bash
E-mail: farmaceut@test.com
Password: Pass123$
```



