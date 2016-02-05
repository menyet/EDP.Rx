using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using EPD.Rx.Service;
using GalaSoft.MvvmLight;

namespace EPD.Rx.WPF.Throttling
{
    public class ThrottlingExampleViewModel : ViewModelBase
    {
        private string _selectedFirstName;
        private string _selectedLastName;

        public ThrottlingExampleViewModel()
        {
            Output = new ObservableCollection<string>();

            FirstNames = new ReadOnlyCollection<string>(new List<string> {"Joe", "Bill", "Victor"});

            LastNames = new ReadOnlyCollection<string>(new List<string> {"Smith", "White", "Black"});
        }

        public ObservableCollection<string> Output { get; private set; }

        public ReadOnlyCollection<string> FirstNames { get; private set; }

        public ReadOnlyCollection<string> LastNames { get; private set; }

        public string SelectedFirstName
        {
            get { return _selectedFirstName; }
            set
            {
                _selectedFirstName = value;
                LoadData();
            }
        }

        public string SelectedLastName
        {
            get { return _selectedLastName; }
            set
            {
                _selectedLastName = value;
                LoadData();
            }
        }

        private void LoadData()
        {
            var service = ServiceFactory.GetService();

            var data = service.GetData(SelectedFirstName, SelectedLastName, 5);

            WriteData(data);
        }

        private void WriteData(string data)
        {
            Output.Insert(0, data);
        }
    }
}


