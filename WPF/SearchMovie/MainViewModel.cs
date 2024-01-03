using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace SearchMovie;

public class MainViewModel : ViewModelBase
{
    private string _search;
    private ObservableCollection<MovieModel> _viewModel;
    private readonly MovieSearchService _searchService;


    public string SearchText
    {
        get { return _search; }
        set
        {
            Set(ref _search, value);
        }

    }
    
    public ObservableCollection<MovieModel> SearchResults
    {
        get { return _viewModel; }
        set
        {
            Set(ref _viewModel, value);
        }
    }

    public ICommand SearchCommand { get; }
    

    public MainViewModel()
    {
        _searchService = new MovieSearchService();
        SearchCommand = new RelayCommand(Search);

    }

    private void Search()
    {
        if (string.IsNullOrEmpty(_search))
        {
            return;
        }
        var results = _searchService.SearchMovies(SearchText);
        
        SearchResults = new ObservableCollection<MovieModel>(results);

        MessageBox.Show("Search command executed!");
    }
}
