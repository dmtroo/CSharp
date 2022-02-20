using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ProgrammingInCSharp.Lab01.Models;
using ProgrammingInCSharp.Lab01.Tools;

namespace ProgrammingInCSharp.Lab01.ViewModels
{
    class DatePickerViewModel : INotifyPropertyChanged
    {
        #region Fields
        private User _user = new User();
        private string[] animals = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        private string[] elements = { "Wood", "Fire", "Earth", "Metal", "Water" };
        #region Commands
        private RelayCommand<object> _calculateCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #endregion


        #region Properties

        public DateTime? Birthdate
        {
            get { return _user.Birthdate; }
            set { _user.Birthdate = value; }
        }

        public string Age
        {
            get
            {
                return _user.Age;
            }
            set
            {
                _user.Age = value;
                OnPropertyChanged();
            }
        }
        public string WestZodiac
        {
            get { return _user.WestZodiac; }
            set
            {
                _user.WestZodiac = value;
                OnPropertyChanged();
            }
        }

        public string ChineseZodiac
        {
            get { return _user.ChineseZodiac; }
            set
            {
                _user.ChineseZodiac = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> CalculateCommand
        {
            get
            {
                return _calculateCommand ??= new RelayCommand<object>(_ => Calculate());
            }

        }

        private void Calculate()
        {
            if (_user.Birthdate == null)
            {
                MessageBox.Show($"Date field is empty!");
                makeEmpty();
                return;
            }

            int age = CountAge(_user.Birthdate);
            if (age < 0 || age > 135)
            {
                makeEmpty();
                MessageBox.Show($"Wrong birthdate!");
                return;
            }

            Age = age == 0 ? "less than 1 year" : age.ToString();

            if (IsBirthday(_user.Birthdate))
            {
                MessageBox.Show($"Happy birthday!!!");
            }

            WestZodiac = WesternZodiacSign(_user.Birthdate.Value.Day, _user.Birthdate.Value.Month);
            ChineseZodiac = ChineseZodiacSign(_user.Birthdate.Value.Year);
        }

        private void makeEmpty()
        {
            Age = "";
            WestZodiac = "";
            ChineseZodiac = "";
        }

        #endregion

        private int CountAge(DateTime? birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Value.Year;

            if (DateTime.Today.Month < birthDate.Value.Month || (DateTime.Today.Month == birthDate.Value.Month && DateTime.Today.Day < birthDate.Value.Day))
                age--;
            return age;
        }
        private bool IsBirthday(DateTime? birthDate)
        {
            return (DateTime.Today.Month == birthDate.Value.Month) && (DateTime.Today.Day == birthDate.Value.Day);
        }

        private string WesternZodiacSign(int day, int month)
        {
            switch (month)
            {
                case 12:
                    return day < 22 ? "Sagittarius" : "Capricorn";
                case 1:
                    return day < 20 ? "Capricorn" : "Aquarius";
                case 2:
                    return day < 19 ? "Aquarius" : "Pisces";
                case 3:
                    return day < 21 ? "Pisces" : "Aries";
                case 4:
                    return day < 20 ? "Aries" : "Taurus";
                case 5:
                    return day < 21 ? "Taurus" : "Gemini";
                case 6:
                    return day < 21 ? "Gemini" : "Cancer";
                case 7:
                    return day < 23 ? "Cancer" : "Leo";
                case 8:
                    return day < 23 ? "Leo" : "Virgo";
                case 9:
                    return day < 23 ? "Virgo" : "Libra";
                case 10:
                    return day < 23 ? "Libra" : "Scorpio";
                default:
                    return day < 22 ? "Scorpio" : "Sagittarius";
            }
        }

        private string ChineseZodiacSign(int year)
        {
            int ei = (int)Math.Floor((year - 4.0) % 10 / 2);
            int ai = (year - 4) % 12;
            return $"{elements[ei]} {animals[ai]}";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
