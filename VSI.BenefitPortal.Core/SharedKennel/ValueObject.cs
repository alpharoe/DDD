using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace VSI.BenefitPortal.Core.SharedKennel
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        private List<PropertyInfo> properties;

        private List<FieldInfo> fields;

        #region public 
        public static bool operator ==(ValueObject obj1, ValueObject obj2)
        {
            if (object.Equals(obj1, null))
            {
                if (object.Equals(obj2, null))
                {
                    return true;
                }
                return false;
            }
            return obj1.Equals(obj2);
        }

        public static bool operator !=(ValueObject obj1, ValueObject obj2)
        {
            return !(obj1 == obj2);
        }


        public bool Equals(ValueObject other)
        {
            return Equals(other as object);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            return GetProperties().All(p => PropertiesAreEqual(obj, p))
                  && GetFields().All(f => FieldsAreEqual(obj, f));

        }

        private bool PropertiesAreEqual(object obj, PropertyInfo p)
        {
            return object.Equals(p.GetValue(this, null), p.GetValue(obj, null));
        }

        private bool FieldsAreEqual(object obj, FieldInfo f)
        {
            return object.Equals(f.GetValue(this), f.GetValue(obj));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                foreach (var prop in GetProperties())
                {
                    var value = prop.GetValue(this, null);
                    hash = HashValue(hash, value);
                }

                foreach (var field in GetFields())
                {
                    var value = field.GetValue(this);
                    hash = HashValue(hash, value);
                }
                return hash;
            }
        }
        #endregion

        private IEnumerable<PropertyInfo> GetProperties()
        {
            if (this.properties == null)
            {
                this.properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                                              .Where(p => p.GetCustomAttribute(typeof(IgnoreCompareAttribute)) == null)
                                                              .ToList();
            }

            return this.properties;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            if (this.fields == null)
            {
                this.fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
                                                      .Where(p => p.GetCustomAttribute(typeof(IgnoreCompareAttribute)) == null)
                                                      .ToList();
            }

            return this.fields;
        }

        private int HashValue(int seed, object value)
        {
            var currentHash = value != null ? value.GetHashCode() : 0;

            return seed * 23 + currentHash;
        }
    }
}
