using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Kupchyk01.Exceptions;

namespace Kupchyk01
{
    public class UserViewModel : INotifyPropertyChanged
    {

        private Person _user= new Person("", "", "");
        private RelayCommand<object> _calcAge;

        public string FirstName
        {
            get { return _user.FirstName; }
            set
            {
                _user.FirstName = value;
            }
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

        public bool ValidInputData
        {
            get { return _user.validInputData; }
            set
            {
                _user.validInputData = value;
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

            try {
                _user.ValidatePerson();
            }
            catch (PastBirthdayException ex) {
                MessageBox.Show(ex.Message);
            }
            catch (FutureBirthdayException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IncorrectEmailException ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (ValidInputData)
            {
                if (IsBirthday == "True")
                {
                    MessageBox.Show("Happy birthday!\nHere’s to a bright,\nhealthy and exciting future!");
                }
                SighWest = _user.CalcWesternHorosc();
                SighChina = _user.CalcChineseHorosc();

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

        public RelayCommand<object> CalcAgeCommand
        {
            get
            {
                return _calcAge ?? (_calcAge = new RelayCommand<object>(o =>
                        Calculate(), o => CanExecuteCommand()));
            }
        }

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_user.DateOfBirth.ToString()) && !string.IsNullOrWhiteSpace(_user.FirstName) && !string.IsNullOrWhiteSpace(_user.LastName) && !string.IsNullOrWhiteSpace(_user.Email);
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
