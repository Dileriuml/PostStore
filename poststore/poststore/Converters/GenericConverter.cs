using System;
using System.Globalization;
using System.Windows.Data;

namespace PostStore.Converters
{
    public class GenericConverter<TFrom, TTo> : IValueConverter
    {
        #region Fields

        private Func<TFrom, TTo> convertFunc;
        private Func<TTo, TFrom> convertBackFunc;
        
        #endregion

        #region Consrtuctors

        public GenericConverter(Func<TFrom, TTo> convertFunc, Func<TTo, TFrom> convertBackFunc = null)
        {
            this.convertFunc = convertFunc;
            this.convertBackFunc = convertBackFunc;
        }

        #endregion

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (convertFunc == null)
            {
                return value;
            }
            
            return convertFunc((TFrom)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (convertBackFunc == null)
            {
                return value;
            }

            return convertBackFunc((TTo)value);
        }

        #endregion
    }
}
