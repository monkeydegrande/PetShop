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

        private ObservableCollection<Animal> products;
        public ObservableCollection<Animal> Products
        {
            get { return products; }
            set
            {
                products = value;
            }
        }

        #region Properties

        private Person user;
        public Person User
        {
            get { return user; }
            set
            {
                user = value;
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
        #endregion

//CONSTRUCTOR
        public BuyerVM(MainWindowVM mvm, Person u)
        {
            MVM = mvm;
            User = u;
            products = MVM.Products;
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

        //Menu Exit Click
        private void ExitClick(object obj)
        {
            App.Current.Shutdown();
        }

        public ICommand ExitCommand
        {
            get
            {
                if (_exitEvent == null)
                {
                    _exitEvent = new DelegateCommand(ExitClick);
                }

                return _exitEvent;
            }
        }

        DelegateCommand _exitEvent;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
