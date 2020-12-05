using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ClassLibrary
{
    /// <summary>
    /// Сериализовать объект в json и десериализовать код json в объект C#.
    /// </summary>
    public class JSONConverter
    {
        /// <summary>
        /// Десериализовать код json в объект C#.
        /// </summary>
        /// <param name="json_string">Код json</param>
        /// <param name="list">Выходной параметр</param>
        static public void Deserialize(string json_string, out List<Products> list)
        {
            try
            {
                list = JsonSerializer.Deserialize<List<Products>>(json_string);
            }
            catch
            {
                throw new JSONExceptions("Невозможно преобразовать строку.");
            }
        }

        /// <summary>
        /// Десериализовать код json в список объектов C#.
        /// </summary>
        /// <param name="json_string">Код json</param>
        /// <param name="products">Выходной параметр</param>
        static public void Deserialize(string json_string, out Products products)
        {
            try
            {
                products = JsonSerializer.Deserialize<Products>(json_string);
            }
            catch
            {
                throw new JSONExceptions("Невозможно преобразовать строку.");
            }
        }
        /// <summary>
        /// Cериализовать объект в json.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        static public string Serialize(List<Products> list)
        {
            try
            {
                string json_string = JsonSerializer.Serialize<List<Products>>(list);
                return json_string;
            }
            catch
            {
                throw new JSONExceptions("Преобразование невозможно!");
            }

        }
        /// <summary>
        /// Cериализовать список объектов в json.
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        static public string Serialize(Products products)
        {
            try
            {
                string json_string = JsonSerializer.Serialize<Products>(products);
                return json_string;
            }
            catch
            {
                throw new JSONExceptions("Преобразование невозможно!");
            }

        }

        /// <summary>
        /// Десериализовать код json в объект C# из файла.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="products"></param>
        public static void DeserializeFromFile(String filename, out Products products)
        {
            try
            {
                using StreamReader sr = new StreamReader(filename);
                string json = sr.ReadToEnd().ToString();
                products = JsonSerializer.Deserialize<Products>(json);
            }
            catch
            {
                throw new JSONExceptions("Невозможно преобразовать строку. Файл поврежден!");
            }
        }
        /// <summary>
        /// Десериализовать код json в объект C# из файла.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="list"></param>
        public static void DeserializeFromFile(String filename, out List<Products> list)
        {
            try
            {
                using StreamReader sr = new StreamReader(filename);
                string json = sr.ReadToEnd().ToString();
                list = JsonSerializer.Deserialize<List<Products>>(json);
            }
            catch
            {
                throw new JSONExceptions("Невозможно преобразовать строку. Файл поврежден!");
            }
            
        }

        /// <summary>
        /// Cериализовать объект в файл .json.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="list"></param>
        public static void SerializeToFile(String filename, List<Products> list)
        {
            try
            {
                string json_string = JsonSerializer.Serialize<List<Products>>(list);
                StreamWriter sw = new StreamWriter(filename);
                sw.Write(json_string);
                sw.Close();
            }
            catch
            {
                throw new JSONExceptions("Преобразование невозможно!");
            }
        }

        /// <summary>
        /// Cериализовать объект в файл .json.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="products"></param>
        public static void SerializeToFile(String filename, Products products)
        {
            try
            {
                string json_string = JsonSerializer.Serialize<Products>(products);
                StreamWriter sw = new StreamWriter(filename);
                sw.Write(json_string);
                sw.Close();
            }
            catch
            {
                throw new JSONExceptions("Преобразование невозможно!");
            }
        }
    }
}
