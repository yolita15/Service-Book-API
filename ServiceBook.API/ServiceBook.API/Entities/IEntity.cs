using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceBook.API.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
