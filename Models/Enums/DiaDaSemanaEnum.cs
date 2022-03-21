using Nuke.Common.Tooling;

namespace RentToParty.Model.Enums
{
    public enum DiaDaSemanaEnum
    {
        [EnumValue("")]
        None = 0,

        [EnumValue("Domingo")]
        Domingo = 1,

        [EnumValue("Segunda-feira")]
        Sengunda = 2,

        [EnumValue("Terca-feira")]
        Terca = 3,

        [EnumValue("Quarta-feira")]
        Quarta = 4,

        [EnumValue("Quinta-feira")]
        Quinta = 5,

        [EnumValue("Sexta-feira")]
        Sexta = 6,

        [EnumValue("Sabado")]
        Sabado = 7

    }
}
