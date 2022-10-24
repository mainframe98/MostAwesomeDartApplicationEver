﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MostAwesomeDartApplicationEver.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MostAwesomeDartApplicationEver.ViewModels
{   
    [INotifyPropertyChanged]
    internal partial class DarterViewModel : ViewModel<Darter>
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteDarterCommand))]
        private Darter? _selectedItem;

        public DarterViewModel(DartDbContext context) : base(context)
        {
            Context.Darters.Load();
            Data = Context.Darters.Local.ToObservableCollection();
        }
        
        [RelayCommand]
        private async Task AddUpdateDarterAsync(Darter darter)
        {
            if (darter.Id is null)
            {
                Context.Darters.Add(darter);
            }
            else
            {
                Context.Darters.Update(darter);
            }
            
            await Context.SaveChangesAsync();
        }

        [RelayCommand(CanExecute = nameof(CanDeleteDarter))]
        private async Task DeleteDarterAsync(Darter darter)
        {
            Context.Darters.Remove(darter);
            await Context.SaveChangesAsync();
        }

        private bool CanDeleteDarter(Darter? darter)
        {
            return darter is not null;
        }
    }
}
