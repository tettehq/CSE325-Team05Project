using RecipeBook.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace RecipeBook.Web.Services
{
    public class RecipeService
    {
        private readonly AppDbContext _context;

        public RecipeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task InitializeSampleDataAsync()
{
    // Check if we already have recipes
    if (await _context.Recipes.AnyAsync())
        return;

    var sampleRecipes = new List<Recipe>
    {
        new Recipe
        {
            Title = "Classic Margherita Pizza",
            Category = "Italian",
            Ingredients = "• 2 ½ cups all-purpose flour\n• 1 teaspoon salt\n• 1 teaspoon sugar\n• 1 tablespoon active dry yeast\n• 1 cup warm water\n• 2 tablespoons olive oil\n• 1 cup tomato sauce\n• 8 oz fresh mozzarella cheese\n• Fresh basil leaves\n• Salt and pepper to taste",
            Steps = "1. Mix flour, salt, sugar, and yeast\n2. Add warm water and olive oil, knead for 10 minutes\n3. Let dough rise for 1 hour\n4. Roll out dough and add tomato sauce\n5. Top with mozzarella and basil\n6. Bake at 475°F for 12-15 minutes",
            ImagePath = "/images/pizza.jpg",
            CreatedAt = DateTime.Now.AddDays(-5),
            UpdatedAt = DateTime.Now.AddDays(-5)
        },
        new Recipe
        {
            Title = "Juicy Beef Burger",
            Category = "American",
            Ingredients = "• 1 lb ground beef (80/20)\n• 1 teaspoon salt\n• ½ teaspoon black pepper\n• 1 teaspoon garlic powder\n• 4 burger buns\n• 4 slices cheddar cheese\n• Lettuce leaves\n• Tomato slices\n• Red onion slices\n• Pickles\n• Ketchup and mustard",
            Steps = "1. Season ground beef with salt, pepper, and garlic powder\n2. Form into 4 patties, make indent in center\n3. Grill for 4-5 minutes per side\n4. Add cheese during last minute\n5. Toast buns lightly\n6. Assemble with toppings and condiments",
            ImagePath = "/images/burger.jpg",
            CreatedAt = DateTime.Now.AddDays(-4),
            UpdatedAt = DateTime.Now.AddDays(-4)
        },
        new Recipe
        {
            Title = "Crispy Fried Chicken",
            Category = "American",
            Ingredients = "• 8 chicken pieces\n• 2 cups buttermilk\n• 2 cups all-purpose flour\n• 1 tablespoon paprika\n• 1 teaspoon garlic powder\n• 1 teaspoon onion powder\n• 1 teaspoon cayenne pepper\n• Salt and pepper to taste\n• Vegetable oil for frying",
            Steps = "1. Soak chicken in buttermilk for 4 hours\n2. Mix flour with spices in a bag\n3. Coat chicken in flour mixture\n4. Heat oil to 350°F\n5. Fry chicken for 15-20 minutes until golden\n6. Drain on paper towels",
            ImagePath = "/images/fried-chicken.jpg",
            CreatedAt = DateTime.Now.AddDays(-3),
            UpdatedAt = DateTime.Now.AddDays(-3)
        },
        new Recipe
        {
            Title = "Authentic Chicken Shawarma",
            Category = "Middle Eastern",
            Ingredients = "• 2 lbs chicken thighs\n• ½ cup plain yogurt\n• 3 tablespoons lemon juice\n• 4 garlic cloves, minced\n• 1 tablespoon paprika\n• 1 teaspoon cumin\n• 1 teaspoon turmeric\n• ½ teaspoon cinnamon\n• Pita bread\n• Garlic sauce\n• Pickles and vegetables",
            Steps = "1. Mix yogurt, lemon juice, and spices\n2. Marinate chicken for 6 hours\n3. Grill or bake until cooked through\n4. Slice thinly\n5. Serve in pita with garlic sauce and vegetables",
            ImagePath = "/images/shawarma.jpg",
            CreatedAt = DateTime.Now.AddDays(-2),
            UpdatedAt = DateTime.Now.AddDays(-2)
        },
        new Recipe
        {
            Title = "Grilled Salmon with Herbs",
            Category = "Seafood",
            Ingredients = "• 4 salmon fillets\n• 2 tablespoons olive oil\n• 2 tablespoons lemon juice\n• 3 garlic cloves, minced\n• 1 tablespoon fresh dill\n• 1 tablespoon fresh parsley\n• Salt and pepper to taste\n• Lemon wedges for serving",
            Steps = "1. Pat salmon dry with paper towels\n2. Mix olive oil, lemon juice, garlic, and herbs\n3. Brush mixture over salmon\n4. Grill for 4-6 minutes per side\n5. Serve with lemon wedges",
            ImagePath = "/images/salmon.jpg",
            CreatedAt = DateTime.Now.AddDays(-1),
            UpdatedAt = DateTime.Now.AddDays(-1)
        }
    };

    _context.Recipes.AddRange(sampleRecipes);
    await _context.SaveChangesAsync();
}

        public async Task<List<Recipe>> GetFeaturedRecipesAsync(int count = 6)
        {
            return await _context.Recipes
                .OrderByDescending(r => r.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<Recipe>> GetAllRecipesAsync()
        {
            return await _context.Recipes
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }
    }
}