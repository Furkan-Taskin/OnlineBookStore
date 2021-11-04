using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Store
{
    public class MusicCD : Product
    {
        private string singer;
        private Types type;

        public string Singer { get => singer; set => singer = value; }
        public Types Type { get => type; set => type = value; }

        public enum Types
        {
            Romance,
            HardRock,
            Country,
            Pop,
            HeavyMetal,
            Rap
        }

        public MusicCD(/*int id, */string name, float price, Image image, string singer, Types type, string description)
        {
            //Product.ID++;

            //this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Image = image;
            this.Singer = singer;
            this.Type = type;
            this.Description = description;
        }
    }
}
