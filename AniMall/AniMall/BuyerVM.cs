using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace AniMall
{
    public class BuyerVM : INotifyPropertyChanged
    {
        MainWindowVM MVM;

        private Person user;
        public Person User
        {
            get { return user; }
            set
            {

            }
        }

        private double _total = 0;
        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                TotalCostDisp = "$" + string.Format("{0:N2}", _total);
                PropertyChanged(this, new PropertyChangedEventArgs("Total"));
            }
        }

        private string totalCostdisp;
        public string TotalCostDisp
        {
            get { return totalCostdisp; }
            set
            {
                totalCostdisp = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TotalCostDisp"));
            }
        }

        private string _qty;
        public string Qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Qty"));
            }
        }

//CONSTRUCTOR
        public BuyerVM(MainWindowVM mvm, Person User)
        {
            MVM = mvm;
        }

//EVENTS AND DELEGATES
        private void AddToCartClicked(object obj)
        {
            int purchAmt = int.Parse(Qty);
            //Animal selectAnimal = SelectedItem as Animal;
            //selectAnimal.Stock -= purchAmt;
            //selectAnimal.PurchAmt = purchAmt;
            //CartCont.Add(selectAnimal as object);
            //Total += selectAnimal.Price * purchAmt;
        }

        public ICommand AddToCartCommand
        {
            get
            {
                if (_addToCartEvent == null)
                {
                    _addToCartEvent = new DelegateCommand(AddToCartClicked);
                }

                return _addToCartEvent;
            }
        }
        DelegateCommand _addToCartEvent;

        private void OpenCartClicked(object obj)
        {

        }

        public ICommand OpenCartCommand
        {
            get
            {
                if (_openCartEvent == null)
                {
                    _openCartEvent = new DelegateCommand(OpenCartClicked);
                }

                return _openCartEvent;
            }
        }
        DelegateCommand _openCartEvent;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
