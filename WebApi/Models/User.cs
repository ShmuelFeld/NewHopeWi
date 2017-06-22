using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class User
    {
        [Key]
        public string UserName
        {
            get;
            set;
        }
        [Required]
        public string Password
        {
            get;
            set;
        }
        public string EMail
        {
            get;
            set;
        }
        public int NumberOfWins
        {
            get;
            set;
        }
        public int NumberOfLoses
        {
            get;
            set;
        }
        public string Date
        {
            get;
            set;
        }

    }
}