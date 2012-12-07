using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;

namespace colle_tMedecine.ViewModel
{
    public class LiveChartsViewModel : BaseViewModel, ServiceLive.IServiceLiveCallback
    {
        private ObservableCollection<KeyValuePair<int, double>> _liveHeart;
        private ObservableCollection<KeyValuePair<int, double>> _liveTemp;
        private ServiceLive.ServiceLiveClient _service;

        public ObservableCollection<KeyValuePair<int, double>> LiveHeart
        {
            get { return _liveHeart; }
            set
            {
                if (_liveHeart != value || _liveHeart.Count != value.Count)
                {
                    _liveHeart = value;
                    OnPropertyChanged("LiveHeart");
                }
            }
        }

        public ObservableCollection<KeyValuePair<int, double>> LiveTemp
        {
            get { return _liveTemp; }
            set
            {
                if (_liveTemp != value || _liveTemp.Count != value.Count)
                {
                    _liveTemp = value;
                    OnPropertyChanged("LiveTemp");
                }
            }
        }

        public LiveChartsViewModel()
        {
            LiveHeart = new ObservableCollection<KeyValuePair<int, double>>();
            LiveTemp = new ObservableCollection<KeyValuePair<int, double>>();

            InstanceContext context = new InstanceContext(this);
            _service = new ServiceLive.ServiceLiveClient(context);
            _service.Subscribe();
        }

        public void PushDataHeart(double requestData)
        {
            LiveHeart = new ObservableCollection<KeyValuePair<int,double>>(_liveHeart.Where(x => x.Key > LiveHeart.Count - 20));
            LiveHeart.Add(new KeyValuePair<int, double>(_liveHeart.Count, requestData));
        }

        public void PushDataTemp(double requestData)
        {
            LiveTemp = new ObservableCollection<KeyValuePair<int, double>>(_liveTemp.Where(x => x.Key > _liveTemp.Count - 20));
            LiveTemp.Add(new KeyValuePair<int, double>(_liveTemp.Count, requestData));
        }

        public void StopService()
        {
            if (_service == null)
                return;

            while (_service.State != CommunicationState.Closed && _service.State != CommunicationState.Closing)
            {
                try
                {
                    _service.Close();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
