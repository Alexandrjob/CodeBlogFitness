using System;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Еда любимая.
    /// </summary>  
    [Serializable]
    public class Food
    {
        #region Свойства
        /// <summary>
        /// Название еды.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Калории за 100 грамм продукта.
        /// </summary>
        public double Calories { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }
        #endregion

        /// <summary>
        /// Получить готовый продукт по имени.
        /// </summary>
        /// <param name="name"> Название продукта. </param>
        public Food(string name) : this(name, 0, 0, 0, 0) { }

        /// <summary>
        /// Создать новую еду.
        /// </summary>
        /// <param name="name"> Название еды. </param>
        /// <param name="calories"> Калории за 100 грамм продукта. </param>
        /// <param name="proteins"> Белки.</param>
        /// <param name="fats"> Жиры. </param>
        /// <param name="carbohydrates"> Углеводы. </param>
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            //TODO: проверка

            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
