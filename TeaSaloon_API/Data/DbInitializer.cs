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

            ReadFakeProducts(context, logger);

            ReadFakeTeas(context, logger);

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

        private static void ReadFakeProducts(TeaSaloonContext context, ILogger logger)
        {
            // Vérifier s'il n'y a pas déjà des produits dans la DB
            if (context.Products.Any())
            {
                logger.LogInformation("La base de donnée contient déjà des produits...");
                return;
            }

            // On va chercher le chemin vers le fichier JSON
            // Path.Combine() permet de combiner plusieurs strings en un seul chemin
            // AppContext.BaseDirectory permet de retrouver le répertoire de base de l'application
            string jsonFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "products.json");

            if (!File.Exists(jsonFilePath))
            {
                logger.LogError("Le fichier products.json est introuvable...");
                return;
            }

            try
            {
                // On lit le fichier JSON
                string jsonData = File.ReadAllText(jsonFilePath);

                List<Product>? products = JsonSerializer.Deserialize<List<Product>>(
                    jsonData,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (products != null && products.Count > 0)
                {
                    context.Products.AddRange(products);
                    context.SaveChanges();
                    logger.LogInformation($"{products.Count} produits ont été ajoutés dans la table Products");
                }
                else
                {
                    logger.LogWarning("Aucun produit détecté dans le fichier products.json");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Erreur lors de la lecture du fichier JSON... " + ex.Message);
            }
        }

        private static void ReadFakeTeas(TeaSaloonContext context, ILogger logger)
        {
            // Vérifier s'il n'y a pas déjà des Teas dans la DB
            if (context.Teas.Any())
            {
                logger.LogInformation("La base de donnée contient déjà des teas...");
                return;
            }

            // On va chercher le chemin vers le fichier JSON
            // Path.Combine() permet de combiner plusieurs strings en un seul chemin
            // AppContext.BaseDirectory permet de retrouver le répertoire de base de l'application
            string jsonFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "teas.json");

            if (!File.Exists(jsonFilePath))
            {
                logger.LogError("Le fichier teas.json est introuvable...");
                return;
            }

            try
            {
                // On lit le fichier JSON
                string jsonData = File.ReadAllText(jsonFilePath);

                List<Tea>? teas = JsonSerializer.Deserialize<List<Tea>>(
                    jsonData,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (teas != null && teas.Count > 0)
                {
                    context.Teas.AddRange(teas);
                    context.SaveChanges();
                    logger.LogInformation($"{teas.Count} teas ont été ajoutés dans la table Teas");
                }
                else
                {
                    logger.LogWarning("Aucun tea détecté dans le fichier teas.json");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Erreur lors de la lecture du fichier JSON... " + ex.Message);
            }
        }


    }
}