using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        #region Свойства
        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Список известных продуктов.
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }
        #endregion

        /// <summary>
        /// Создание нового приема пищи.
        /// </summary>
        /// <param name="user"> Пользователь, которых жрет. </param>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }       

        /// <summary>
        /// Добавление новых продуктов в существующий список продуктов.
        /// </summary>
        /// <param name="food"> Продукт. </param>
        /// <param name="weight"> Вес. </param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
