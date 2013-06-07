using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Globalization;
using System.Web.Mvc;

namespace Leverager.Models
{


    [Table("Status")]
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "If you see that message contact developper. Error: accessing closed data!")]
        public string Name { get; set; }

        public const int All=0;
        public const int New=1;
        public const int Approved=2;
        public const int Declined=3;

        public const string strAll = "All";
        public const string strNew = "New";
        public const string strApproved = "Approved";
        public const string strDeclined = "Declined";

        public static string Choose(int CurrentStatus, int RequiredStatus, string Default, string Selected)
        {
            if (CurrentStatus == RequiredStatus) return Selected;
            else return Default;
        }

        public static int ToInt(string status)
        {
            switch(status)
            {
                case Status.strNew:
                    return Status.New;
                case Status.strApproved:
                    return Status.Approved;
                case Status.strDeclined:
                    return Status.Declined;
                case Status.strAll:
                default:
                    return Status.All;
            }
        }

        public static string ToString(int status)
        {
            switch (status)
            {
                case Status.New:
                    return Status.strNew;
                case Status.Approved:
                    return Status.strApproved;
                case Status.Declined:
                    return Status.strDeclined;
                case Status.All:
                default:
                    return Status.strAll;
            }
        }
    }
}