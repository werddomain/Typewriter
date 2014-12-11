﻿using System;
using System.Collections.Generic;

namespace Typewriter.CodeModel
{
    public interface IItemInfo
    {
        [Property("string Name", "The name of the $context")]
        string Name { get; }

        [Property("string name", "The name of the $context (camelCased)")]
        string name { get; }

        [Property("string FullName", "The namespace and name of the $context")]
        string FullName { get; }

        [Property("collection Attributes", "All attributes defined on the $context")]
        ICollection<IAttributeInfo> Attributes { get; }
    }
}