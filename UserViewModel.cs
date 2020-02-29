using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Kupchyk01
{
    public class UserViewModel : INotifyPropertyChanged
    {

        private Person _user= new Person("", "", "");
        private RelayCommand<object> _calcAge;

        public string FirstName
        {
            get { return _user.FirstName; }
            set { _user.FirstName = value; }
        }

        public string LastName {
            get { return _user.LastName; }
            set { _user.LastName = value; }
        }

        public string Email
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }

         public DateTime? DateOfBirth
        {
            get { return _user.DateOfBirth; }
            set { _user.DateOfBirth = value; }
        }

        public int Age
        {
            get { return _user.Age; }
            set {
                _user.Age = value;
            }
        }

        public string SighWest
        {
            get { return _user.SighWest; }
            set {
                _user.SighWest = value;
            }
        }

        public string SighChina
        {
            get { return _user.SighChina; }
            set {
                _user.SighChina = value;
            }
        }

        public string IsAdult
        {
            get { return _user.IsAdult; }
            
        }

        public string IsBirthday
        {
            get { return _user.IsBirthday; }
        }

        private async void Calculate()
        {
            await Task.Run(() => Thread.Sleep(1000));

            if ((Convert.ToDateTime(_user.DateOfBirth)).Year < DateTime.Today.Year - 135  || _user.DateOfBirth > DateTime.Today)
            {
                MessageBox.Show("Incorrect date!\nTry one more time.");
               
            }
            else
            {
                if (_user.IsBirthday == "True")
                {
                    MessageBox.Show("Happy birthday!\nHere’s to a bright,\nhealthy and exciting future!");
                }
                _user.SighWest = _user.CalcWesternHorosc();
                _user.SighChina = _user.CalcChineseHorosc();

                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(DateOfBirth));
                OnPropertyChanged(nameof(IsAdult));
                OnPropertyChanged(nameof(SighWest));
                OnPropertyChanged(nameof(SighChina));
                OnPropertyChanged(nameof(IsBirthday));
            }

        }

        public RelayCommand<object> CalcAge
        {
            get
            {
                return _calcAge ?? (_calcAge = new RelayCommand<object>(o =>
                        Calculate(), o => CanExecuteCommand()));
            }
        }

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_user.DateOfBirth.ToString());
        }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null){
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
