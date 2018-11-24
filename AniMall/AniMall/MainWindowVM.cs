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
        public MainWindow MW { get; set; }
        private object currentView;

        public object CurrentView
        {
            get { return currentView; }

            set { currentView = value; OnPropertyChanged("CurrentView"); }

        }

        public Person User;

        //List of People
        public ObservableCollection<Person> People = new ObservableCollection<Person>();

        //Main csv data file
        static string PeoplePath = "people.xml";

        //XML Serializer
        static XmlSerializer Xmler = new XmlSerializer(typeof(ObservableCollection<Person>));

//CONSTRUCTOR  
        public MainWindowVM()
        {
            ReadPeopleFile();
        }



//READING AND WRITING FILE FUNCTIONS
        //Read in XML to get Students List 
        public void ReadPeopleFile()
        {
            if (File.Exists(PeoplePath))
            {
                try
                {
                    using (FileStream ReadStream = new FileStream(PeoplePath, FileMode.Open, FileAccess.Read))
                    {
                        People = Xmler.Deserialize(ReadStream)
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
                    CurrentView = new CreateVM();
                }
                else
                {
                    App.Current.Shutdown();
                }
            }
        }

        //Write to Xml file
        static public void WriteXmlFile(ObservableCollection<Person> People)
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
                    Xmler.Serialize(fs, People);
                }
            }
        }


//DELEGATES AND BUTTONCLICKS
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
