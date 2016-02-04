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

        private int _duration = 5;
        private int _callNumber = 0;

        public ThrottlingExampleViewModel()
        {
            Output = new ObservableCollection<string>();

            FirstNames = new ReadOnlyCollection<string>(new List<string> {"Joe", "Bill", "Victor"});

            LastNames = new ReadOnlyCollection<string>(new List<string> {"Smith", "White", "Black"});


            //var uiScheduler = new SynchronizationContextScheduler(SynchronizationContext.Current);

            //_requestParametersObservable = new Subject<Tuple<string, string>>();
            //_requestParametersObservable// .SubscribeOn(NewThreadScheduler.Default).Select(LoadData)
            //                            //.Select(parameters => Observable.Start(() => LoadData(parameters), ThreadPoolScheduler.Instance))
            //    .Select(parameters => Observable.FromAsync(token => LoadDataAsync(parameters, token)))
            //    .Switch()
            //    .ObserveOn(DispatcherScheduler.Current)
            //    .Subscribe(WriteData);
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
                // LoadData();
                Console.WriteLine("Setting First name o thread {0}", Thread.CurrentThread.ManagedThreadId);
                _requestParametersObservable.OnNext(new Tuple<string, string>(_selectedFirstName, _selectedLastName));
            }
        }

        public string SelectedLastName
        {
            get { return _selectedLastName; }
            set
            {
                _selectedLastName = value;
                // LoadData();

                _requestParametersObservable.OnNext(new Tuple<string, string>(_selectedFirstName, _selectedLastName));
            }
        }

        //private void LoadData()
        //{
        //    var service = ServiceFactory.GetService();

        //    var data = service.GetData(SelectedFirstName, SelectedLastName);
        //}

        //private void LoadData()
        //{
        //    var service = ServiceFactory.GetService();

        //    service.GetDataAsync(SelectedFirstName, SelectedLastName)
        //        .ContinueWith(task => Output.Insert(0, task.Result), TaskScheduler.FromCurrentSynchronizationContext());
        //}

        //private async void LoadData()
        //{
        //    var service = ServiceFactory.GetService();

        //    Output.Insert(0, await service.GetDataAsync(SelectedFirstName, SelectedLastName));
        //}


        private Subject<Tuple<string, string>> _requestParametersObservable;



        private string LoadData(Tuple<string, string> parameters)
        {
            var service = ServiceFactory.GetService();

            _duration = (_duration + 3)%5 + 1;

            return service.GetData((_callNumber++).ToString() + parameters.Item1, parameters.Item2, _duration);
            
            //Output.Insert(0, await service.GetDataAsync(parameters.Item1, parameters.Item2));
        }

        private async Task<string> LoadDataAsync(Tuple<string, string> parameters, CancellationToken token)
        {
            var service = ServiceFactory.GetService();

            _duration = (_duration + 3) % 5 + 1;

            return await service.GetDataAsync((_callNumber++).ToString() + parameters.Item1, parameters.Item2, _duration, token);

            //Output.Insert(0, await service.GetDataAsync(parameters.Item1, parameters.Item2));
        }

        private void WriteData(string data)
        {
            Output.Insert(0, data);
        }
    }
}


