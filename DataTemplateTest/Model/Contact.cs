namespace DataTemplateTest.Model
{
    public class Contact : ModelBase
    {
        private string firstName;
        private string lastName;
        private string phoneNr;
        private string image;

        public string FirstName
        {
            get => firstName; 
            set
            {
                firstName = value;
                RaisePropertyChanged();
            }
        }
        public string LastName
        {
            get => lastName; 
            set
            {
                lastName = value;
                RaisePropertyChanged();
            }
        }
        public string PhoneNr
        {
            get => phoneNr; 
            set
            {
                phoneNr = value;
                RaisePropertyChanged();
            }
        }
        public string Image
        {
            get => image; 
            set
            {
                image = value;
                RaisePropertyChanged();
            }
        }
    }
}
