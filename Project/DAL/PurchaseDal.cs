using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public class PurchaseDal : IPurchaseDal
    {
        private readonly OrdersContext ordersContext;
        private readonly IMapper Mapper;

        public PurchaseDal(OrdersContext ordersContext)
        {
            this.ordersContext = ordersContext;
        }
        public async Task<Purchase> Add(Purchase purchase)
        {
            try
            {
                await ordersContext.Purchase.AddAsync(purchase);
                await ordersContext.SaveChangesAsync();
                return purchase;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Purchase>> GetAllPurchases()
        {
            try
            {
                List<Purchase> purchases = await ordersContext.Purchase.ToListAsync();
                return purchases;
            }
            catch (Exception ex)
            {
                throw;
            }
        }





  public async Task<Purchase> AddPresentToPurchase(CardDto cardDto)//לא עובד
        {
            try
            {
                Purchase purchase = await ordersContext.Purchase.FirstOrDefaultAsync(p => p.Id == cardDto.PurchaseId);
                List<Card> presentToCartDto = new List<Card>();
                if (purchase.Presents != null)
                {
                    presentToCartDto = purchase.Presents.ToList();
                }


               //presentToCartDto.Append(cardDto);
                purchase.Presents = presentToCartDto;

                ordersContext.Purchase.Update(purchase);
                await ordersContext.Purchase.AddAsync(purchase);
                await ordersContext.SaveChangesAsync();
                return purchase;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Card> UpdatePresentToPurchase( CardDto cardDto)//ככל הנראה לא צריך אותך
        {
            try
            {
                // Purchase purchase = await ordersContext.Purchase.FirstOrDefaultAsync(p => p.Id == cardDto.PurchaseId);
                //     List<CardDto> presentToCartDto = purchase.Presents.ToList();

                //  IEnumerable<Card> CardDto = presentToCartDto.Where(p => (p.PurchaseId == cardDto.PurchaseId && p.PresentID == cardDto.PresentID));
                //    var card = Mapper.Map<Card>(cardDto);

                if (cardDto == null)
                {
                    return null;
                }
                else
                {
                    // CardDto.ElementAt(0).Id = cardDto.Id;

                    //    for (int i = 0; i < presentToCartDto.Capacity; i++)
                    //    {
                    //        if ((CardDto.ElementAt(i).PurchaseId == cardDto.PurchaseId && CardDto.ElementAt(i).PresentID == cardDto.PresentID))
                    //        {
                    //            CardDto.ElementAt(0).PurchaseId = cardDto.PurchaseId;
                    //            CardDto.ElementAt(0).Amount = cardDto.Amount;
                    //            CardDto.ElementAt(0).PresentID = cardDto.PresentID;
                    //        }
                    //    }
                    //    purchase.Presents = presentToCartDto;
                    //    await ordersContext.SaveChangesAsync();
                    return null;
                }
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
        }





        //public async Task<List<PresentToCartDto>> GetAllPresentOfPurchase(int PurchaseId)//
        //{
        //    try
        //    {
        //        Purchase purchase = await ordersContext.Purchase.FirstOrDefaultAsync(p => p.Id == PurchaseId);
        //        List<PresentToCartDto> presentToCartDto = purchase.Presents.ToList();


        //        return presentToCartDto;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error getting Present");
        //    }
        //}

        public async Task<bool> DeletePurchase(int purchaseId)
        {
            try
            {
                List<Purchase> purchases = await ordersContext.Purchase.ToListAsync();
                Purchase deletePurchase = purchases.FirstOrDefault(p => p.Id == purchaseId);
                if (deletePurchase == null)
                {

                    return false;
                }
                else
                {
                    ordersContext.Purchase.Remove(deletePurchase);
                    await ordersContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Purchase> UpdatePurchase(Purchase newPurchase, int purchaseId)
        {
            try
            {
                Purchase purchaseToUpdate = await ordersContext.Purchase.FirstOrDefaultAsync(p => p.Id == purchaseId);
                if (purchaseToUpdate == null)
                {
                    return null;
                }
                else
                {
                   // purchaseToUpdate.Id = newPurchase.Id;
                    purchaseToUpdate.IsDraft = newPurchase.IsDraft;
                   // purchaseToUpdate.Presents = newPurchase.Presents;
                    purchaseToUpdate.CustomerId = newPurchase.CustomerId;
                    ordersContext.Purchase.Update(purchaseToUpdate);
                    await ordersContext.SaveChangesAsync();
                    return purchaseToUpdate;
                }
    
    }
        
            catch (Exception ex)
            {
                throw new Exception("UpdatePresent failed");
            }
        }
        public async Task<Purchase> FindPurchaseById(int Id)
        {
            try
            {
                List<Purchase> purchases = await ordersContext.Purchase.ToListAsync();
                Purchase purchase = purchases.FirstOrDefault(p => p.Id == Id);
                if (purchase == null)
                {
                    return null;
                }
                return purchase;
            }
            catch (Exception ex)
            {
                throw new Exception("FindPurchaseById failed");
            }
        }


        public async Task<List<Purchase>> FindPurchaseByCustomerId(int customerId)
        {
            try
            {
                List<Purchase> allPurchases = await ordersContext.Purchase.ToListAsync();

                List<Purchase> currPurchases = new List<Purchase>();
                currPurchases = allPurchases.Where(p => p.CustomerId == customerId).ToList();
                if (currPurchases == null)
                {
                    return null;
                }
                return currPurchases;
            }
            catch (Exception ex)
            {
                throw new Exception("FindPurchaseById failed");
            }
        }



        public async Task<Customer> GetCustomerDetails(int purchaseId)
        {
            try
            {
                List<Purchase> purchases = await ordersContext.Purchase.ToListAsync();
                List<Customer> customeres = await ordersContext.Customer.ToListAsync();

                Purchase purchase = purchases.FirstOrDefault(p => p.Id == purchaseId);
                Customer customer = customeres.FirstOrDefault(p => p.Id == purchase.CustomerId);

                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("GetCustomerDetails failed");
            }
        }
        public async Task<List<Card>> GetPresentPurchase(int PurchaseId)//נותן לי את כל המתנות בקשר לפורצאס הזה// GetAllPresentOfPurchase
        {
            try
            {
                Purchase purchase = await ordersContext.Purchase.FirstOrDefaultAsync(p => p.Id == PurchaseId);
                List<Card> presentToCartDto = purchase.Presents.ToList();


                return presentToCartDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting Present");
            }
        }
        public async Task<List<Customer>> GetAllCustomersDetails()
        {
            try
            {
                /*   List<Customer> customers = await ordersContext.Customer.Where(p => p.Present.IsNullOrEmpty()).ToListAsync();
                   return customers;*/
              List<Customer>c= new List<Customer>();
                return c;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllCustomersDetails failed");
            }
        }








    }
}

