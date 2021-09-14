using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrandmaCookieFactory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GrandmaCookieFactory.Pages.Recipe
{
    public class AddRecipeModel : PageModel
    {
        [BindProperty]
        public RecipeModel Recipe { get; set; }
        public List<RecipeModel> RecipeList { get; set; } = new List<RecipeModel>();

        public int NumberOfIngredients { get; set; }
        [BindProperty]
        public string[] IngredientKeys { get; set; }
        [BindProperty]
        public string[] IngredientValues { get; set; }

        public void OnGet(int id = 2)
        {
            NumberOfIngredients = id;
            IngredientKeys = new string[NumberOfIngredients];
            IngredientValues = new string[NumberOfIngredients];

            string stringRecipe = HttpContext.Session.GetString("Recipe");

            if (!String.IsNullOrEmpty(stringRecipe))
            {
                RecipeList = JsonConvert.DeserializeObject<List<RecipeModel>>(stringRecipe);
            }
        }
        public IActionResult OnPost()
        {
            for (int i = 0; i < IngredientKeys.Length; i++)
            {
                Recipe.Ingredients.Add(IngredientKeys[i], IngredientValues[i]);
                RecipeList.Add(Recipe);
            }

            List<RecipeModel> recipes = new List<RecipeModel>();

            string stringRecipe = HttpContext.Session.GetString("Recipe");

            if (!String.IsNullOrEmpty(stringRecipe))
            {
                recipes = JsonConvert.DeserializeObject<List<RecipeModel>>(stringRecipe);
            }

            recipes.Add(Recipe);

            if (ModelState.IsValid)
            {
                stringRecipe = JsonConvert.SerializeObject(recipes);
                HttpContext.Session.SetString("Recipe", stringRecipe);

                return RedirectToPage("/Recipe/AddRecipe");

            }
            else
            {
                return Redirect("/Recipe/AddRecipe");
            }
        }
    }
}
