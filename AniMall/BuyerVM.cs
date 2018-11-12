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
        public TabItem Tab { get; set; }  //TO-DO 

        private ObservableCollection<object> cartCont = new ObservableCollection<object>();
        public ObservableCollection<object> CartCont
        {
            get { return cartCont; }
            set
            {
                cartCont = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CartCont"));
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

        public BuyerVM() { }

        private void AddToCartClicked(object obj)
        {
            ContentControl cc = Tab.Content as ContentControl;
            ListBox lb = cc.Content as ListBox;
            int purchAmt = int.Parse(Qty);
            Animal selectAnimal = lb.SelectedItem as Animal;
            selectAnimal.Stock -= purchAmt;
            selectAnimal.PurchAmt = purchAmt;
            CartCont.Add(selectAnimal as object);
            Total += selectAnimal.Price * purchAmt;
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
            CartVM shoppingCartVM = new CartVM(this);
            Cart cart = new Cart();
            cart.DataContext = shoppingCartVM;
            cart.Show();
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
