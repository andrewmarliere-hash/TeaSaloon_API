using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using TeaSaloon_API.Data;
using TeaSaloon_API.Models;

namespace PokIspoBowl_API.Data
{
    //Cette classe va nous permette d'initialiser la db
    //Elle va exécuter les migrations et les insert de données pour nous
    public static class DbInitializer
    {
        public static void Initialize(TeaSaloonContext context, ILogger logger)
        {
            //Même chose que quand on fait dotnet ef update etc...
            context.Database.Migrate();

            ReadFakeIngredients(context, logger);

            ReadFakeUsers(context, logger);

            ReadFakeCategories(context, logger);


        }

        private static void ReadFakeIngredients(TeaSaloonContext context, ILogger logger)
        {
            //Vérifier si il n'y a pas déjà des ingrédients dans la DB
            if (context.Ingredients.Any())
            {
                logger.LogInformation("La base de donnée contient déjà des ingrédients...");
                return;
            }

            //On va chercher le chemin vers le fichier JSON
            //Path.Combine() permet de combiner 3 strings en un seul string/chemin
            //AppContext.BaseDirectory permet de retrouver le répertoire de base de l'application
            string jsonFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "ingredients.json");

            if (!File.Exists(jsonFilePath))
            {
                logger.LogError("Le fichier ingredients.json est introuvable...");
                return;
            }

            try
            {
                //On va lire le fichier telquel
                string jsonData = File.ReadAllText(jsonFilePath);

                List<Ingredient>? ingredients = JsonSerializer.Deserialize<List<Ingredient>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (ingredients != null && ingredients.Count > 0)
                {
                    context.Ingredients.AddRange(ingredients);
                    context.SaveChanges();
                    logger.LogInformation($"{ingredients.Count()} ingredients ont été ajouté dans la table Ingredients");
                }
                else
                {
                    logger.LogWarning("Pas d'ingrédients detectés dans le fichier ingredients.json");
                }

            }
            catch (Exception ex)
            {
                logger.LogError("Erreur lors de la lecture du fichier JSON... " + ex.Message);
            }
        }


        private static void ReadFakeUsers(TeaSaloonContext context, ILogger logger)
        {
            //Vérifier si il n'y a pas déjà des Users dans la DB
            if (context.Users.Any())
            {
                logger.LogInformation("La base de donnée contient déjà des users...");
                return;
            }

            //On va chercher le chemin vers le fichier JSON
            //Path.Combine() permet de combiner 3 strings en un seul string/chemin
            //AppContext.BaseDirectory permet de retrouver le répertoire de base de l'application
            string jsonFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "users.json");

            if (!File.Exists(jsonFilePath))
            {
                logger.LogError("Le fichier users.json est introuvable...");
                return;
            }

            try
            {
                //On va lire le fichier telquel
                string jsonData = File.ReadAllText(jsonFilePath);

                List<User>? users = JsonSerializer.Deserialize<List<User>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (users != null && users.Count > 0)
                {
                    context.Users.AddRange(users);
                    context.SaveChanges();
                    logger.LogInformation($"{users.Count()} users ont été ajouté dans la table users");
                }
                else
                {
                    logger.LogWarning("Pas d'ingrédients detectés dans le fichier users.json");
                }

            }
            catch (Exception ex)
            {
                logger.LogError("Erreur lors de la lecture du fichier JSON... " + ex.Message);
            }
        }

        private static void ReadFakeCategories(TeaSaloonContext context, ILogger logger)
        {
            //Vérifier si il n'y a pas déjà des Categories dans la DB
            if (context.Categories.Any())
            {
                logger.LogInformation("La base de donnée contient déjà des categories...");
                return;
            }

            //On va chercher le chemin vers le fichier JSON
            //Path.Combine() permet de combiner 3 strings en un seul string/chemin
            //AppContext.BaseDirectory permet de retrouver le répertoire de base de l'application
            string jsonFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "categories.json");

            if (!File.Exists(jsonFilePath))
            {
                logger.LogError("Le fichier categories.json est introuvable...");
                return;
            }

            try
            {
                //On va lire le fichier telquel
                string jsonData = File.ReadAllText(jsonFilePath);

                List<Category>? categories = JsonSerializer.Deserialize<List<Category>>(
                    jsonData,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (categories != null && categories.Count > 0)
                {
                    context.Categories.AddRange(categories);
                    context.SaveChanges();
                    logger.LogInformation($"{categories.Count()} categories ont été ajouté dans la table categories");
                }
                else
                {
                    logger.LogWarning("Pas d'ingrédients detectés dans le fichier categories.json");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Erreur lors de la lecture du fichier JSON... " + ex.Message);
            }
        }

    }
}