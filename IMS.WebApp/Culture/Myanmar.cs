using System.Globalization;

namespace IMS.WebApp.Culture
{
    public class Myanmar
    {
        public NumberFormatInfo NumberFormatInfo { get; set; }
        public Myanmar()
        {
            NumberFormatInfo = new CultureInfo("my-MM").NumberFormat;
           
        }
    }
}
