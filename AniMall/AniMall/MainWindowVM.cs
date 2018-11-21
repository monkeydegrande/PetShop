using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace AniMall
{
    public class MainWindowVM
    {

//PROPERTIES
        public MainWindow MainWindow { get; set; }
        public LoginVM LoginVM { get; set; }
        public BuyerVM BuyerVM { get; set; }
        public SellerVM SellerVM { get; set; }
        public CartVM CartVM { get; set; }
        public CreateVM CreateUserVM { get; set; }

        public Person User;

        //XML Serializer
        static XmlSerializer Xmler = new XmlSerializer(typeof(ObservableCollection<Person>));

        //List of People
        public ObservableCollection<Person> People = new ObservableCollection<Person>();

        //Main csv data file
        static string XmlPath = "people.xml";

//CONSTRUCTOR  
        public MainWindowVM(MainWindow MW)
        {
            LoginVM = new LoginVM(this);
        }

//READING AND WRITING FILE FUNCTIONS
        //Read in XML to get Students List 
        public void ReadPeopleFile()
        {
            if (File.Exists(XmlPath))
            {
                try
                {
                    using (FileStream ReadStream = new FileStream(XmlPath, FileMode.Open, FileAccess.Read))
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
            }
            else
            {
                if (MessageBox.Show("There are no users on file. Would you like to create one?",
                    "No Users File", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MainWindow.Login.Visibility = Visibility.Hidden;
                    MainWindow.Create.Visibility = Visibility.Visible;
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
                if (File.Exists(XmlPath))
                {
                    File.Delete(XmlPath);
                }
                MessageBox.Show("No data to save. Try adding a emp first.");
            }
            else
            {
                using (FileStream fs = new FileStream(XmlPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    Xmler.Serialize(fs, People);
                }
            }
        }

    }
}
