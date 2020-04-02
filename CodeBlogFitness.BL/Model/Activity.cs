using System;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Справочник активности.
    /// </summary>
    /// 
    [Serializable]
    public class Activity
    {
        /// <summary>
        /// Название активности.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сжигание калориев в минуту.
        /// </summary>
        public double CaloriesPerMinute { get; set; }

        /// <summary>
        /// Создание активность.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="caloriesPerMinute"></param>
        public Activity(string name, double caloriesPerMinute)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
