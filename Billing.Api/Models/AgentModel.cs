using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Billing.Api.Models
{
    //Početak onog što mi je Edin poslao
    public class AgentModel
    {
        public AgentModel()
        {
            Towns = new List<string>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Towns { get; set; }
    }
    //Završetak onog što mi je Edin poslao
}