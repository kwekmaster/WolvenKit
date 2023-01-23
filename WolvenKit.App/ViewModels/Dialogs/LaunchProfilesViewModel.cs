using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using WolvenKit.App.Models;
using WolvenKit.Core.Interfaces;
using WolvenKit.Functionality.Services;
using WolvenKit.ViewModels.Dialogs;

namespace WolvenKit.App.ViewModels.Dialogs
{
    public class LaunchProfilesViewModel : DialogViewModel
    {
        private readonly ISettingsManager _settingsManager;
        private readonly ILoggerService _loggerService;

        public LaunchProfilesViewModel(ISettingsManager settingsManager, ILoggerService loggerService)
        {
            _settingsManager = settingsManager;
            _loggerService = loggerService;

            OkCommand = ReactiveCommand.Create(() => { });
            CancelCommand = ReactiveCommand.Create(() => { });

            Title = "Rename";

            // populate profiles
            LaunchProfiles = new();
            if (_settingsManager.LaunchProfiles is not null)
            {
                foreach ((var key, var value) in _settingsManager.LaunchProfiles)
                {
                    LaunchProfiles.Add(new LaunchProfileViewModel(key, value));
                }
            }

            NewItemCommand = ReactiveCommand.Create(NewItem);
            DuplicateItemCommand = ReactiveCommand.Create(DuplicateItem);
            DeleteItemCommand = ReactiveCommand.Create(DeleteItem);
            //RenameItemCommand = ReactiveCommand.Create(RenameItem);


        }

        private void LogExtended(Exception ex) => _loggerService.Error($"Message: {ex.Message}\nSource: {ex.Source}\nStackTrace: {ex.StackTrace}");


        private void NewItem() => LaunchProfiles.Add(new LaunchProfileViewModel("New LaunchProfile", new()));

        private void DuplicateItem()
        {
            if (SelectedLaunchProfile != null)
            {
                LaunchProfiles.Add(new LaunchProfileViewModel($"{SelectedLaunchProfile.Name} Copy", SelectedLaunchProfile.Profile.Copy()));
            }
        }

        private void DeleteItem()
        {
            if (SelectedLaunchProfile != null)
            {
                LaunchProfiles.Remove(SelectedLaunchProfile);
            }
        }

        //private void RenameItem()
        //{
        //    _lastName = SelectedLaunchProfile.Name;
        //    SelectedLaunchProfile.SetEditable(true);
        //}

        //public void SetEditableFalse(LaunchProfileViewModel viewModel)
        //{
        //    if (!viewModel.IsEditable)
        //    {
        //        return;
        //    }

        //    if (LaunchProfiles.Where(x => x.Name == viewModel.Name).Count() > 1)
        //    {
        //        // duplicate Name
        //        SelectedLaunchProfile.Name = _lastName;
        //    }
        //    SelectedLaunchProfile.SetEditable(false);
        //}

        [Reactive] public ObservableCollection<LaunchProfileViewModel> LaunchProfiles { get; set; } = new();
        [Reactive] public LaunchProfileViewModel? SelectedLaunchProfile { get; set; }


        public string Title { get; set; }

        public override ReactiveCommand<Unit, Unit> CancelCommand { get; }
        public override ReactiveCommand<Unit, Unit> OkCommand { get; }


        public ReactiveCommand<Unit, Unit> NewItemCommand { get; }
        public ReactiveCommand<Unit, Unit> DuplicateItemCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteItemCommand { get; }


    }
}
