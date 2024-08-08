namespace MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;

public class CreateCargoDetailDto
{
    public int CargoCompanyId { get; set; }
    public string SenderCustomer { get; set; }
    public string ReceiverCustomer { get; set; }
    public int Barcode { get; set; }
}
