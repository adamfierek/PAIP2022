using DataTemplateTest.Model;
using DataTemplateTest.Services;
using DataTemplateTest.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace DataTemplateTest
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Contact> ContactList { get; set; } = new();
        public Contact SelectedContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                RaisePropertyChanged();
            }
        }
        private ContactService service;
        private Contact selectedContact;

        public MainWindowViewModel()
        {
            service = new ContactService();
            var contacts = service.GetAll();
            foreach (var c in contacts)
            {
                ContactList.Add(c);
            }
        }
    }
}
