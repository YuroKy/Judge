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

        /*OLD
        public Compiler GetCompilerByName(string compilerName)
        {
            foreach (LanguageElement language in _languageSettings.LanguageItems)
                if (language.Name == compilerName)
                    return new Compiler(language.Name, language.Path, language.Args, language.Type);

            throw new ConfigurationErrorsException($"There is no difinition for {compilerName}");
        }
        */

        public Compiler GetCompilerByName(string compilerName)
        {
            foreach (Compiler compiler in GetAvailableCompilers())
                if (compiler.GetName() == compilerName)
                    return compiler;

            return null;
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
       
    }
}