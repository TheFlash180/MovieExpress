using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Csla;
using Singular.Web;

namespace MEWeb.Movies
{
    public partial class Movie : MEPageBase<MovieVM>
    {
    }
    public class MovieVM : MEStatelessViewModel<MovieVM>
    {
        public MELib.Movies.Movie CurrentMovie { get; set; }
        public MELib.Movies.MovieList MovieList { get; set; }

        public static PropertyInfo<String> MovieTitleProperty = RegisterSProperty<String>(c => c.MovieTitle, "");

        [Display(Name = "Movie Title", Description = "")]
        public String MovieTitle
        {
            get { return GetProperty(MovieTitleProperty); }
            set { SetProperty(MovieTitleProperty, value); }
        }

        public static PropertyInfo<String> MovieDescProperty = RegisterSProperty<String>(c => c.MovieDesc, "");

        [Display(Name = "Movie Description", Description = "")]
        public String MovieDesc
        {
            get { return GetProperty(MovieDescProperty); }
            set { SetProperty(MovieDescProperty, value); }
        }

        public MovieVM()
        {

        }
        protected override void Setup()
        {
            base.Setup();
            CurrentMovie = MELib.Movies.MovieList.GetMovieList().FirstOrDefault();
            MovieList = MELib.Movies.MovieList.GetMovieList();
            //var movieId = MovieList.Where(c => c.MovieID == ).Select(c=> c.MovieID);
            MovieTitle = CurrentMovie.MovieTitle;
            MovieDesc = CurrentMovie.MovieDescription;
        }
    }
}

