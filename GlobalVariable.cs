using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaTicketing
{
    class GlobalVariable
    {
        private static string moviecode;
        public static string ulogin;
        public static string pic;
        public static string avatar;
        public static string title;
        public static string superadmin;
        public static string price;
        public static string genre;
        public static int portals;

        public string SA
        {
            get { return superadmin; }
            set { superadmin = value; }
        }

        public string Moviecode
        {
            get { return moviecode; }
            set { moviecode = value; }
        }
        private static int countofticket;
        public int CountOfTicket
        { 
            get { return countofticket; }
            set { countofticket = value;  }
        }
        public string usernameLogin
    {
        get { return ulogin; }
        set { ulogin = value; }
}
        public string getpic
        {
            get { return pic; }
            set { pic = value; }
        }
        public string avatars
        {
            get { return avatar; }
            set { avatar = value; }
    }
        public string movietitle
        {
            get { return title; }
            set { title = value; }
        }
        public string movieprice
        {
            get { return price; }
            set { price = value; }
        }
        public string moviegenre
        {
            get { return genre ; }
            set { genre = value; }
        }
        private static int editoradd;
        public int EditorAdd
        {
            get { return editoradd; }
            set { editoradd = value; }
        }

        public int Port
        {
            get { return portals; }
            set { portals = value; }
        }
    }
}
