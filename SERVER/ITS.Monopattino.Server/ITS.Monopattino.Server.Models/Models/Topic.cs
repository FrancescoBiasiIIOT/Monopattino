using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Models.Models
{
    public class Topic
    {

        public int ScooterId { get; set; }

        public string TopicName { get; set; }

        public Topic(string topicContainer)
        {
            var topic = topicContainer.Split('.');
            TopicName = topic[3];
            ScooterId = Convert.ToInt32(topic[2]);

        }
    }
}
