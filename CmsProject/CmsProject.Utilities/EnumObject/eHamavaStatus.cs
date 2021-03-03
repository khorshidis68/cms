namespace CmsProject.Utilities.EnumObject
{
    public enum eHamavaStatus
    {
        [TitleAtribute("ورود اطلاعات")]
        Import = 1,
        [TitleAtribute("تایید جهت بررسی مرکز")]
        AcceptToAssign = 2,
        [TitleAtribute("تایید استاد مرکز")]
        AcceptTraining = 3
    }
}