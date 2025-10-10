using Microsoft.AspNetCore.Identity;

namespace RecipeBook.Web.Data
{
    // Usuario extendible por si mañana queremos agregar más propiedades (DisplayName, etc.)
    public class ApplicationUser : IdentityUser
    {
    }
}
