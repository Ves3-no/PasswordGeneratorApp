using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    public partial string Password { get; set; }

    [RelayCommand]
    public void ChangePassword(string newPassword)
    {
        Debug.WriteLine("Changing password to: " + newPassword);
        Password = newPassword;
        Debug.WriteLine("Password changed to: " + Password);
    }
}
