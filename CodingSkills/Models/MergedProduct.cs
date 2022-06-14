using System;
using System.Collections.Generic;

namespace CodingSkills.Models
{
    public class MergedProduct : IEquatable<MergedProduct>
    {
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }

        public bool Equals(MergedProduct other)
        {
            if (SKU == other.SKU && Source == other.Source)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hashSKU = SKU == null ? 0 : SKU.GetHashCode();
            int hashSource = Source == null ? 0 : Source.GetHashCode();

            return hashSKU ^ hashSource;
        }
    }
}