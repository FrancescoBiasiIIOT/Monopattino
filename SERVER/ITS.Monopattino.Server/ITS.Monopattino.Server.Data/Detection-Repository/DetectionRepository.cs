using ITS.Monopattino.Server.Data.Detection_Repository;
using ITS.Monopattino.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITS.Monopattino.Server.Data
{
    public class DetectionRepository : IDetectionRepository
    {
        //ACCESSO AI DATI
        public ValleProjectContext Context{ get; set; }

        public DetectionRepository(ValleProjectContext context)
        {
            Context = context;
        }
        public IEnumerable<Detection> GetDetections()
        {
            return Context.Detections.
                Include(d => d.Scooter).
                ToList(); //ritorna tutto il contenuto della tabella
        }

        public IEnumerable<Detection> GetDetectionsByScooter(int scooterId)
        {
            return Context.Detections.
                Include(d => d.Scooter).Where(sc => sc.Id == scooterId).
                ToList(); //ritorna tutto il contenuto della tabella
        }

        public void InsertDetection(Detection detection)
        {
            Context.Detections.Add(detection);
            Context.SaveChanges();
        }
    }
}
