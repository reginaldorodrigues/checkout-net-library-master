using System;
using System.Net;
using Checkout.ApiServices.Customers.RequestModels;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture(Category = "ShoppingListApi")]
    public class ShoppingListApiTests : BaseServiceTests
    {
        [Test]
        public void CreateItem()
        {
            var response = CheckoutClient.ShoppingListService.CreateItem(TestHelper.GetShoppingItemCreateRandomModel());

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Message.Should().BeEquivalentTo("Ok");
        }

        [Test]
        public void DeleteItem()
        {
            var item = "Coca-cola";

            CheckoutClient.ShoppingListService.CreateItem(TestHelper.GetShoppingItemCreateCocaColaModel());

            var response = CheckoutClient.CustomerService.DeleteCustomer(item);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Message.Should().BeEquivalentTo("Ok");
        }

        [Test]
        public void GetItem()
        {
            var model = TestHelper.GetShoppingItemCreateRandomModel();

            CheckoutClient.ShoppingListService.CreateItem(model);

            var response = CheckoutClient.ShoppingListService.GetItem(model.Drink.Name);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void GetList()
        {
            var item1 = CheckoutClient.ShoppingListService.CreateItem(TestHelper.GetShoppingItemCreateRandomModel());
            var item2 = CheckoutClient.ShoppingListService.CreateItem(TestHelper.GetShoppingItemCreateRandomModel());
            var item3 = CheckoutClient.ShoppingListService.CreateItem(TestHelper.GetShoppingItemCreateRandomModel());
            var item4 = CheckoutClient.ShoppingListService.CreateItem(TestHelper.GetShoppingItemCreateRandomModel());

            //Get all customers created
            var response = CheckoutClient.ShoppingListService.GetShoppingList();

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Data.Count.Should().BeGreaterOrEqualTo(4);
        }

        [Test]
        public void UpdateItem()
        {
            var item = TestHelper.GetShoppingItemCreateCocaColaModel();

            CheckoutClient.ShoppingListService.CreateItem(item);

            var updateModel = TestHelper.GetShoppingItemUpdateCocaColaModel();
            var response = CheckoutClient.ShoppingListService.UpdateItem(updateModel);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Message.Should().BeEquivalentTo("Ok");
        }
    }
}