using System;
using Amib.Threading;
using Action = System.Action;

namespace CoolNameGenerator.Helper.Threading
{
    /// <summary>
    ///     A ITaskExecutor's implementation using SmartThreadPool to execute tasks in parallel.
    /// </summary>
    public sealed class SmartThreadPoolTaskExecutor : TaskExecutorBase, IDisposable
    {
        #region Fields

        private SmartThreadPool _mThreadPool;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SmartThreadPoolTaskExecutor" /> class.
        /// </summary>
        public SmartThreadPoolTaskExecutor()
        {
            MinThreads = 2;
            MaxThreads = 2;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the minimum threads.
        /// </summary>
        /// <value>The minimum threads.</value>
        public int MinThreads { get; set; }

        /// <summary>
        ///     Gets or sets the max threads.
        /// </summary>
        /// <value>The max threads.</value>
        public int MaxThreads { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Starts the tasks execution.
        /// </summary>
        /// <returns>If has reach the timeout false, otherwise true.</returns>
        public override bool Start()
        {
            base.Start();
            _mThreadPool = new SmartThreadPool();

            try
            {
                _mThreadPool.MinThreads = MinThreads;
                _mThreadPool.MaxThreads = MaxThreads;
                var workItemResults = new IWorkItemResult[Tasks.Count];

                for (var i = 0; i < Tasks.Count; i++)
                {
                    var t = Tasks[i];
                    workItemResults[i] = _mThreadPool.QueueWorkItem(new WorkItemCallback(Run), t);
                }

                _mThreadPool.Start();

                // Timeout was reach?
                if (
                    !_mThreadPool.WaitForIdle(Timeout.TotalMilliseconds > int.MaxValue
                        ? int.MaxValue
                        : Convert.ToInt32(Timeout.TotalMilliseconds)))
                {
                    if (_mThreadPool.IsShuttingdown)
                    {
                        return true;
                    }
                    else
                    {
                        _mThreadPool.Cancel(true);
                        return false;
                    }
                }

                foreach (var wi in workItemResults)
                {
                    Exception ex;
                    wi.GetResult(out ex);

                    if (ex != null)
                    {
                        throw ex;
                    }
                }

                return true;
            }
            finally
            {
                _mThreadPool.Shutdown(true, 1000);
                _mThreadPool.Dispose();
                IsRunning = false;
            }
        }

        /// <summary>
        ///     Stops the tasks execution.
        /// </summary>
        public override void Stop()
        {
            base.Stop();

            if (_mThreadPool != null && !_mThreadPool.IsShuttingdown)
            {
                _mThreadPool.Shutdown(true, Timeout);
            }

            IsRunning = false;
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _mThreadPool?.Dispose();

            GC.SuppressFinalize(this);
        }

        private object Run(object state)
        {
            ((Action) state)();

            return true;
        }

        #endregion
    }
}