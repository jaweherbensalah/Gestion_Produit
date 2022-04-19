using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
     public class Provider
    {
        public DateTime DateCreated { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Key]
        public int Id { get; set; }
        public bool IsApproved { get; set; }
        //******************************************************************************
        [DataType(DataType.Password)]
        [MaxLength(8)]
        [Required]
        private string password;
        public string Password
        {
            get { return password; }
            set {if (value.Length >= 5 && value.Length <= 20) password = value;
                else
                    Console.WriteLine("password incorrecte!");
            }
        }
        //********************************************************************************
        [Required]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Pass Not Matched")]
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        //many prods to many providers
        public virtual ICollection<Product> Products { get; set; }
        //public override void GetDetails()
        //{ Console.WriteLine("DateCreated: " + DateCreated + "Email :" + Email+ "UserName: "+ UserName); }
     //passage parréférence:
        public static void SetIsApproved(Provider P)
        { P.IsApproved = string.Compare(P.Password, P.ConfirmPassword) == 0; }
        //Passage par valeur
        public static void SetIsApproved(string password, string confirmPassword, bool isApproved)
        {isApproved = string.Compare(password, confirmPassword) == 0; }

        //*****************************************************************************
        //**********Polymorphisme de surcharge:
        public bool login(string username, string password)
        {
            return string.Compare(username
              , this.UserName) == 0 && string.Compare(password
              , this.Password) == 0;

        }
        public bool login(string username, string password,string email)
        {
            return string.Compare(username
              , this.UserName) == 0 && string.Compare(password
              , this.Password) == 0  && string.Compare(email, this.Email)==0;

        }
    }
}
