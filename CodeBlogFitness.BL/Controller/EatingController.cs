using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер приема пищи.
    /// </summary>
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";

        #region Свойства
        /// <summary>
        /// Пользователь.
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Список продуктов.
        /// </summary>
        public List<Food> Foods { get; }

        /// <summary>
        /// Справочник приемов пищи.
        /// </summary>
        public Eating Eating { get; }
        #endregion

        /// <summary>
        /// Создание нового контроллера приенма пищи.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public EatingController(User user)
        {
            if (user is null)           
            {
                throw new ArgumentNullException("Пользователь не может быть равен null", nameof(user));
            }

            this.user = user;

            Foods = GetAllFoods();
            Eating = GetEating();
        }

        /// <summary>
        /// Добавление в прием пищи еды. 
        /// </summary>
        /// <param name="foodName"> Название еды. </param>
        /// <param name="weight"> Вес еды. </param>
        /// <returns></returns>
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        /// <summary>
        /// Получает список еды.
        /// </summary>
        /// <returns> Список еды. </returns>
        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        /// <summary>
        /// Получает список приемов пищи.
        /// </summary>
        /// <returns> Список пищи. </returns>
        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        /// <summary>
        /// Сохраняет список данных о еде и приемов пищи.
        /// </summary>
        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}
