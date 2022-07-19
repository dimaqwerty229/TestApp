using System.Windows;
using WpfApp1.Core;
using System.Windows.Controls;

namespace WpfApp1.MVVM.ViewModel
{
    class MainViewModel : ObserbavleObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand CurrencyViewCommand { get; set; }
        public HomeViewModel HomeVm { get; set; }
        public CurrencyViewModel CurrencyVM{ get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            CurrencyVM = new CurrencyViewModel();
            CurrentView = HomeVm;
            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });
            
            CurrencyViewCommand = new RelayCommand(o =>
            {
                CurrentView = CurrencyVM;
            });
        }
    }
}
