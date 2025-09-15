# PF_LAB3_BSIT31E1_Joshua_Villafuerte

##  Overview
This project is a **Greed Island themed card manager** built with **ASP.NET Core MVC**.  
It includes:
- **Individual Authentication** (Identity via `ApplicationDbContext`)
- **Card Management** (CRUD with `GreedDbContext`)
- **Greed Island Theme** applied to home page and navigation

---

## Run Locally

### 1. Configure Connection Strings
Open `appsettings.json` and set:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=IdentityDB;Trusted_Connection=True;MultipleActiveResultSets=true",
  "GreedConnection": "Server=(localdb)\\MSSQLLocalDB;Database=GreedDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
