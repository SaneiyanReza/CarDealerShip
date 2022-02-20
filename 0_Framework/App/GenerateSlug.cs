using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _0_Framework.App
{
    public static class GenerateSlug
    {
        public static string Slugify(this string phrase)
        {
            var slug = phrase.RemoveDiacritics().ToLower();
            slug = Regex.Replace(slug, @"[^\u0600-\u06ff\uFB8A\u067E\u0686\u06AF\u200C\u200Fa-z0-9\s-]", "");
            slug = Regex.Replace(slug, @"\s+", " ").Trim();
            slug= slug.Substring(0, slug.Length <=100 ? slug.Length:45).Trim();
            slug = Regex.Replace(slug, @"\s", "-");
            slug = Regex.Replace(slug, @"", "-");
            return slug.ToLower();
        }
        public static string RemoveDiacritics(this string text)
        {
            if(string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var normalizedString = text.Normalize(NormalizationForm.FormKC);
            var stringBuilder = new StringBuilder();

            foreach(var word in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(word);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(word);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
