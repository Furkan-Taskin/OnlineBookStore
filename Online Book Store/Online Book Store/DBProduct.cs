using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Store
{
    public static class DBProduct
    {
        public static List<Book> bookList;
        public static List<Magazine> magazineList;
        public static List<MusicCD> musicCDList;

        static DBProduct()
        {
            bookList = new List<Book>();
            magazineList = new List<Magazine>();
            musicCDList = new List<MusicCD>();
        }

        public static void UpdateBooksFromDatabase()
        {
            DBOperation dBOperation = new DBOperation();
            bookList = dBOperation.GetBooksFromDatabase();
        }
        public static void UpdateMagazinesFromDatabase()
        {
            DBOperation dBOperation = new DBOperation();
            magazineList = dBOperation.GetMagazinesFromDatabase();
        }
        public static void UpdateMusicCDsFromDatabase()
        {
            DBOperation dBOperation = new DBOperation();
            musicCDList = dBOperation.GetMusicCDsFromDatabase();
        }
    }
}
