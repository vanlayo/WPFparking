﻿using parking.Extensions;
using parking.Messages;
using parking.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace parking.ViewModel
{
    public class ParkingViewModel : BaseViewModel
    {

        private ObservableCollection<ParkPlace> parkPlaces;

        public ObservableCollection<ParkPlace> ParkPlaces
        {
            get
            {
                return parkPlaces;
            }
            set
            {
                parkPlaces = value;
                NotifyPropertyChanged();
            }
        }

        private ParkPlace selectedParkPlace;
        public ParkPlace SelectedParkPlace
        {
            get
            {
                return selectedParkPlace;
            }
            set
            {
                selectedParkPlace = value;
                NotifyPropertyChanged();
            }
        }


        private ICommand toevoegenCommand;
        public ICommand ToevoegenCommand
        {
            get
            {
                return toevoegenCommand;
            }

            set
            {
                toevoegenCommand = value;
            }
        }

        private ICommand wijzigenCommand;
        public ICommand WijzigenCommand
        {
            get
            {
                return wijzigenCommand;
            }

            set
            {
                wijzigenCommand = value;
            }
        }


        private DialogService dialogService;

        public ParkingViewModel()
        {
            //laden data
            ParkPlaceDataService ds = new ParkPlaceDataService();
            parkPlaces = ds.GetParkPlace();

            //instantiëren DialogService als singleton
            dialogService = new DialogService();

            //koppelen commands
            WijzigenCommand = new BaseCommand(WijzigenParkPlace);
            ToevoegenCommand = new BaseCommand(ToevoegenParkPlace);

            //luisteren naar messages vanuit detailvenster
            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);

        }

        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            //na update of delete mag detailvenster sluiten
            dialogService.CloseDetailDialog();

            //na Delete/Insert moet collectie Koffies terug ingeladen worden
            if (message.Type != UpdateFinishedMessage.MessageType.Updated)
            {
                ParkPlaceDataService ds = new ParkPlaceDataService();
                parkPlaces = ds.GetParkPlace();
            }

        }

        private void ToevoegenParkPlace()
        {

            SelectedParkPlace = new ParkPlace();

            Messenger.Default.Send<ParkPlace>(SelectedParkPlace);

            dialogService.ShowDetailDialog();

        }

        private void WijzigenParkPlace()
        {
            if (SelectedParkPlace != null)
            {
                Messenger.Default.Send<ParkPlace>(SelectedParkPlace);

                dialogService.ShowDetailDialog();
            }
        }


    }
}
