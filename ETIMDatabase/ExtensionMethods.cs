using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase
{
    internal static class ExtensionMethods
    {
        public static Language GetLanguage(this string language)
        {
            switch(language)
            {
                case "nl-NL": return Language.Dutch;
                case "fr-FR": return Language.French;
                case "en-GB": return Language.English;
                case "de-DE": return Language.German;
                default: return Language.Dutch;
            }
        }
    }
}
