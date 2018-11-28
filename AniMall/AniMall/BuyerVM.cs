using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace AniMall
{
    public class BuyerVM : INotifyPropertyChanged
    {
        public MainWindowVM MVM;

        #region Properties
        private ObservableCollection<Animal> products;
        public ObservableCollection<Animal> Products
        {
            get { return products; }
            set
            {
                products = value;
            }
        }

        private Person user;
        public Person User
        {
            get { return user; }
            set
            {
                user = value;
            }
        }

        private double total = 0;
        public double Total
        {
            get { return total; }
            set
            {
                total = value;
                TotalCostDisp = "$" + string.Format("{0:N2}", total);
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

        private string qty;
        public string Qty
        {
            get { return qty; }
            set
            {
                qty = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Qty"));
            }
        }

        private Animal selectedAnimal;
        public Animal SelectedAnimal
        {
            get { return selectedAnimal; }
            set
            {
                selectedAnimal = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedAnimal"));
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
            if (selectedAnimal != null)
            {
                int purchAmt;
                Int32.TryParse(qty, out purchAmt);

                if (purchAmt <= selectedAnimal.Stock)
                {
                    selectedAnimal.Stock -= purchAmt;
                    selectedAnimal.PurchAmt = purchAmt;
                    User.Cart.CartCont.Add(selectedAnimal);
                    total += selectedAnimal.Price * purchAmt;
                }
                else
                {
                    MessageBox.Show("Not enough in stock");
                    Qty = selectedAnimal.Stock.ToString();
                }
            }

        }
        public ICommand AddToCartCommand
        {
            get
            {
                if (addToCartEvent == null)
                {
                    addToCartEvent = new DelegateCommand(AddToCartClicked);
                }

                return addToCartEvent;
            }
        }
        DelegateCommand addToCartEvent;

        private void OpenCartClicked(object obj)
        {
            CartVM CVM = new CartVM(MVM);
            MVM.PreviousVM = this;
            MVM.CurrentView = CVM;
        }
        public ICommand OpenCartCommand
        {
            get
            {
                if (openCartEvent == null)
                {
                    openCartEvent = new DelegateCommand(OpenCartClicked);
                }

                return openCartEvent;
            }
        }
        DelegateCommand openCartEvent;

        private void SaveClick(object obj)
        {
            Person temp = new Person();
            temp = MVM.People.FirstOrDefault(x => x.UserName == User.UserName);
            temp.Cart = User.Cart;
            MVM.WriteXmlFile(MVM.People);
        }
        public ICommand SaveCommand
        {
            get
            {
                if (saveEvent == null)
                {
                    saveEvent = new DelegateCommand(SaveClick);
                }

                return saveEvent;
            }
        }
        DelegateCommand saveEvent;

        private void LogoutClick(object obj)
        {
            MVM.User = new Person();
            MVM.ReadPeopleFile();
            MVM.ReadProductFile();
            MVM.CurrentView = new LoginVM(MVM);
        }
        public ICommand LogoutCommand
        {
            get
            {
                if (logoutEvent == null)
                {
                    logoutEvent = new DelegateCommand(LogoutClick);
                }
                return logoutEvent;
            }
        }
        DelegateCommand logoutEvent;

        //Menu Exit Click
        private void ExitClick(object obj)
        {
            App.Current.Shutdown();
        }
        public ICommand ExitCommand
        {
            get
            {
                if (exitEvent == null)
                {
                    exitEvent = new DelegateCommand(ExitClick);
                }

                return exitEvent;
            }
        }
        DelegateCommand exitEvent;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
