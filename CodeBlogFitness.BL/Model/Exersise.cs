using System;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Упражнение.
    /// </summary>
    /// 
    [Serializable]
    public class Exercise
    {
        #region
        /// <summary>
        /// Нвчало упражнения.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Конец упражнения.
        /// </summary>
        public DateTime Finish { get; set; }

        /// <summary>
        /// Вид упражнения.
        /// </summary>
        public Activity Activity { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; set; }
        #endregion
        /// <summary>
        /// Создать новое упражнение.
        /// </summary>
        /// <param name="dateTime"> Начало упражнения. </param>
        /// <param name="fihish"> Конец упражнения. </param>
        /// <param name="activity"> Что это? </param>
        /// <param name="user"> Пользователь. </param>
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            //TODO: проверка.

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;

        }
    }
}
