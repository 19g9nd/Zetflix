using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Zeflix
{
    /// <summary>
    /// Interaction logic for MainMovie.xaml
    /// </summary>
    public partial class MainMovie : Window
    {
        public ObservableCollection<MovieData> Movies { get; set; } = new ObservableCollection<MovieData>();
        public ObservableCollection<MovieData> AllMovies { get; set; } = new ObservableCollection<MovieData>();
        private void FilterBy(IEnumerable<Func<MovieData, bool>> filters)
        {
            this.Movies.Clear();

            var founds = this.AllMovies.Where(u => filters.All(p => p.Invoke(u)));

            foreach (var found in founds)
            {
                this.Movies.Add(found);
            }
        }
        
        public MainMovie()
        {
            InitializeComponent();
            this.DataContext = this;

            foreach (var movie in AllMovies)
            {
                AllMovies.Add(movie);
                Movies.Add(movie);
            }

        }

    }
}



  