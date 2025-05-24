using Budget.Infrastructure.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.App.ViewModels.Home;

public partial class HomePageViewModel : ObservableObject
{

    [ObservableProperty]
    private DateTime? _selectedDate;

    private readonly AppDbContext _context;

    public HomePageViewModel(AppDbContext context)
    {
        _context = context;
    }
}
