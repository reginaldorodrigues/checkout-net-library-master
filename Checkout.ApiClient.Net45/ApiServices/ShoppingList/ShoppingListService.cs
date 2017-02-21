using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.ApiServices.Customers.RequestModels;
using Checkout.ApiServices.Customers.ResponseModels;
using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;

namespace Checkout.ApiServices.ShoppingList
{
    public class ShoppingListService
    {
        public HttpResponse<OkResponse> CreateItem(ShoppingItemCreate requestModel)
        {
            return new ApiHttpClient().PostRequest<OkResponse>(ApiUrls.ShoppingList, AppSettings.ShoppingListApiKey, requestModel);
        }

        public HttpResponse<OkResponse> UpdateItem(ShoppingItemUpdate requestModel)
        {
            return new ApiHttpClient().PutRequest<OkResponse>(ApiUrls.ShoppingList, AppSettings.ShoppingListApiKey, requestModel);
        }

        public HttpResponse<OkResponse> DeleteItem(string item)
        {
            var deletItemUri = string.Format(ApiUrls.ShoppingItem, item);
            return new ApiHttpClient().DeleteRequest<OkResponse>(deletItemUri, AppSettings.ShoppingListApiKey);
        }

        public HttpResponse<ShoppingItem> GetItem(string item)
        {
            var getItemUri = string.Format(ApiUrls.ShoppingItem, item);
            return new ApiHttpClient().GetRequest<ShoppingItem>(getItemUri, AppSettings.ShoppingListApiKey);
        }

        public HttpResponse<ResponseModels.ShoppingList> GetShoppingList()
        {
            return new ApiHttpClient().GetRequest<ResponseModels.ShoppingList>(ApiUrls.ShoppingList, AppSettings.ShoppingListApiKey);
        }
    }
}
