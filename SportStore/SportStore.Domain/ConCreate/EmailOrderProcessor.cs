using SportStore.Domain.ConCreate;
using SportStore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStore.Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace SportStore.Domain.ConCreate


{
    public class EmailSettings
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "Sportsstore@example.com";
        public bool UserSsl = true;
        public string UserName = "내이름";
        public string UserPassword = "비밀번호";
        public string ServerName = "smtp.exmple.com";
        public int ServerPort = 587;
        public bool WriteAsfile = false;
        public string FileLocation = @"c:\sports_store_emails";
    }
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailsettings;
        public void ProcessOrder(Cart cart, ShoppingDetail detail)
        {
            using (var stmpClient = new SmtpClient())
            {
                stmpClient.EnableSsl = emailsettings.UserSsl;
                stmpClient.Host = emailsettings.ServerName;
                stmpClient.Port = emailsettings.ServerPort;
                stmpClient.UseDefaultCredentials = false;
                stmpClient.Credentials = new NetworkCredential(emailsettings.UserName, emailsettings.UserPassword);

                if (emailsettings.WriteAsfile)
                {
                    stmpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    stmpClient.PickupDirectoryLocation = emailsettings.FileLocation;
                    stmpClient.EnableSsl = false;

                }

                StringBuilder body = new StringBuilder()
                .AppendLine("새 주문이 제출 되었습니다.")
                .AppendLine("==============")
                .AppendLine("Items");


                foreach (var line in cart.cartLine)
                {
                    var subTotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity, line.Product.Name, subTotal);

                }
                body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("=======")
                    .AppendLine("ship to")
                    .AppendLine(detail.Name)
                    .AppendLine(detail.Line1)
                    .AppendLine(detail.Line2 ?? "")
                    .AppendLine(detail.Line3 ?? "")
                    .AppendLine(detail.City)
                    .AppendLine(detail.State ?? "")
                    .AppendLine(detail.Country)
                    .AppendLine(detail.Zip)
                    .AppendLine("-----")
                    .AppendFormat("선물 옵션: {0}", detail.GiftWarp);

                MailMessage mail = new MailMessage(
                    emailsettings.MailFromAddress,
                    emailsettings.MailToAddress,
                    "새로운 주문!",
                    body.ToString());

                if (emailsettings.WriteAsfile)
                {
                    mail.BodyEncoding = Encoding.ASCII;
                }
                stmpClient.Send(mail);
            }
        }
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailsettings = settings;
        }




    }
}
