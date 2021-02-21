using countdown_api.Data;
using countdown_api.Data.Tables;
using countdown_api.Models.Events;
using countdown_api.Models.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace countdown_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private CountDownContext _db;

        public EventController(CountDownContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<EventVM>> Get()
        {
            List<EventVM> events = await _db.Event.
                Select(t => new EventVM { 
                     Id = t.Id,
                     EventDate = t.EventDate,
                     Name = t.Name
                }).ToListAsync();
            return events;
        }

        [HttpPost]
        public async Task<ErrorVM> Post(Create create)
        {
            ErrorVM error = new ErrorVM { No = 1, Description = "Data saved succesfully" };

            _db.Event.Add(new Event
            {
                 EventDate = create.date,
                 Name = create.name,
                 UserId = 2
            });
            try
            {
                await _db.SaveChangesAsync();
            }catch(Exception ex)
            {
                error = new ErrorVM { No = 4, Description = "There was an error during save!" };
            }
            return error;
        }

        [HttpDelete]
        public async Task<ErrorVM> Delete(int id)
        {
            ErrorVM error = new ErrorVM { No = 1, Description = "Data saved succesfully" };
            try
            {
                _db.Event.Remove(await _db.Event.FindAsync(id));
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                error = new ErrorVM { No = 4, Description = "There was an error during save!" };
            }
            return error;
        }
    }
}
