using System;

namespace DI_Container
{
    public class RandomGuidGenerator
    {
        public Guid RandomGuid { get; set; } = Guid.NewGuid();
    }
}