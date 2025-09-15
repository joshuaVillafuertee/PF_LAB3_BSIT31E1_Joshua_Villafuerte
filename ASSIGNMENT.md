# PF_LAB3 – Assignment Documentation

## Project Information
- **Student:** Joshua Villafuerte  
- **Section:** BSIT31E1  
- **Project Name:** PF_LAB3_BSIT31E1_Joshua_Villafuerte  
- **Theme:** Greed Island (Hunter x Hunter inspired)  

---

## Checklist of Requirements

### MVC Architecture
- [x] Used the Model-View-Controller (MVC) design pattern  
- [x] Configured **Identity** for individual user authentication  
- [x] Implemented two DbContexts:
  - `ApplicationDbContext` → Handles authentication  
  - `GreedDbContext` → Handles card data  

### Card Model
- [x] Created `Card` model with properties:
  - `Id` (primary key)  
  - `Name`  
  - `Rarity`  
  - `ImageUrl`  
  - Other relevant properties  

### Controller
- [x] `CardsController` created with CRUD operations:
  - Create  
  - Read (Index/Details)  
  - Update  
  - Delete  

### Views
- [x] `Index.cshtml` → Displays cards in a Bootstrap grid  
- [x] `Create.cshtml` → Form for adding new cards  
- [x] `Edit.cshtml` → Form for editing cards  
- [x] `Delete.cshtml` → Confirmation page  
- [x] `Details.cshtml` → Shows card info  
- [x] TODO comments included in each view for guidance  

### Theme Application
- [x] Applied Bootstrap styling  
- [x] Added Greed Island (HxH) banner to homepage and navigation  
- [ ] Included Hunter x Hunter character images as card art  

### Documentation
- [x] `README.md` → Contains technical setup instructions  
- [x] `ASSIGNMENT.md` → Contains grading checklist and criteria  

---

## Grading Criteria

| Criteria | Points |
|----------|--------|
| MVC Structure & Routing | 20 pts |
| Identity Authentication | 20 pts |
| Card Model & Database | 20 pts |
| Controller (CRUD) | 15 pts |
| Views (5 templates + TODOs) | 15 pts |
| Theme (Greed Island + styling) | 5 pts |
| Documentation (README + ASSIGNMENT) | 5 pts |
| **Total** | **100 pts** |

---

## Screenshots
- Home Page with banner  
- Cards Index page (Grid of cards)  
- Create Card form  
- Edit Card form  
- Details view  

---

## Notes
- Banner image (`wwwroot/Image/greed-island-banner.jpg`) is displayed in `_Layout.cshtml`.  
- TODO comments are included inside each view for future improvements.  
- Theme customization done through `wwwroot/css/greed-theme.css`.  
- Authentication and migrations are already configured and working.  
- CRUD tested and functional.  
