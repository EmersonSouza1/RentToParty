using RentToParty.Model.Enums;

namespace RentToParty.Model
{
    public class CaracteristicaModel
    {
        public int Id { get; set; }
        public CaracteristicaEnum Tipo { get; set; }

        public int Quantidade { get; set; }
    }
}