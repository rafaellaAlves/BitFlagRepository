using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Localization
{
    public class TranslationFunctions
    {
        //private readonly GLAS2Context context;
        private readonly List<DAL.Translation> translations;
        public TranslationFunctions(GLAS2Context context)
        {
            this.translations = context.Translation.ToList();
        }
        public string GetTranslation(string key, string localization)
        {
            var translation = translations.FirstOrDefault(x => x.Key.Trim().Equals(key.Trim()));
            if (translation == null || localization == null) return key;

            switch(localization.ToUpper())
            {
                case "PT-BR":
                    return translation.PT_BR ?? key;
                case "ES-ES":
                    return translation.ES_ES ?? key;
            }

            return key;
        }
    }
}
