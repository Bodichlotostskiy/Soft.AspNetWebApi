using System;

namespace RB_Soft.Data.Core
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
