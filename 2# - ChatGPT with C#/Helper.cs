using System.Globalization;

namespace ChatGPTIntegration
{
    public static class Helper
    {
        public static string ToProperCase(this string text)
        {
            if (text != null)
            {
                CultureInfo _cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = _cultureInfo.TextInfo;
                // Send in the text as lower case to allow the method to
                // make all the decisions
                return textInfo.ToTitleCase(text.ToLower());
            }
            else
            {
                return text;
            }
        }
    }
}
