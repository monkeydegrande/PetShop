using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AniMall
{
    public class CartVM : INotifyPropertyChanged
    {
        #region Properties
        public MainWindowVM MVM { get; set; }

        private Person user;
        public Person User
        {
            get { return user; }
            set
            {
                user = value;
            }
        }

        //private double totalCost;
        //public double TotalCost
        //{
        //    get { return totalCost; }
        //    set
        //    {
        //        totalCost = value;
        //        PropertyChanged(this, new PropertyChangedEventArgs("TotalCost"));
        //    }
        //}

       //private int items;
        //public int Items
        //{
        //    get { return items; }
        //    set
        //    {
        //        items = value;
        //        PropertyChanged(this, new PropertyChangedEventArgs("Items"));
        //    }
        //}

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
        public CartVM(MainWindowVM mvm)
        {
            MVM = mvm;
            User = MVM.User;
            CalculateTotals();
        }

//METHODS
        private void CalculateTotals()
        {
            User.Cart.Total = 0;
            User.Cart.Items = 0;
            foreach (Animal an in User.Cart.CartCont)
            {
                User.Cart.Total += an.Price * an.PurchAmt;
                User.Cart.Items += an.PurchAmt;
            }
        }
        public void RemoveClicked(object obj)
        {
            User.Cart.CartCont.Remove(SelectedAnimal);
            CalculateTotals(); 
        }
        public ICommand RemoveCommand
        {
            get
            {
                if (removeEvent == null)
                {
                    removeEvent = new DelegateCommand(RemoveClicked);
                }

                return removeEvent;
            }
        }
        DelegateCommand removeEvent;

        private void SaveClick(object obj)
        {
            Person temp = new Person();
            temp = MVM.People.Where(x => x.FirstName == User.FirstName && x.LastName == User.LastName) as Person;
            MVM.People.Remove(temp);
            MVM.People.Add(User);
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

        private void ContinueClick(object obj)
        {
            MVM.CurrentView = MVM.PreviousVM;
        }
        public ICommand ContinueCommand
        {
            get
            {
                if (continueEvent == null)
                {
                    continueEvent = new DelegateCommand(ContinueClick);
                }
                return continueEvent;
            }
        }
        DelegateCommand continueEvent;

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
