using TW.Models;

namespace TW.DataLayer
{
    public interface ICompanySettingsProvider
    {
        CompanySetting GetCompanySettings(long Id);
        bool UpdateSettings(CompanySetting setting);

    }
}
