using System;
using System.Collections.Generic;
using System.Linq;

namespace PostStore.Data.Utils
{
    public static class LambdaAndListExtensions
    {
        public static void With<T>(this T withObj, Action<T> withAction) where T : class
        {
            if (withObj != null)
                withAction(withObj);
        }

        public static TResult With<T, TResult>(this T withObj, Func<T, TResult> withFunction)
          where T : class
        {
            return (withFunction == null || withObj == null) ? default(TResult) : withFunction(withObj);
        }

        public static void WithNullable<T>(this T? withObj, Action<T?> withAction) where T : struct
        {
            if (withObj.HasValue)
                withAction(withObj);
        }

        public static TResult WithNullable<T, TResult>(this T? withObj, Func<T?, TResult> withFunction) where T : struct
        {
            return withObj.HasValue ? withFunction(withObj) : default(TResult);
        }

        public static void WithNull<T>(this T withObj, Action onNullAction) where T : class
        {
            if (withObj == null)
                onNullAction();
        }

        public static TResult WithNull<T, TResult>(this T withObj, Func<TResult> onNullAction) where T : class
        {
            return withObj == null ? onNullAction() : default(TResult);
        }

        public static void WithEmpty<T>(this IEnumerable<T> withCollection, Action<IEnumerable<T>> withAction) where T : class
        {
            if (withCollection != null && withCollection.Any())
                withAction(withCollection);
        }

        public static TResult WithEmpty<T, TResult>(this IEnumerable<T> withCollection, Func<IEnumerable<T>, TResult> withAction) where T : class
        {
            return (withCollection != null && withCollection.Any()) ? withAction(withCollection) : default(TResult);
        }

        public static T As<T>(this object objToConvert) where T : class
        {
            return objToConvert as T;
        }

        public static void WithType<T>(this object objToConvert, Action<T> withAction) where T : class
        {
            objToConvert.As<T>().With(withAction);
        }

        public static TResult WithType<T, TResult>(this object objToConvert, Func<T, TResult> withAction)
          where T : class
        {
            return objToConvert.As<T>().With(withAction);
        }

        public static void ForEach<T>(this IEnumerable<T> withCollection, Action<T> withAction)
          where T : class
        {
            withCollection.With(collection =>
              {
                  try
                  {
                      foreach (var element in collection)
                          withAction(element);
                  }
                  catch (Exception ex)
                  {
                      Console.WriteLine(ex.Message);
                  }
              });
        }

        public static string CatElements<T>(this IEnumerable<T> collectionToCat, string separator) where T : class
        {
            string result = string.Empty;
            collectionToCat.WithEmpty(collection => result = string.Join(separator, collection));
            return result;
        }
    }
}
