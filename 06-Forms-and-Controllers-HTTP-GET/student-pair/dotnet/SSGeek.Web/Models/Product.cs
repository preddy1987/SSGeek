using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class Product
    {
        /// <summary>
        /// Product's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product's cost.
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Product's ImageName
        /// </summary>
        public string ImageName { get; set; }
        public string Description { get; set; }
    }
}