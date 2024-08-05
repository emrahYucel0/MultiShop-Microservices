using MultiShop.Discount.Dtos.CouponDtos;

namespace MultiShop.Discount.Services.CouponServices;

public interface IDiscountCouponService
{
    Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync();
    Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);
    Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);
    Task DeleteDiscountCouponAsync(int id);
    Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
}
