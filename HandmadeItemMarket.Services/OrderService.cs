using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using HandmadeItemMarket.Models.EntityModels;
using HandmadeItemMarket.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace HandmadeItemMarket.Services
{
    using System.Data.Entity.Migrations;

    public class OrderService:Service
    {
        public IEnumerable<OrderVM> RetrieveRecievedOrders(string currentUserId)
        {
            IEnumerable<Order> Orders = this.Context.Orders.Where(a => a.Seller.Id == currentUserId).ToList();
            IEnumerable<OrderVM> vms = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderVM>>(Orders);
            return vms;
        }

        public void SendMail(string sellerId)
        {
            try
            {
            var user = Context.Users.FirstOrDefault(u => u.Id == sellerId);
            MailMessage mail = new MailMessage();
            mail.To.Add(user.UserName);
            mail.From = new MailAddress("slavradev@gmail.com");
            mail.Subject = "New Order";

            string Body = "Hi, this message was sent to inform you that you have a new order recieved in ScriBu. </br>" +
                          "-ScriBuBot <3";
            mail.Body = Body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential
                 ("slavradev@gmail.com", "9703175848");
            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);
            }
            catch (Exception e)
            {

            }
        }

        public Order CreateOrder(string currentUserId,int id)
        {
            var order = new Order()
            {
                Product = Context.Products.FirstOrDefault(p => p.Id == id),
                OrderedOn = DateTime.Now,
                Buyer = Context.Users.FirstOrDefault(u => u.Id == currentUserId)
            };
            return order;
        }

        public void RaiseProductRating(int id)
        {
           var product = this.Context.Products.FirstOrDefault(p => p.Id == id);
            product.Rating = product.Rating + 1;
            Context.Products.AddOrUpdate(product);
            Context.SaveChanges();
        }
    }
}
