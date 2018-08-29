using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum AccountTypeEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("checking")]
         Checking,

        [Description("savings")]
         Savings,

    }
}