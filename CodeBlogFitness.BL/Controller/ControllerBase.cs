using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        /// <summary>
        /// Сохраняет данные о продукте.
        /// </summary>
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        /// <summary>
        /// Загружает сохраненный список продуктов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"> Путь/название файла. </param>
        /// <returns> Список продуктов. </returns>
        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
