using ApiSample.DTOs.Guests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.DAL
{
    public class EntityFrameworkExampleService : IExampleService
    {
        public bool AddGuest(GuestRequestDto newGuest)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGuest(int id)
        {
            throw new NotImplementedException();
        }

        public GuestResponseDto GetGuestById(int idGuest)
        {
            throw new NotImplementedException();
        }

        public ICollection<GuestResponseDto> GetGuestsCollection(string lastName)
        {
            throw new NotImplementedException();
        }

        public string Test()
        {
            return "Działa! ta wersja API korzysta z bazy danych mssql API_hotel przy użyciu Entity Framework";
        }

        public bool UpdateGuest(int id, GuestRequestDto updateGuest)
        {
            throw new NotImplementedException();
        }
    }
}
