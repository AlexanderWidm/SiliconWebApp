using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class SubscribeFactory
{
    public static SubscribeEntity Create(SubscribeForm form)
    {
        try
        {
            var datetime = DateTime.Now;
            return new SubscribeEntity
            {
                Email= form.Email,
                DailyNewsletter= form.DailyNewsletter,
                AdvertisingUpdates= form.AdvertisingUpdates,
                WeekinReview= form.WeekinReview,
                EventUpdates= form.EventUpdates,
                StartupsWeekly= form.StartupsWeekly,
                Podcasts= form.Podcasts,
                Created = datetime,
                Modified = datetime
            };
        }
        catch { }
        return null!;
    }
}
