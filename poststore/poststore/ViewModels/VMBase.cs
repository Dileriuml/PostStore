using System.ComponentModel;

using PostStore.Data.Utils;
using System.Runtime.CompilerServices;

namespace PostStore.ViewModels
{
    public class VMBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected internal void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            handler.With(hEvent => hEvent(this, new PropertyChangedEventArgs(propertyName)));
        }

        #endregion
    }
}
