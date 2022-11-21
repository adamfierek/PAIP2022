using DataTemplateTest.Model;
using DataTemplateTest.Services;
using Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

        public Command Refresh { get; }
        public Command NewContact { get; }
        public Command RemoveContact { get; }
        public Command SaveContact { get; }

        private Contact selectedContact;

        public MainWindowViewModel()
        {
            service = new ContactService();
            Refresh = new Command(Init);
            NewContact = new Command(AddContact);
            RemoveContact = new Command(_RemoveContact);
            SaveContact = new Command(_SaveContactAsync);

            Task.Run(Init);
        }

        private async void _SaveContactAsync()
        {
            if (selectedContact.ContactId == 0)
            {
                await service.Add(selectedContact);
            }
            else
            {
                await service.Update(selectedContact);
            }

            Init();
        }

        private async void _RemoveContact()
        {
            await service.Delete(selectedContact.ContactId);
            Init();
        }

        private void AddContact()
        {
            ContactList.Add(new Contact { FirstName = "(new contact)" });
        }

        private async void Init()
        {
            var result = await service.GetAll();
            ContactList = new ObservableCollection<Contact>(result);
            RaisePropertyChanged(nameof(ContactList));
        }
    }
}
