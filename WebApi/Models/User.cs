using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [Key]
        public string UserName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        public string Password
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the e mail.
        /// </summary>
        /// <value>
        /// The e mail.
        /// </value>
        public string EMail
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the number of wins.
        /// </summary>
        /// <value>
        /// The number of wins.
        /// </value>
        public int NumberOfWins
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the number of loses.
        /// </summary>
        /// <value>
        /// The number of loses.
        /// </value>
        public int NumberOfLoses
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public string Date
        {
            get;
            set;
        }

    }
}