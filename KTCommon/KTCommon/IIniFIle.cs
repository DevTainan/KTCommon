using System;
using System.Collections.Generic;
using System.Text;

namespace KTCommon
{
    public interface IIniFIle
    {
        bool IniWriteValue(string Section, string Key, string Value);
        string IniReadValue(string Section, string Key);
        string IniReadValue(string Section, string Key, string defaultValue);
    }
}
