using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Repository
{
    public class ParticipantRepository : IRepository<Participant>
    {
        private readonly ApplicationDbContext _dbContext;

        public ParticipantRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Participant> GetAll()
        {
            return _dbContext.Participants.ToList();
        }
        public Participant GetById(int id)
        {
            return _dbContext.Participants.Find(id);
        }
        public bool Insert(Participant item)
        {
            item.ParticipantId = 0;
            item.Results = new List<Result>();
            _dbContext.Participants.Add(item);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var foundParticipant = _dbContext.Participants.Find(id);
            _dbContext.Participants.Remove(foundParticipant);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Modify(int id, Participant item)
        {
            var foundParticipant = _dbContext.Participants.Find(id);

            foundParticipant.FirstName = item.FirstName;
            foundParticipant.LastName = item.LastName;
            return _dbContext.SaveChanges() > 0;
        }
    }
}