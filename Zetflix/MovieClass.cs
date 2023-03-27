namespace Zeflix
{
    public enum GENRE
    {
        horror,comedy,action
    }
    public class MovieData
    {
      
        public string Title
        {
            get; set;
        }

        public string Image 
        { 
            get; set;
        }

        public GENRE GENRE { get; set; }
        public MovieData(string title, string image, GENRE genre)
        {
            Title = title;
            Image = image;
            GENRE = genre;
        }
    }

}
