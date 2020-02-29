using System;

namespace Kupchyk01
{
    class Person
    {
        public enum WestSignsEnum
        {
            Aquarius, Pisces, Aries, Taurus, Gemini, Cancer, Leo, Virgo, Libra, Scorpio, Sagittarius, Capricorn
        }

        public enum ChinSignsEnum
        {
            Rat, Ox, Tiger, Rabbit, Dragon, Snake, Horse, Sheep, Monkey, Rooster, Dog, Pig
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int Age { get; set; }

        public string SighWest { get; set; }

        public string SighChina { get; set; }

        public string IsAdult
        {
            get
            {
                if (DateOfBirth == null) return "";
                return calculateAge() >= 18 ? "True" : "False";
            }
        }

        public string IsBirthday
        {
            get
            {
                if (DateOfBirth == null) return "";
                return isTodayBirthday();
            }
        }

        public Person(string firstNameP, string lastNameP, string emailP, DateTime dateOfBirthP)
        {
            FirstName = firstNameP;
            LastName = lastNameP;
            Email = emailP;
            DateOfBirth = dateOfBirthP;
        }

        public Person(string firstNameP, string lastNameP, string emailP)
        {
            FirstName = firstNameP;
            LastName = lastNameP;
            Email = emailP;
        }

        public Person(string firstNameP, string lastNameP, DateTime dateOfBirthP)
        {
            FirstName = firstNameP;
            LastName = lastNameP;
            DateOfBirth = dateOfBirthP;
        }

        public string CalcWesternHorosc()
        {
            int month = (Convert.ToDateTime(DateOfBirth)).Month;
            int day = (Convert.ToDateTime(DateOfBirth)).Day;
            int index = 0;

            switch (month)
            {
                case 02 when day >= 19:
                case 03 when day <= 20:
                    index = 1;
                    break;
                case 03 when day >= 21:
                case 04 when day <= 19:
                    index = 2;
                    break;
                case 04 when day >= 20:
                case 05 when day <= 20:
                    index = 3;
                    break;
                case 05 when day >= 21:
                case 06 when day <= 20:
                    index = 4;
                    break;
                case 06 when day >= 21:
                case 07 when day <= 22:
                    index = 5;
                    break;
                case 07 when day >= 23:
                case 08 when day <= 22:
                    index = 6;
                    break;
                case 08 when day >= 23:
                case 09 when day <= 22:
                    index = 7;
                    break;
                case 09 when day >= 23:
                case 10 when day <= 22:
                    index = 8;
                    break;
                case 10 when day >= 23:
                case 11 when day <= 21:
                    index = 9;
                    break;
                case 11 when day >= 22:
                case 12 when day <= 21:
                    index = 10;
                    break;
                case 12 when day >= 22:
                case 01 when day <= 19:
                    index = 11;
                    break;
            }
            return Enum.GetName(typeof(WestSignsEnum), index);
        }

        public string CalcChineseHorosc()
        {
            return Enum.GetName(typeof(ChinSignsEnum), ((Convert.ToDateTime(DateOfBirth)).Year - 4) % 12);
        }

        private int calculateAge()
        {
            return (DateTime.Today - Convert.ToDateTime(DateOfBirth)).Days / 365;
        }

        private string isTodayBirthday()
        {
            return ((Convert.ToDateTime(DateOfBirth)).Day == DateTime.Today.Day && (Convert.ToDateTime(DateOfBirth)).Month == DateTime.Today.Month).ToString();
        }

    }
}