using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PetShop
{
    public class CartVM : INotifyPropertyChanged
    {
        public MainWindowVM Parent { get; set; }
        public CartVM(MainWindowVM parent) { Parent = parent; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void UpdateCartClicked(object obj)
        {
            double sumTotal = 0;
            List<object> toDelete = new List<object>();

            foreach (object cartObject in Parent.CartCont)
            {
                    Animal an = cartObject as Animal;
                    sumTotal +=an.Price * an.PurchAmt;
                    if (an.PurchAmt == 0) { toDelete.Add(an); }
            }

            foreach (object itemToDelete in toDelete) { Parent.CartCont.Remove(itemToDelete); }
            Parent.Total = sumTotal;
        }
        public ICommand UpdateCartCommand
        {
            get
            {
                if (_updateCartEvent == null)
                {
                    _updateCartEvent = new DelegateCommand(UpdateCartClicked);
                }

                return _updateCartEvent;
            }
        }
        DelegateCommand _updateCartEvent;
    }
}
