# RecipeBook - Culinary Sharing Platform

A modern .NET Blazor web application for sharing and discovering recipes with beautiful dark theme design.

## Features

- **User Authentication** - Secure login/register with ASP.NET Identity
- **Full CRUD Operations** - Create, read, update, and delete recipes
- **Image Upload** - Upload and preview recipe images
- **Responsive Design** - Mobile-friendly interface
- **Modern UI** - Purple-themed dark design with smooth animations

##  Tech Stack

- **Frontend**: Blazor Server (.NET 9.0)
- **Backend**: ASP.NET Core
- **Database**: SQLite + Entity Framework Core
- **Styling**: Custom CSS

## Quick Start

```bash
git clone https://github.com/tettehq/CSE325-Team05Project.git
cd CSE325-Team05Project/RecipeBook.Web
dotnet restore
dotnet ef database update
dotnet run
```

Visit: `https://localhost:7000`

## 📱 Usage

1. **Register/Login** - Create account or sign in
2. **Browse Recipes** - View public recipe collection
3. **Create Recipes** - Add recipes with images and instructions
4. **Manage Content** - Edit or delete your recipes

## Project Structure

- `Components/Pages/` - Recipe pages (Create, Edit, List, Manage)
- `Data/` - Database models & context
- `Services/` - File upload service
- `wwwroot/app.css` - Main styling
- `Areas/Identity/` - Authentication pages provided by default by .NET

## Key Components

- **Home** - Recipe slideshow and quick actions
- **RecipeCreate** - Two-column form with image upload
- **RecipeEdit** - Edit existing recipes with same styling
- **RecipesManagement** - User's recipe dashboard
- **Authentication** - Styled login/register pages

## Design Features

- Dark purple gradient theme
- Responsive grid layouts
- Smooth hover animations
- Professional card-based design
- Consistent navigation

## Support

Contact development team or create GitHub issues for support.

---

**Share your culinary creations! 🍳**