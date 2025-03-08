using System.ComponentModel;
using System.Runtime.CompilerServices;
using model.Entities;

namespace webapp.Configuration;

public class AppState : INotifyPropertyChanged
{
    private Organisation _selectedOrganization;

    public Organisation SelectedOrganization
    {
        get => _selectedOrganization;
        set
        {
            if (_selectedOrganization != value)
            {
                _selectedOrganization = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedOrganization)));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}