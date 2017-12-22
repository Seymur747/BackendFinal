using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using temp0.ViewModels;
using temp0.Models;

namespace temp0.ViewModels
{
    public class ViewsModels
    {
        public IEnumerable<Mesages> Mesagess { get; set; }
        public IEnumerable<News_category> News_Categorys { get; set; }
        public IEnumerable<News_images> News_İmagess { get; set; }
        public IEnumerable<News_subcategory> News_Subcategorys { get; set; }
        public IEnumerable<News_videos> News_Videoss { get; set; }
        public IEnumerable<News> Newss { get; set; }
        public IEnumerable<Subscriber> Subscribers { get; set; }
        public IEnumerable<User_category> User_Categorys { get; set; }
        public IEnumerable<User_comment> User_Commentss { get; set; }
        public IEnumerable<Users> Usersss { get; set; }






    }

}