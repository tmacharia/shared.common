using System;
using System.Collections;
using System.Collections.Generic;
using System.Extensions;
using System.IO;
using System.Linq;
using Common.Models;
using Newtonsoft.Json;
using static System.Environment;

namespace Common
{
    /// <summary>
    /// Represents a service to store and retrieve data in your app's
    /// local application folder
    /// </summary>
    [Obsolete]
    public static class Backpack
    {
        /// <summary>
        /// Name of folder to use inside of <see cref="SpecialFolder.LocalApplicationData"/>
        /// </summary>
        public static string FolderName = "Data";
        /// <summary>
        /// Full path of the folder.
        /// </summary>
        public static string AppFolder { get; } = GetAppFolderPath(Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), FolderName));

        #region Local Functions
        /// <summary>
        /// Adds or updates a model to the <typeparamref name="T"/> data store
        /// based on its Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T AddOrUpdate<T>(T model) where T : RootModel
        {
            if (model != null)
            {
                var list = GetEntities<T>();
                var prev = list.FirstOrDefault(x => x.Id == model.Id);
                if (prev == null)
                {
                    model.Timestamp = DateTime.Now;
                }
                else
                {
                    list = list.RemoveWherePredicate(x => x.Id == prev.Id).ToList();
                    model.Timestamp = prev.Timestamp;
                    model.LastModified = DateTime.Now;
                }
                list.Add(model);
                Save<T>(list);
                return model;
            }
            return null;
        }
        /// <summary>
        /// Checks if the store for <typeparamref name="T"/> contains
        /// an item with the specified id.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Id of the item.</param>
        /// <returns></returns>
        public static bool Contains<T>(string id) where T : RootModel
            => GetById<T>(id: id) != null;
        /// <summary>
        /// Checks if the store for <typeparamref name="T"/> contains
        /// an item matching the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool ContainsWhere<T>(Func<T, bool> func) where T : RootModel
            => GetWhere(func) != null;
        /// <summary>
        /// Get an item with the speicified id from the <typeparamref name="T"/> store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Id of the item to get</param>
        /// <returns></returns>
        public static T GetById<T>(string id) where T : RootModel
        {
            if (id.IsValid())
            {
                var list = GetEntities<T>();
                return list.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }
        /// <summary>
        /// Get an item matching the speicified predicate from the <typeparamref name="T"/> store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T GetWhere<T>(Func<T, bool> predicate) where T : RootModel
        {
            if (predicate != null)
            {
                var list = GetEntities<T>();
                return list.FirstOrDefault(predicate);
            }
            return null;
        }
        /// <summary>
        /// Removes items with the specified ids from the <typeparamref name="T"/> store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        public static void RemoveModel<T>(params string[] ids) where T : RootModel
        {
            if (ids != null && ids.Length > 0)
            {
                var list = GetEntities<T>();
                ids.ForEach(id =>
                {
                    list = list.RemoveWherePredicate(x => x.Id == id).ToList();
                });
                Save<T>(list);
            }
        }
        /// <summary>
        /// Clear/Delete all items in the <typeparamref name="T"/> store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Clear<T>() where T : RootModel
        {
            var list = GetEntities<T>();
            list.Clear();
            Save<T>(list);
        }
        /// <summary>
        /// Gets a list of all items in the <typeparamref name="T"/> store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> GetEntities<T>() where T : RootModel
        {
            string _path = GetAppFilePath<T>();
            return _path.IsValid() ? GetEntities<T>(_path) : new List<T>();
        }
        /// <summary>
        /// Gets a list of all items from a specified file casting the results
        /// to <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IList<T> GetEntities<T>(string path) where T : RootModel
        {
            IList<T> list = GetFile<List<T>>(path);
            return list != null ? list.Ordered() : new List<T>();
        }
        private static void Save<T>(object obj) where T : class
        {
            string path = GetAppFilePath<T>();
            File.WriteAllText(path, string.Empty);
            File.WriteAllText(path, obj.ToJson());
        }
        private static void Save(string path, object obj)
        {
            File.WriteAllText(path, string.Empty);
            File.WriteAllText(path, obj.ToJson());
        }
       
        private static T GetFile<T>() where T : class
            => GetFile(GetAppFilePath<T>()).DeserializeTo<T>();
        private static T GetFile<T>(string path) => GetFile(path).DeserializeTo<T>();
        /// <summary>
        /// Orders items in descending order by Timestamp or LastModified date.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static IList<T> Ordered<T>(this IEnumerable<T> ts) where T : RootModel
        {
            return ts.OrderByDescending(x => x.LastModified ?? x.Timestamp).ToList();
        }
        private static string GetFile(string path)
        {
            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        /// <summary>
        /// Gets full filepath to use for mapping to a <typeparamref name="T"/> store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetAppFilePath<T>() => Path.Combine(AppFolder, PredictFileName<T>() + ".json");
        /// <summary>
        /// Tries to get name to use as filename from a generic <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string PredictFileName<T>()
        {
            Type type = typeof(T);
            if (typeof(IEnumerable).IsAssignableFrom(type))
                type = type.GenericTypeArguments[0];
            string name = type.Name;
            return name.CleanFileName().ToLower();
        }
        private static string GetAppFolderPath(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
        #endregion
    }
}