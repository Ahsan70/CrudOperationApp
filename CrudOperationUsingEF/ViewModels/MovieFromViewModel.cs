using CrudOperationUsingEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudOperationUsingEF.ViewModels
{
    public class MovieFromViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

    }
}