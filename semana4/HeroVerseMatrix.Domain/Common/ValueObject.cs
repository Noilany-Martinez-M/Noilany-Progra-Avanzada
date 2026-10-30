using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroVerseMatrix.Domain.Common
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            var other = obj as ValueObject;
            if(other == null || other.GetType() != GetType())
            {
                return false;
            }

            using (var letf = GetEqualityComponents().GetEnumerator())
            {
                using(var right = other.GetEqualityComponents().GetEnumerator())
                {
                    while (true)
                    {
                        var hasNextLeft = letf.MoveNext();
                        var hasNextRight = right.MoveNext();

                        if(!hasNextLeft && !hasNextRight)
                        {
                            return hasNextLeft == hasNextRight;
                        }

                        if(!Equals(letf.Current, right.Current))
                        {
                            return false;
                        }
                    }
                }
            }
        }
    }
}
