﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Aggregates.PostAggregate
{
    public class PostInteraction
    {
        public Guid InteractionId { get; set; }
        public Guid PostId { get; set; }
        public InteractionType InteractionType { get; set; }
    }
}
