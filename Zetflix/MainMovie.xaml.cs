using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
       
        public MainMovie()
        {
            InitializeComponent();
            this.DataContext = this;
            foreach (var movie in LoadMovies())
            {
                AllMovies.Add(movie);
                Movies.Add(movie);
            }

           
        }
        private IEnumerable<MovieData> LoadMovies()
        {
           var movieJSON= File.ReadAllText(@".\Resource\movies.json");
            var movies = JsonSerializer.Deserialize<IEnumerable<MovieData>>(movieJSON);

            if (movies == null || movies.Any() == false)

                return Enumerable.Empty<MovieData>();
            else
                return movies;
        }
        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ActionClicked(object sender, RoutedEventArgs e)
        {
            this.Movies.Clear();

            var founds = this.AllMovies.Where(m => m.GENRE == GENRE.action);

            foreach (var found in founds)
            {
                this.Movies.Add(found);
            }

        }

        private void HorrorClicked(object sender, RoutedEventArgs e)
        {
            this.Movies.Clear();

            var founds = this.AllMovies.Where(m => m.GENRE == GENRE.horror);

            foreach (var found in founds)
            {
                this.Movies.Add(found);
            }
        }

        private void ComedyClicked(object sender, RoutedEventArgs e)
        {
            this.Movies.Clear();

            var founds = this.AllMovies.Where(m => m.GENRE == GENRE.comedy);

            foreach (var found in founds)
            {
                this.Movies.Add(found);
            }
        }

      
    }
}



