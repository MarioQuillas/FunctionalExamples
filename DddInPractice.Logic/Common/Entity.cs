namespace DddInPractice.Logic.Common
{
    using System;

    using NHibernate.Proxy;

    public abstract class Entity
    {
        public virtual long Id { get; protected set; }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null)) return false;

            if (ReferenceEquals(this, other)) return true;

            if (this.GetRealType() != other.GetRealType()) return false;

            if (this.Id == 0 || other.Id == 0) return false;

            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return (this.GetRealType().ToString() + this.Id).GetHashCode();
        }

        private Type GetRealType()
        {
            return NHibernateProxyHelper.GetClassWithoutInitializingProxy(this);
        }
    }
}