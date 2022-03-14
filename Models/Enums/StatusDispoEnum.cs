using Nuke.Common.Tooling;

namespace RentToParty.Model.Enums
{
    public enum StatusDispoEnum
    {
        [EnumValue("Não Disponivel")]
        NaoDisponivel = 0,

        [EnumValue("Disponivel")]
        Disponivel = 1,

        [EnumValue("Negociar")]
        Negociar = 2,


    }
}
