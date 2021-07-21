using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using RT.Comb;

namespace Infrastructure.Services
{
    public class PurchaseService: IPurchaseService
    {
        private IPurchaseRepository _purchaseRepository;
        public PurchaseService(IPurchaseRepository  purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<UserPurchaseMovieResponseModel> PurchaseMovie(UserPurchaseMovieRequestModel model)
        {
            var guid = new RT.Comb.SqlCombProvider(new UnixDateTimeStrategy(),
                new UtcNoRepeatTimestampProvider().GetTimestamp);
            var purchase = new Purchase()
            {
                UserId = model.UserId,
                TotalPrice = model.TotalPrice,
                PurchaseDateTime = DateTime.Now,
                MovieId = model.MovieId,
                PurchaseNumber = guid.Create()

            };
            var createPurchase = await _purchaseRepository.AddAsync(purchase);
            var userpurchase = new UserPurchaseMovieResponseModel
            {
                MovieId = createPurchase.MovieId,
                UserId = createPurchase.UserId,
                TotalPrice = createPurchase.TotalPrice,
                PurchaseDateTime = createPurchase.PurchaseDateTime,
            };
            return userpurchase;
        }
        public async Task<List<UserPurchaseMovieResponseModel>> GetAllPurchases()
        {
            var purchases = await _purchaseRepository.ListAllAsync();
            var purchaseList = new List<UserPurchaseMovieResponseModel>();
            foreach (var purchase in purchases)
            {
                purchaseList.Add(new UserPurchaseMovieResponseModel
                {
                    Id=purchase.Id,
                    MovieId=purchase.MovieId,
                    UserId=purchase.UserId,
                    TotalPrice=purchase.TotalPrice,
                    PurchaseDateTime=purchase.PurchaseDateTime
                });
            }
            return purchaseList;
        }
    }
}
