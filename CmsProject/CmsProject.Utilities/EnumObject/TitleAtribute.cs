using System;

namespace CmsProject.Utilities.EnumObject
{
    [System.AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class TitleAtribute : Attribute
    {

        public TitleAtribute(string title)
        {
            this.Title = title;
        }

        public string Title
        {
            get; private set;
        }

        public string Caption { get; set; }
        public int OrderNo { get; set; }
        public bool Hidden { get; set; }

    }
}