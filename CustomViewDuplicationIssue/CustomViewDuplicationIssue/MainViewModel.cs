using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomViewDuplicationIssue
{
    public class MainViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Person _person;

        public Person Fella
        {
            get { return _person; }
            set {
                if (!value.Equals(_person))
                {
                    _person = value;
                    OnPropertyChanged(nameof(Fella));
                }
                 }
        }

    }
}
