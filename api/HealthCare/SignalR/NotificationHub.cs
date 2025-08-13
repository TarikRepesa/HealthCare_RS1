using HealthCare.Data;
using HealthCare.Models;
using HealthCare.ViewModels.Obavijesti;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.SignalR
{
    public class NotificationHub : Hub
    {
        private readonly ApplicationDbContext _dbContext;

        public NotificationHub(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task authMe(string userId)
        {
            var user = _dbContext.Korisnik.Where(x => x.Id == userId).FirstOrDefault();

            if (user != null)
            {
                await Clients.Caller.SendAsync("authMeResponseSuccess", user.Ime);
            }
            else
            {
                await Clients.Caller.SendAsync("authMeResponseFail");
            }
        }

        public async Task GetObavijesti()
        {
            var data = _dbContext.Obavijesti
                .Include("Osoblje")
                .Select(x => new ObavijestiVM()
                {
                    id = x.Id,
                    poruka = x.Poruka,
                    datumVrijemeSlanja = x.DatumVrijemeSlanja,
                    ime = x.Osoblje.Ime,
                    prezime = x.Osoblje.Prezime
                })
                .OrderByDescending(comparer => comparer.id)
                .ToList();

            await Clients.All.SendAsync("GetObavijestiResponse", data);
        }

        public async Task SendNotification(string Id, string message)
        {
            var user = _dbContext.Osoblje.Where(x => x.Id == Id).SingleOrDefault();

            if (user != null)
            {
                var newNotification = new Obavijesti()
                {
                    Poruka = message,
                    OsobljeId = user.Id,
                    DatumVrijemeSlanja = DateTime.Now
                };

                await _dbContext.Obavijesti.AddAsync(newNotification);
                await _dbContext.SaveChangesAsync();

                await Clients.Caller.SendAsync("SendNotificationResponseSuccess");
            }
            else
            {
                await Clients.Caller.SendAsync("SendNotificationResponseFail");
            }
        }

        public async Task RemoveNotification(int id, string userId)
        {
            var notification = _dbContext.Obavijesti.Where(x => x.Id == id && x.OsobljeId == userId).FirstOrDefault();

            if (notification != null)
            {
                _dbContext.Obavijesti.Remove(notification);
                await _dbContext.SaveChangesAsync();

                await Clients.Caller.SendAsync("RemoveNotificationResponseSuccess");
            }
            else
            {
                await Clients.Caller.SendAsync("RemoveNotificationResponseFail");
            }
        }
    }
}
