using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test.Classes
{
    public struct StringPartition : IEnumerable<char>
    {
        private readonly string mOrigin;
        private readonly int mPartitionLength;
        private readonly int mStartIndex;

        public StringPartition(string origin)
            : this(origin, 0, origin == null ? 0 : origin.Length)
        {
        }

        public StringPartition(string origin, int startIndex)
            : this(origin, startIndex, origin == null ? 0 : origin.Length - startIndex)
        {
        }

        public StringPartition(string origin, int startIndex, int partitionLength)
        {
            if (origin == null) throw new ArgumentNullException("origin");
            if (startIndex < 0) throw new ArgumentOutOfRangeException("startIndex", "The value must be non negative.");
            if (partitionLength < 0)
                throw new ArgumentOutOfRangeException("partitionLength", "The value must be non negative.");
            mOrigin = string.Intern(origin);
            mStartIndex = startIndex;
            int availableLength = mOrigin.Length - startIndex;
            mPartitionLength = Math.Min(partitionLength, availableLength);
        }

        public char this[int index]
        {
            get { return mOrigin[mStartIndex + index]; }
        }

        public int Length
        {
            get { return mPartitionLength; }
        }

        #region IEnumerable<char> Members

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < mPartitionLength; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public bool Equals(StringPartition other)
        {
            return string.Equals(mOrigin, other.mOrigin) && mPartitionLength == other.mPartitionLength &&
                   mStartIndex == other.mStartIndex;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is StringPartition && Equals((StringPartition)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (mOrigin != null ? mOrigin.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ mPartitionLength;
                hashCode = (hashCode * 397) ^ mStartIndex;
                return hashCode;
            }
        }

        public bool StartsWith(StringPartition other)
        {
            if (Length < other.Length)
            {
                return false;
            }

            for (int i = 0; i < other.Length; i++)
            {
                if (this[i] != other[i])
                {
                    return false;
                }
            }
            return true;
        }

        public struct SplitResult
        {
            private readonly StringPartition mHead;
            private readonly StringPartition mRest;

            public SplitResult(StringPartition head, StringPartition rest)
            {
                mHead = head;
                mRest = rest;
            }

            public StringPartition Rest
            {
                get { return mRest; }
            }

            public StringPartition Head
            {
                get { return mHead; }
            }

            public bool Equals(SplitResult other)
            {
                return mHead == other.mHead && mRest == other.mRest;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is SplitResult && Equals((SplitResult)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (mHead.GetHashCode() * 397) ^ mRest.GetHashCode();
                }
            }

            public static bool operator ==(SplitResult left, SplitResult right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(SplitResult left, SplitResult right)
            {
                return !(left == right);
            }
        }

        public SplitResult Split(int splitAt)
        {
            var head = new StringPartition(mOrigin, mStartIndex, splitAt);
            var rest = new StringPartition(mOrigin, mStartIndex + splitAt, Length - splitAt);
            return new SplitResult(head, rest);
        }

        public ZipResult ZipWith(StringPartition other)
        {
            int splitIndex = 0;
            using (IEnumerator<char> thisEnumerator = GetEnumerator())
            using (IEnumerator<char> otherEnumerator = other.GetEnumerator())
            {
                while (thisEnumerator.MoveNext() && otherEnumerator.MoveNext())
                {
                    if (thisEnumerator.Current != otherEnumerator.Current)
                    {
                        break;
                    }
                    splitIndex++;
                }
            }

            SplitResult thisSplitted = Split(splitIndex);
            SplitResult otherSplitted = other.Split(splitIndex);

            StringPartition commonHead = thisSplitted.Head;
            StringPartition restThis = thisSplitted.Rest;
            StringPartition restOther = otherSplitted.Rest;
            return new ZipResult(commonHead, restThis, restOther);
        }

        public override string ToString()
        {
            var result = new string(this.ToArray());
            return string.Intern(result);
        }

        public static bool operator ==(StringPartition left, StringPartition right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(StringPartition left, StringPartition right)
        {
            return !(left == right);
        }
    }
}