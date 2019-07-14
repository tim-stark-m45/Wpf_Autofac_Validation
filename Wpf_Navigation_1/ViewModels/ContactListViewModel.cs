using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Navigation_1.Messages;
using Wpf_Navigation_1.Models;
using Wpf_Navigation_1.Services;

namespace Wpf_Navigation_1.ViewModels
{
    class ContactListViewModel : ViewModelBase
    {
        private ObservableCollection<Contact1> contact1s;
        public ObservableCollection<Contact1> Contact1s { get => contact1s; set => Set(ref contact1s, value); }

        private readonly INavigationService navigationService;
        private readonly ApplDbContext db;
        private readonly IMessageService messageService;

        public ContactListViewModel(
            INavigationService navigationService, 
            ApplDbContext db,
            IMessageService messageService)
        {
            this.navigationService = navigationService;
            this.db = db;
            this.messageService = messageService;
            Contact1s = new ObservableCollection<Contact1>(db.Contact1s);

            Messenger.Default.Register<ContactListChangedMessage>(this, msg => 
            {
                //Contact1s = new ObservableCollection<Contact1>(db.Contact1s);
                Contact1s.Add(msg.Item);
            });
        }

        private RelayCommand addContactCommmad;
        public RelayCommand AddContactCommmad
        {
            get => addContactCommmad ?? (addContactCommmad = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<AddEditContactViewModel>();
              }
              ));
        }

        private RelayCommand<Contact1> openInfoCommand;
        public RelayCommand<Contact1> OpenInfoCommand
        {
            get => openInfoCommand ?? (openInfoCommand = new RelayCommand<Contact1>(
              param =>
              {
                  var info = $@"Name: {param.Name}
Phone: {param.Phone} 
Email: {param.Email ?? "Empty"} 
Category: {param.Category1.Name}";
                  messageService.ShowInfo(info);
              }
              ));
        }

        private RelayCommand<Contact1> deleteCommand;
        public RelayCommand<Contact1> DeleteCommand
        {
            get => deleteCommand ?? (deleteCommand = new RelayCommand<Contact1>(
              param =>
              {
                  if (messageService.ShowYesNo("Are you sure?"))
                  {
                      db.Contact1s.Remove(param);
                      db.SaveChanges();
                      Contact1s.Remove(param);
                  }
              }
              ));
        }
    }
}
