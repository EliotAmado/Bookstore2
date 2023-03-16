using Bookstore2.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookstore2.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket(IServiceProvider services) //making an instance of the service 
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; //question markes means could be null, in this line of code we set up a session

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();//if a session has been started see if its there and get it started. Otherwise create a new session basket

            basket.Session = session; //update session

            return basket;
        }

        [JsonIgnore] //prevents a property from being serialized or descerialized
        public ISession Session { get; set; }


        //These methods below are from our Donate class
        public override void AddItem(Book proj, int qty)
        {
            base.AddItem(proj, qty);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book proj)
        {
            base.RemoveItem(proj);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }

    }
}
