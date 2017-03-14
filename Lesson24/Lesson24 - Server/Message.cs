using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson24___Server
{
    class Message
    {
        public string content { get; set; }
        public string sender { get; set; }

        private DateTime _createdOn;

        public DateTime createdOn
        {
            get
            {
                return _createdOn;
            }
        }

        public Message(string content, string sender)
        {
            this.content = content;
            this.sender = sender;
            _createdOn = DateTime.Now;
        }
    }
}
