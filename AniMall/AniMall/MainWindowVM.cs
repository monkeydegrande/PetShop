using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace AniMall
{
    public class MainWindowVM : INotifyPropertyChanged
    {

        //PROPERTIES
        #region Properties
        public MainWindow MW { get; set; }

        public object PreviousVM { get; set; }

        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CurrentView"));
            }
        }

        private Person user = new Person();
        public Person User
        {
            get { return user; }
            set
            {
                user = value;
                PropertyChanged(this, new PropertyChangedEventArgs("User"));
            }
        }

        //List of People
        public ObservableCollection<Person> People = new ObservableCollection<Person>();
        public ObservableCollection<Animal> Products = new ObservableCollection<Animal>();

        //Main csv data file
        readonly string PeoplePath = "people.xml";
        readonly string ProductsPath = "products.xml";

        //XML Serializer
        XmlSerializer PeepsXmler = new XmlSerializer(typeof(ObservableCollection<Person>));
        XmlSerializer ProdsXmler = new XmlSerializer(typeof(ObservableCollection<Animal>));
        #endregion

        //CONSTRUCTOR  
        public MainWindowVM()
        {
            ReadPeopleFile();
            ReadProductFile();
        }

//READING AND WRITING FILE FUNCTIONS
        //Read in XML to get Users List 
        public void ReadPeopleFile()
        {
            if (File.Exists(PeoplePath))
            {
                try
                {
                    using (FileStream ReadStream = new FileStream(PeoplePath, FileMode.Open, FileAccess.Read))
                    {
                        People = PeepsXmler.Deserialize(ReadStream)
                        as ObservableCollection<Person>;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to read XML file", ex.InnerException);
                    MessageBox.Show($"Unable to read XML file\nInnerException:{ ex.InnerException.Message}");
                }
                CurrentView = new LoginVM(this);
            }
            else
            {
                if (MessageBox.Show("There are no users on file. Would you like to create one?",
                    "No Users File", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    CurrentView = new CreateVM(this);
                }
                else
                {
                    App.Current.Shutdown();
                }
            }
        }

        //Read in XML to get products List 
        public void ReadProductFile()
        {
            if (File.Exists(ProductsPath))
            {
                try
                {
                    using (FileStream ReadStream = new FileStream(ProductsPath, FileMode.Open, FileAccess.Read))
                    {
                        Products = ProdsXmler.Deserialize(ReadStream)
                        as ObservableCollection<Animal>;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to read products file", ex.InnerException);
                    MessageBox.Show($"Unable to read products file\nInnerException:{ ex.InnerException.Message}");
                }
            }
            else
            {
                MessageBox.Show("There are no products on file.");
                App.Current.Shutdown();
            }
        }
        //Write to Xml file
        public void WriteXmlFile(ObservableCollection<Person> People)
        {
            //Ensure there isn't an empty Xml file
            if (People.Count == 0)
            {
                if (File.Exists(PeoplePath))
                {
                    File.Delete(PeoplePath);
                }
                MessageBox.Show("No data to save. Try adding a emp first.");
            }
            else
            {
                using (FileStream fs = new FileStream(PeoplePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    PeepsXmler.Serialize(fs, People);
                }
            }
        }

        //DELEGATES AND BUTTONCLICKS

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}
