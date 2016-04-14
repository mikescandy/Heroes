using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns a new Observable collection based on the IEnumerable
        /// </summary>
        /// <returns>A new observable collecion.</returns>
        /// <param name="src">The source IEnumerable.</param>
        /// <typeparam name="T">The IEnumerable type</typeparam>
        public static ObservableCollection<T> ToObservable<T> (this IEnumerable<T> src)
        {
            if (src == null) {
                throw new ArgumentNullException ("src");
            }
            if (src is ObservableCollection<T>) {
                return src as ObservableCollection<T>;
            }
            if (src != null) {
                return new ObservableCollection<T> (src);
            }
            return default (ObservableCollection<T>);
        }
    }
}