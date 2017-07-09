using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Xml;

namespace Judge
{
    public class ConfigurationService
    {
        private NameValueCollection _appSettings = ConfigurationManager.AppSettings;
        private StartupLanguageConfigSection _languageSettings = (StartupLanguageConfigSection)ConfigurationManager.GetSection("languageSettings");



        public Compiler GetCompilerByName(string compilerName)
        {
            return GetAvailableCompilers().Find(c => c.GetName() == compilerName);
        }

        private List<Compiler> GetAvailableCompilers()
        {
            List<Compiler> compilers = new List<Compiler>();
            foreach (LanguageElement language in _languageSettings.LanguageItems)
            {
                if (File.Exists(language.Path))
                    compilers.Add(new Compiler(language.Name, language.Path, language.Args, (language.Type == "compiler") ? LanguageType.сompiler : LanguageType.interpreter));
            }
            return compilers;
        }

        public static string GetRoot()
        {
            return System.Configuration.ConfigurationManager.AppSettings["Root"];
        }

    }
}