using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore1.Models
{
    public class Item
    {
        public Book book
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }
    }
}