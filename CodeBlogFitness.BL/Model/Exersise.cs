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
        #region Свойства

        public int Id { get; set; }

        /// <summary>
        /// Нвчало упражнения.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Конец упражнения.
        /// </summary>
        public DateTime Finish { get; set; }

        public int ActivityId { get; set; }

        /// <summary>
        /// Вид упражнения.
        /// </summary>
        public virtual Activity Activity { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }
        #endregion

        public Exercise() { }
        

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
