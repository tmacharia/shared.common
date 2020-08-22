using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Common.Models;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class ReflectionFluentExts
    {
        /// <summary>
        /// Checks if there are any changes between two versions of a model and updates the 
        /// values of the specified properties in the old/base model with new 
        /// property values from the updated model.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="baseModel"></param>
        /// <param name="updatedModel"></param>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        public static TModel UpdateWith<TModel>(this TModel baseModel, TModel updatedModel, params Expression<Func<TModel,object>>[] propertySelectors) 
            where TModel : class
        {
            if (baseModel == null)
                throw new ArgumentNullException(nameof(baseModel));

            if (updatedModel == null)
                throw new ArgumentNullException(nameof(updatedModel));

            if (propertySelectors == null || propertySelectors.Length < 1)
                throw new ArgumentNullException(nameof(propertySelectors), "Specify atleast 1 property selector to update");

            string[] props = baseModel.GetMemberNames(propertySelectors);

            for (int i = 0; i < props.Length; i++)
            {
                object oldValue = baseModel.GetPropertyValue<TModel, object>(props[i]);
                object newValue = updatedModel.GetPropertyValue<TModel, object>(props[i]);

                if (newValue != oldValue)
                    baseModel.SetPropertyValue(props[i], newValue);
            }

            return baseModel;
        }
        /// <summary>
        /// Checks if there are any changes between two versions of a model and updates the 
        /// values of the specified properties in the old/base model with new 
        /// property values from the updated model.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="baseModel"></param>
        /// <param name="updatedModel"></param>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        public static UpdateResult<TModel> GetPropertyUpdates<TModel>(this TModel baseModel, TModel updatedModel, params Expression<Func<TModel, object>>[] propertySelectors)
            where TModel : class
        {
            UpdateResult<TModel> updates = new UpdateResult<TModel>
            {
                BaseModel = baseModel ?? throw new ArgumentNullException(nameof(baseModel)),
                UpdatedModel = updatedModel ?? throw new ArgumentNullException(nameof(updatedModel))
            };

            string[] props = baseModel.GetMemberNames(propertySelectors);

            for (int i = 0; i < props.Length; i++)
            {
                object oldValue = baseModel.GetPropertyValue<TModel, object>(props[i]);
                object newValue = updatedModel.GetPropertyValue<TModel, object>(props[i]);

                updates.PropertyUpdates.Add(new PropertyUpdateResult(props[i],oldValue,newValue));
            }
            return updates;
        }
        private static string GetMemberName<T, TProperty>(this T instance, Expression<Func<T, TProperty>> expression)
        {
            return ExpressionExts.GetMemberName(expression.Body);
        }
        private static string[] GetMemberNames<T, TProperty>(this T instance, params Expression<Func<T, TProperty>>[] expressions)
        {
            List<string> memberNames = new List<string>();
            foreach (var cExpression in expressions)
                memberNames.Add(ExpressionExts.GetMemberName(cExpression.Body));

            return memberNames.ToArray();
        }
        private static string GetMemberName<T>(this T instance, Expression<Action<T>> expression)
        {
            return ExpressionExts.GetMemberName(expression.Body);
        }
    }
}