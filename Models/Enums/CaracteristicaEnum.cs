using Nuke.Common.Tooling;

namespace RentToParty.Model.Enums
{
    public enum CaracteristicaEnum
    {
        [EnumValue("Não Definida")]
        None = 0,

        [EnumValue("Qualitativa")]
        Interna = 1,

        [EnumValue("Quantitativa")]
        Externa = 2,


    }
}
