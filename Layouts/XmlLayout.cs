namespace Logger.Layouts
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string Format => "<log>" + Environment.NewLine +
            "\t<date>{0}</date>" + Environment.NewLine +
            "\t<level>{1}</level" + Environment.NewLine +
            "\t<message>{2}</message>" + Environment.NewLine +
            "</log>" + Environment.NewLine;

    }
}
