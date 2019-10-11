using System;

namespace Common.Conversion
{
    /// <summary>
    /// Defines a service that can convert instances from one type to another
    /// </summary>
    public interface IConversionService
    {
        /// <summary>
        /// Converts <paramref name="source"/> to an instance of type <paramref name="targetType"/>
        /// </summary>
        /// <param name="targetType">The type to convert to</param>
        /// <param name="source">The thing to be converted</param>
        /// <returns>An instance of <paramref name="targetType"/></returns>
        object Convert(object source, Type targetType);

        /// <summary>
        /// Maps the values of the properties on the <paramref name="source"/> object to 
        /// the values of the properties on the <paramref name="target"/> object
        /// </summary>
        void Map(object source, object target);
    }
}
