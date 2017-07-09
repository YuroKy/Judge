using System;
using System.Configuration;

namespace Judge
{
    public class StartupLanguageConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("languages")]
        public LanguagesCollection LanguageItems
        {
            get { return ((LanguagesCollection)(base["languages"])); }
        }
    }

    [ConfigurationCollection(typeof(LanguageElement))]
    public class LanguagesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new LanguageElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LanguageElement)(element)).Name;
        }

        public LanguageElement this[int idx]
        {
            get { return (LanguageElement)BaseGet(idx); }
        }
    }

    public class LanguageElement : ConfigurationElement
    {

        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return ((string)(base["name"])); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("path", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Path
        {
            get { return ((string)(base["path"])); }
            set { base["path"] = value; }
        }
      
        //ENUM
      [ConfigurationProperty("type", DefaultValue = "", IsKey = false, IsRequired = false)]
      public string Type
      {
          get { return ((string)(base["type"])); }
          set { base["type"] = value; }
      }

        [ConfigurationProperty("args", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Args
        {
            get { return ((string)(base["args"])); }
            set { base["args"] = value; }
        }

        public override string ToString()
        {
            return String.Format("{0}:{1}:{2}:{3}", Name, Path, Type, Args);
        }
    }

    public enum LanguageType
    {
        сompiler,
        interpreter
    }
}
