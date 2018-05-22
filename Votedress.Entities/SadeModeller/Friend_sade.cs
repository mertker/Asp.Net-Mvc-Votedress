using System;

namespace Votedress.Entities.SadeModeller
{
    public class Friend_sade
    {
        public Friend_sade()
        {
        }

        public Guid UserId { get; set; }
        public string UserNameSurname { get; set; }
        public string UserProfileImage { get; set; }
        public DateTime Tarih { get; set; }
    }
}