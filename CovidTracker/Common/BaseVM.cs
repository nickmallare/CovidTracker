using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CovidTracker.Common
{
    public class BaseVM : INotifyPropertyChanged
    {
        public BaseVM() 
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
