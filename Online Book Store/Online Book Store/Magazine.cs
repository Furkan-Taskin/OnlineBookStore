using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Store
{
    public class Magazine:Product
    {
        private string issue;
        private Types type;
        private string author;

        public string Issue { get => issue; set => issue = value; }
        public Types Type { get => type; set => type = value; }
        public string Author { get => author; set => author = value; }

        public enum Types{
            Actual,
            News, 
            Sport, 
            Computer, 
            Technology
        }

        public Magazine()
        {

        }

        public Magazine(/*int id, */string name, float price, Image image, string issue, Types type, string description)
        {
            //Product.ID++;

            //this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Image = image;
            this.Issue = issue;
            this.Type = type;
            this.Description = description;
        }
    }
}
