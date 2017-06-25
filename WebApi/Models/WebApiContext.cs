using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class WebApiContext : DbContext
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiContext"/> class.
        /// </summary>
        public WebApiContext() : base("name=WebApiContext")
        {
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public System.Data.Entity.DbSet<WebApi.Models.User> Users { get; set; }
    }
}
