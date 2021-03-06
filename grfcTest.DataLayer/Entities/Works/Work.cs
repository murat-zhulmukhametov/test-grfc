﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using grfcTest.DataLayer.Common;

namespace grfcTest.DataLayer.Entities.Works
{
    [Table("works")]
    public class Work : IgrfcEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public EngineType EngineType { get; set; }
    }
}