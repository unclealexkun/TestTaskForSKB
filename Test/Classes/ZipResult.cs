using Test.Enums;

namespace Test.Classes
{
    public struct ZipResult
    {
        private readonly StringPartition mCommonHead;
        private readonly StringPartition mOtherRest;
        private readonly StringPartition mThisRest;

        public ZipResult(StringPartition commonHead, StringPartition thisRest, StringPartition otherRest)
        {
            mCommonHead = commonHead;
            mThisRest = thisRest;
            mOtherRest = otherRest;
        }

        public MatchKind MatchKind
        {
            get
            {
                return mThisRest.Length == 0
                    ? (mOtherRest.Length == 0
                        ? MatchKind.ExactMatch
                        : MatchKind.IsContained)
                    : (mOtherRest.Length == 0
                        ? MatchKind.Contains
                        : MatchKind.Partial);
            }
        }

        public StringPartition OtherRest
        {
            get { return mOtherRest; }
        }

        public StringPartition ThisRest
        {
            get { return mThisRest; }
        }

        public StringPartition CommonHead
        {
            get { return mCommonHead; }
        }


        public bool Equals(ZipResult other)
        {
            return
                mCommonHead == other.mCommonHead &&
                mOtherRest == other.mOtherRest &&
                mThisRest == other.mThisRest;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ZipResult && Equals((ZipResult)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = mCommonHead.GetHashCode();
                hashCode = (hashCode * 397) ^ mOtherRest.GetHashCode();
                hashCode = (hashCode * 397) ^ mThisRest.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(ZipResult left, ZipResult right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ZipResult left, ZipResult right)
        {
            return !(left == right);
        }
    }
}