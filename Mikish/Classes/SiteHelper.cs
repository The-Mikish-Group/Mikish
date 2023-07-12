namespace Mikish.Classes
{
    public static class SiteHelpers
    {

        public static string ImageHtmlString(string path)
        {
            int count = 0;
            string returnStringActive = "";
            string returnString = "";
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                if (count==0) { 
                    returnStringActive = "<div class='carousel-item w-100' active><img src='" + @file + "' alt='Image' /></div>";
                    count = 1;
                }

                returnString = returnString + "<div class='carousel-item w-100'><img src='" + @file + "' alt='Image' /></div>";
            }
            returnString = returnStringActive + returnString;

            return returnString;
        }

        public static string siteName()
        {
            return "The Mikish Group";
        }

        public static string siteURL()
        {
            return "https://Mikish.com";
        }
        public static string siteAbout()
        {
            return "_About_Mikish";
        }
        public static string siteAboutSide()
        {
            return "Aside/_Aside_About_Mikish";
        }
        public static string siteFacebookPageURL()
        {
            return "https://www.facebook.com/mikishgroup/";
        }

        public static string siteGoogleMapsURL()
        {
            return "";
        }

        public static string siteEmailSupport()
        {
            return "mikish@mikish.com";
        }
    }
}
