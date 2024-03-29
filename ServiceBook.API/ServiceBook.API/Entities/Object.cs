﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceBook.API.Entities
{
    public class Object : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string ImageName { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public Guid CompanyId { get; set; }

        [ForeignKey("TypeId")]
        public ObjectType Type { get; set; }

        public Guid TypeId { get; set; }

        [ForeignKey("TfmId")]
        public Tfm Tfm { get; set; }

        public Guid TfmId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ObjectIdentifier { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public IList<ObjectUser> ObjectUsers { get; set; }

        public IList<ObjectDepartment> ObjectDepartments { get; set; }
    }
}
