using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Navigation_1.Extensions;
using Wpf_Navigation_1.Messages;
using Wpf_Navigation_1.Models;
using Wpf_Navigation_1.Services;

namespace Wpf_Navigation_1.ViewModels
{
    class AddEditContactViewModel : ViewModelBase, IDataErrorInfo
    {
        //private string text;
        //[Required(ErrorMessage = "Gde tekst?")]
        //public string Test { get => text; set => Set(ref text, value); }

        private Contact1 contact1 = new Contact1();
        public Contact1 Contact1 { get => contact1; set => Set(ref contact1, value); }

        private ObservableCollection<Category1> category1s;
        public ObservableCollection<Category1> Category1s { get => category1s; set => Set(ref category1s, value); }

        private Category1 selectedCategory;
        public Category1 SelectedCategory { get => selectedCategory; set => Set(ref selectedCategory, value); }

        private readonly INavigationService navigationService;
        private readonly ApplDbContext db;
        private readonly IMessageService messageService;

        public AddEditContactViewModel(
            INavigationService navigationService,
            ApplDbContext db,
            IMessageService messageService)
        {
            this.navigationService = navigationService;
            this.db = db;
            this.messageService = messageService;

            Category1s = new ObservableCollection<Category1>(db.Category1s);
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get => addCommand ?? (addCommand = new RelayCommand(
              () =>
              {
                  if (string.IsNullOrWhiteSpace(Contact1.Name) || string.IsNullOrWhiteSpace(Contact1.Phone) || string.IsNullOrWhiteSpace(Contact1.Email))
                  {
                      messageService.ShowError("Text can't be empty!");
                  }
                  else
                  {
                      Contact1.Category1 = SelectedCategory;
                      db.Contact1s.Add(Contact1);
                      db.SaveChanges();
                      Messenger.Default.Send(new ContactListChangedMessage { Item = Contact1 });
                      navigationService.Navigate<ContactListViewModel>();
                      //Contact1.Name = "";
                      //Contact1.Phone = "";
                      //Contact1.Email = "";
                  }
              }
              ));
        }

        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand
        {
            get => cancelCommand ?? (cancelCommand = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<ContactListViewModel>();
              }
              ));
        }

        public string Error => throw new NotImplementedException();
        public string this[string columnName] => this.Validate(columnName);
    }
}
