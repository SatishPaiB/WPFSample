using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double ControlWidth { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new CarManufacturerViewModel();

        }
    }

    public class CarManufacturerViewModel  
    {

        private CarModelModel _selectedCarModel;
        private CarManufacturerModel _carManufacturer;

        private ObservableCollection<CarModelModel> _carModels;
        private ObservableCollection<CarManufacturerModel> _carManufacturers;

        [DesignOnly(true)]
        public CarManufacturerViewModel()
        {
            CarManufacturers = new ObservableCollection<CarManufacturerModel>
        {
            CarManufacturerModel.Create("Audi", CarModelModel.Create(new string[]{"A1","A2","A3","A4","A5"})),
            CarManufacturerModel.Create("Mercedes", CarModelModel.Create(new string[]{"A-Class", "B-Class", "C-Class", "E-Class", "S-Class"})),
            CarManufacturerModel.Create("BMW", CarModelModel.Create(new string[]{"1-Serie", "2-Serie", "3-Serie", "4-Serie", "5-Serie"})),
            CarManufacturerModel.Create("Volkswagen", CarModelModel.Create(new string[]{ "Golf", "Passat", "Arteon", "T-Cross","Up!"})),
            CarManufacturerModel.Create("Volvo", CarModelModel.Create(new string[]{"V60","V70","XC60","XC90","S90"}))
        };
            //SelectedCarManufacturer = CarManufacturers.First();
        }

        public ObservableCollection<CarManufacturerModel> CarManufacturers
        {
            get => _carManufacturers;
            set
            {
                 _carManufacturers = value;
            }
        }

        public CarManufacturerModel SelectedCarManufacturer
        {
            get => _carManufacturer;
            set
            {
                _carManufacturer =value;
            }
        }

        public ObservableCollection<CarModelModel> CarModels
        {
            get => _carModels;
            set => _carModels = value;
        }

        public CarModelModel SelectedCarModel
        {
            get => _selectedCarModel;
            set => _selectedCarModel = value;
        }
    }

        public class CarManufacturerModel
    {
        public string CarManufacturer { get; set; }

        public CarModelModel CarModel { get; set; }

        //public ObservableCollection<CarModelModel> CarModels { get; set; }

        private CarManufacturerModel(string carManufacturer, /*ObservableCollection<CarModelModel>carModels*/CarModelModel carModel)
        {
            CarManufacturer = carManufacturer;
            //CarModels = carModels;
            CarModel = carModel;

        }

        public static CarManufacturerModel Create(string carManufacturer, CarModelModel carModel)
            => new CarManufacturerModel(carManufacturer, carModel);

    }

     

    public class CarModelModel
    {

        public string[] CarModelList { get; set; }

        public CarModelModel(string[] carModelList)
        {
            CarModelList = carModelList;
        }
        public static CarModelModel Create(string[] carModelList)
            => new CarModelModel(carModelList);
    }
}
