using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasssHomeWork
{
    public partial class Plane
    {
        private string brandOfThePlane;
        private string typeOfThePlane;
        private DateTime dateOfManufacture;
        private double operatingEmptyWeight;
        private double maximumTakeoffWeight;
        private int fuelTankCapacity;
        private int maxSpeed;
        private static int totalNeededFuel = 0;
        private static int countOfPlane = 0;

        static Plane() { }

        public Plane()
        {
            CountOfPlane++;
        }
        public Plane(DateTime dateOfManufacture)
        {
            this.dateOfManufacture = dateOfManufacture;
        }
        public Plane(string brandOfThePlane, string typeOfThePlane)
        {
            this.brandOfThePlane = brandOfThePlane;
            this.typeOfThePlane = typeOfThePlane;
            CountOfPlane++;
        }
        public Plane(string brandOfThePlane, string typeOfThePlane, DateTime dateOfManufacture, double operatingEmptyWeight,
            double maximumTakeoffWeight, int fuelTankCapacity, int maxSpeed, int flightRange)
        {
            this.brandOfThePlane = brandOfThePlane;
            this.typeOfThePlane = typeOfThePlane;
            this.dateOfManufacture = dateOfManufacture;
            this.operatingEmptyWeight = operatingEmptyWeight;
            this.maximumTakeoffWeight = maximumTakeoffWeight;
            this.fuelTankCapacity = fuelTankCapacity;
            this.maxSpeed = maxSpeed;
            CountOfPlane++;
            totalNeededFuel += fuelTankCapacity;
        }

        #region Методы доступа
        public string BrandOfThePlane
        {
            get
            {
                return brandOfThePlane;
            }
            set
            {
                brandOfThePlane = value;
            }
        }
        public string TypeOfThePlane
        {
            get
            {
                return typeOfThePlane;
            }
            set
            {
                typeOfThePlane = value;
            }
        }
        public DateTime DateOfManufacture
        {
            get
            {
                return dateOfManufacture;
            }
            set
            {
                dateOfManufacture = value;
            }
        }
        public double OperatingEmptyWeight
        {
            get
            {
                return operatingEmptyWeight;
            }
            set
            {
                operatingEmptyWeight = value;
            }
        }
        public double MaximumTakeoffWeight
        {
            get
            {
                return maximumTakeoffWeight;
            }
            set
            {
                maximumTakeoffWeight = value;
            }
        }
        public int FuelTankCapacity
        {
            get
            {
                return fuelTankCapacity;
            }
            set
            {
                totalNeededFuel += (value - fuelTankCapacity);
                fuelTankCapacity = value;
            }
        }
        public int MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                maxSpeed = value;
            }
        }
        public static int CountOfPlane { get => countOfPlane; set => countOfPlane = value; }
        public static int TotalNeededFuel { get => totalNeededFuel; set => totalNeededFuel = value; }
        #endregion

        public void Show()
        {
            Console.WriteLine("Название самолета:\t\t" + brandOfThePlane +
                "\nТип самолета:\t\t" + typeOfThePlane +
                "\nДата производства:\t\t" + dateOfManufacture +
                "\nРабочий пустой вес:\t\t" + operatingEmptyWeight +
                "\nМаксимальная взлетная масса:\t\t" + maximumTakeoffWeight +
                "\nОбъем топливного бака:\t\t" + fuelTankCapacity +
                "\nМаксимальная скорость:\t\t" + maxSpeed);
        }
        public string PlaneAge()
        {
            DateTime difference = new DateTime((DateTime.Now - dateOfManufacture).Ticks);

            string age = string.Format("{0} лет {1} месяцев", difference.Year - 1, difference.Month - 1);
            return age;
        }
        public bool IsSupersonic()
        {
            const double MACH_NUMBER = 1.2;
            const int MACH_NUMBER_2 = 5;
            const double SPEED_OF_SOUND = 1191.6;

            if ((maxSpeed / SPEED_OF_SOUND > MACH_NUMBER) && (maxSpeed / SPEED_OF_SOUND) < MACH_NUMBER_2)
                return true;
            return false;
        }
        public void ComparisonOfSpeed(ref int FastestPlaneTopSpeed)
        {
            if (FastestPlaneTopSpeed < maxSpeed) FastestPlaneTopSpeed = maxSpeed;
        }
    }
}